using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using MaasOne.Finance;
using System.Xml.Linq;
using System.IO;

namespace TradeApp
{
    public partial class ClsDashBoard: Form
    {
        public BackgroundWorker m_oWorker;
        public BackgroundWorker m_oWorker_LiveRefresh;
        public static int OverallProgress { get; set; }
        public static int ScriptProgress { get; set; }
        public static int OverallPbarMax { get; set; }
        public static int ScriptPbarMax { get; set; }
        public static string ScriptSStatus { get; set; }
        public static string ScriptOStatus { get; set; }
        public static bool ChangeOPbarValue { get; set; }
        public static bool ChangeSPbarValue { get; set; }
        public static string DataDate { get; set; }
        private bool OneDayData;
        List<DateTime> Dates;
        private bool UpdatedData;
        private System.Windows.Forms.Timer Tm=new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer Tm_RefreshLive = new System.Windows.Forms.Timer();
        int i = 0;
        int j = 0;
        DataTable dtLiveData = new DataTable();
        public ClsDashBoard()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker_LiveRefresh = new BackgroundWorker();
            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
            //Live data refresh Backround Worker block
            m_oWorker_LiveRefresh.DoWork += M_oWorker_LiveRefresh_DoWork;
            m_oWorker_LiveRefresh.ProgressChanged += M_oWorker_LiveRefresh_ProgressChanged;
            m_oWorker_LiveRefresh.RunWorkerCompleted += M_oWorker_LiveRefresh_RunWorkerCompleted;
            m_oWorker_LiveRefresh.WorkerReportsProgress = true;
            m_oWorker_LiveRefresh.WorkerSupportsCancellation = true;
            DgvAllDma.AutoGenerateColumns = false;
            DgvAllEma.AutoGenerateColumns = false;
            DgvDCross.AutoGenerateColumns = false;
            DgvGCross.AutoGenerateColumns = false;
            Dgv50_200.AutoGenerateColumns = false;
            DgvLiveData.AutoGenerateColumns = false;
            DgvSwing.AutoGenerateColumns = false;
            UpdatedData = false;
            CB50DMA.Items.Add("50");
            CB50DMA.Items.Add("200");
            CB50DMA.Items.Add("50+200");
            CB50DMA.SelectedIndex = 0;
            CmbRefreshTime.Items.Add(".5");
            CmbRefreshTime.Items.Add("1");
            CmbRefreshTime.Items.Add("3");
            CmbRefreshTime.Items.Add("5");
            CmbRefreshTime.SelectedIndex = 1;
            ClsLog.WriteLog("**********************************App Start*************************** Date: "+DateTime.Today.ToLongDateString());
            Tm.Tick += Tm_Tick;
            Tm.Interval = 1000;
            Tm_RefreshLive.Tick += Tm_RefreshLive_Tick;
            Tm_RefreshLive.Interval = 1000*60;
        }

        private void M_oWorker_LiveRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DgvLiveData.DataSource = null;
            DgvLiveData.DataSource = dtLiveData;
            LabLiveStatus.Visible = false;
        }

        private void M_oWorker_LiveRefresh_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void M_oWorker_LiveRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            
            dtLiveData = null;
            dtLiveData = ClsPriceDataSetLive.TblLiveData;
        }

        private void Tm_RefreshLive_Tick(object sender, EventArgs e)
        {
            LabLiveStatus.Visible = true;
            if(!m_oWorker_LiveRefresh.IsBusy)
            m_oWorker_LiveRefresh.RunWorkerAsync();
            //LabLiveStatus.Visible = false;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            if (i == 60)
            {
                j = j + 1;
                i = 0;
            }
            LabTimeElapsed.Text = j.ToString() + ":" + (++i).ToString();
        }

        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                lblStatus.Text = "Task Cancelled.";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                // Everything completed normally.
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                labStckStatus.Text = "Download Complete..";
                lblStatus.Text = "Download Complete..";
                ClsLog.WriteLog("Download Complete.");
                ClsDataBase.UpdateConfigTbl("LastDataDate", Dates[Dates.Count - 1].ToString("yyyy-MM-dd"));
                BtnJson.Enabled = true;
                BtnGetData.Enabled = true;
                UpdatedData = true;
                
            }
            UpdateDashBoard();
            Tm.Enabled = false;
            LabTotalTime.Visible = false;
            LabTimeElapsed.Visible = false;
            //Change the status of the buttons on the UI accordingly

        }

       public void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // Update the progressBar with the integer supplied to us from the

            // ReportProgress() function.  
            try
            {
                if (e.ProgressPercentage == 0)
                {
                    if (ChangeOPbarValue)
                    {
                        progressBar1.Maximum = OverallPbarMax;

                    }
                    if (ChangeSPbarValue)
                    {
                        ChangeSPbarValue = false;
                        progressBar2.Maximum = ScriptPbarMax;
                    }
                    progressBar1.Value = OverallProgress;
                    progressBar2.Value = ScriptProgress;
                    lblStatus.Text = "Downloading Data for NSE scripts......" + ScriptOStatus;
                    labStckStatus.Text = "Downloading Data for " + ScriptSStatus;
                }
                else if(e.ProgressPercentage==1)
                {
                    progressBar1.Value = 0;
                    progressBar2.Value = 0;
                    lblStatus.Text = "Data Download Complete. Running EMA DMA Update SP. Please wait..";
                    labStckStatus.Text = "Please wait..";
                }
                else if (e.ProgressPercentage == 2)
                {
                    progressBar1.Value = 0;
                    LabDates.Text = DataDate;
                                        
                }
            }
            catch(Exception ex)
            {
                ClsLog.WriteLog("ERROR: "+ex.Message);
            }

        }


        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //ClsGetEodData.DownlaodBulkEodData(ref m_oWorker,Dates);
            ClsGetEodData.DownloadEodDataNSEBhav(ref m_oWorker, Dates);
            if (m_oWorker.CancellationPending)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was cancelled.
                e.Cancel = true;
                m_oWorker.ReportProgress(0);
                return;
            }
        }

        

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            ChangeOPbarValue = true;
            ChangeSPbarValue = false;
            OneDayData = true;
            ClsLog.WriteLog("Initiating Daily Stock Data Download.. ");
            BtnGetData.Enabled = false;
            m_oWorker.RunWorkerAsync();
            Tm.Enabled = true;
            LabUpdateEOD.ForeColor = Color.Green;
            LabUpdateEOD.Text = "Please Wait...Data is being download.";
            label1.ForeColor = Color.Green;
            LabTotalTime.Visible = true;
            LabTimeElapsed.Visible = true;
            // ClsDataBase.InsertScriptCode();
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {
            ClsDataBase.InsertScriptCode();
            //if (MessageBox.Show("Are you sure to download complete data, this operation will take huge time!!","Warning!!",MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    ChangeOPbarValue = true;
            //    ChangeSPbarValue = false;
            //    OneDayData = false;
            //    BtnJson.Enabled = false;
            //    ClsLog.WriteLog("Initiating Bulk Stock Data Download.. ");
            //    m_oWorker.RunWorkerAsync();
            //}

        }

        private void ClsDashBoard_Load(object sender, EventArgs e)
        {
            UpdateDashBoard();
        }
        private void UpdateDashBoard()
        {
            DataTable dt;
            int i=0;
            try
            {
                Dates = ClsDataBase.GetDatesForDataDownload(ClsDataBase.GetConfigValue("LastDataDate"),null);

            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: Load Function, DashBoard module: " + ex.Message);
            }
            if (Dates.Count == 0)
            {
                UpdatedData = true;
                label1.ForeColor = Color.Green;
                label1.Text = "Data is up to date!!";
                LabDates.Visible = false;
                BtnGetData.Enabled = false;
                BtnJson.Enabled = false;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox8.Enabled = true;
                Grv.Enabled = true;
            }
            else
            {
                UpdatedData = false;
                label1.ForeColor = Color.Red;
                label1.Text = "Data to be downloaded for the dates(" + Dates.Count.ToString() + ") :";
                BtnGetData.Enabled = true;
                BtnJson.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                groupBox8.Enabled = false;
                Grv.Enabled = false;
                
            }
            
            foreach (var Date in Dates)
            {
                if (i <= 3)
                {
                    LabDates.Text = LabDates.Text + Date.Date.Day.ToString() + "-" + Date.Date.Month.ToString() + ", ";
                    i++;
                }
                else

                {
                    LabDates.Text = LabDates.Text.Remove(LabDates.Text.Length - 2);
                    LabDates.Text = LabDates.Text + " + " + (Dates.Count - i).ToString() + " More";
                    break;
                }
            }
            if (UpdatedData)
            {
                dt = ClsDataBase.GetBreakOutData(1);
                if (dt != null)
                    DgvAllDma.DataSource = dt;
                PanUpdateEOD.Visible = false;
                dt = ClsDataBase.GetBreakOutData(2);
                if (dt != null)
                    Dgv50_200.DataSource = dt;
                dt = ClsDataBase.GetBreakOutData(5);
                if (dt != null)
                    DgvGCross.DataSource = dt;
                dt = ClsDataBase.GetSwingScriptData();
                if (dt != null)
                    DgvSwing.DataSource = dt;
                dt = ClsDataBase.GetSwingThit(true);
                foreach (DataRow item in dt.Rows)
                {
                    RTxtSwing.AppendText("It's Time to BUY:"+item[0].ToString()+" CP:"+ item[1].ToString());
                    RTxtSwing.AppendText(Environment.NewLine);                    
                }
                RTxtSwing.Select(0, RTxtSwing.Text.Length);
                RTxtSwing.SelectionColor = Color.Green;
                dt = ClsDataBase.GetSwingThit(false);
                var txtLenth = RTxtSwing.Text.Length;
                foreach (DataRow item in dt.Rows)
                {
                    RTxtSwing.AppendText("It's Time to SELL:" + item[0].ToString() + " CP:" + item[1].ToString());
                    RTxtSwing.AppendText(Environment.NewLine);                    
                }
                RTxtSwing.Select(txtLenth,RTxtSwing.Text.Length- txtLenth);
                RTxtSwing.SelectionColor = Color.Red;


            }
            else
            {
                PanUpdateEOD.Visible = true;
            }
            LabDataDetails.Text = "Latest Data Date: " + ClsDataBase.GetConfigValue("LastDataDate");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddFav_Click(object sender, EventArgs e)
        {
            FrmScriptSelection ObjFrmSelection = new FrmScriptSelection();
            ObjFrmSelection.ShowDialog();
            DgvSwing.DataSource= ClsDataBase.GetSwingScriptData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void CB50DMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatedData)
            {
                DataTable dt;
                Dgv50_200.DataSource = null;
                if (CB50DMA.SelectedItem.ToString() == "200")
                {
                    dt = ClsDataBase.GetBreakOutData(3);
                    if (dt != null)
                        Dgv50_200.DataSource = dt;
                }
                if (CB50DMA.SelectedItem.ToString() == "50")
                {
                    dt = ClsDataBase.GetBreakOutData(2);
                    if (dt != null)
                        Dgv50_200.DataSource = dt;
                }
                if (CB50DMA.SelectedItem.ToString() == "50+200")
                {
                    dt = ClsDataBase.GetBreakOutData(4);
                    if (dt != null)
                        Dgv50_200.DataSource = dt;
                }
            }
        }

        private void BtnPopOut_Click(object sender, EventArgs e)
        {
            
            if(CB50DMA.SelectedItem.ToString()=="50")
            FrmGridDetails.StrHeader = "50 DMA BeakOut Scripts";
            else if(CB50DMA.SelectedItem.ToString() == "200")
            FrmGridDetails.StrHeader = "200 DMA BeakOut Scripts";
            else
            FrmGridDetails.StrHeader = "50 and 200 DMA BeakOut Scripts";

            FrmGridDetails.StrScriptIdCol = "ScriptId_200DMA";
            FrmGridDetails.StrScriptPriceCol = "LastClosePrice_50";
            FrmGridDetails.StrScriptName = "ScriptName_50";
            FrmGridDetails Objfrm = new FrmGridDetails(Dgv50_200);
            
            Objfrm.ShowDialog();
            
        }

        private void DgvAllDma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvAllEma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAllDmaPop_Click(object sender, EventArgs e)
        {
            FrmGridDetails.StrHeader = "All DMA BeakOut Scripts";
            FrmGridDetails.StrScriptIdCol = "ScriptID_All";
            FrmGridDetails.StrScriptPriceCol = "LastClosePrice";
            FrmGridDetails.StrScriptName = "ScriptName";
            FrmGridDetails Objfrm = new FrmGridDetails(DgvAllDma);
            Objfrm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnStrData_Click(object sender, EventArgs e)
        {
            if (BtnStrData.Text == "Start")
            {
                Tm_RefreshLive.Start();
                BtnStrData.Text = "Stop";
            }
            else
            {
                Tm_RefreshLive.Stop();
                BtnStrData.Text = "Start";
            }
        }

        private void CmbRefreshTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbRefreshTime.SelectedItem.ToString() == ".5")
                Tm_RefreshLive.Interval = 5000;
            else
            Tm_RefreshLive.Interval =Convert.ToInt16(CmbRefreshTime.SelectedItem.ToString())*60000;
        }

        private void BtnRemoveScript_Click(object sender, EventArgs e)
        {
            if (DgvSwing.SelectedRows.Count != 0)
            {
                var id = DgvSwing.SelectedRows[0].Cells["ID"].Value.ToString();
                if(MessageBox.Show("Do you want to delete the selected Script?","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    ClsDataBase.RemoveSwingScript(Convert.ToInt16(id));
                }
                DgvSwing.DataSource = ClsDataBase.GetSwingScriptData();
            }

        }

        private void BtnGoldenPop_Click(object sender, EventArgs e)
        {
            FrmGridDetails.StrHeader = "All Golden Cross Scripts";
            FrmGridDetails.StrScriptIdCol = "ScriptID";
            FrmGridDetails.StrScriptPriceCol="LastClosePriceG";
            FrmGridDetails.StrScriptName = "ScriptNameG";
            FrmGridDetails Objfrm = new FrmGridDetails(DgvGCross);
            Objfrm.ShowDialog();
        }

        private void TabScriptTrack_Click(object sender, EventArgs e)
        {

        }
    }
}
