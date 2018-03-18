using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeApp
{
    public partial class FrmGridDetails : Form
    {
        public static DataGridViewColumnCollection ColumnCollection;
        public static string StrHeader;
        public static string StrScriptIdCol;
        public static string StrScriptPriceCol;
        public static string StrScriptName;
        string[] ScriptData;
        public FrmGridDetails(DataGridView dgv_org)
        {
            InitializeComponent();
            CopyDataGridView(dgv_org);
            LabHeader.Text = StrHeader + ".                      Total Records: "+dgv_org.RowCount.ToString();
            DgvDetails.CellClick += DgvDetails_CellClick;
            ScriptData = new string[3];
        }

        private void DgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvDetails.Columns["BtnColAdd"].Index)
            {
                if(DgvDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Green)
                {
                    MessageBox.Show("Record Already Exist!!!");
                    return;
                }
                FrmTrackScriptDetails ObjTrack = new FrmTrackScriptDetails();
                FrmTrackScriptDetails._ScriptName = DgvDetails.Rows[e.RowIndex].Cells[StrScriptName].Value.ToString();
                FrmTrackScriptDetails._ScriptPrice= DgvDetails.Rows[e.RowIndex].Cells[StrScriptPriceCol].Value.ToString();
                ObjTrack.ShowDialog();
                //ScriptData[0] = DgvDetails.Rows[e.RowIndex].Cells[StrScriptIdCol].Value.ToString();
                //ScriptData[1] = DateTime.Now.ToShortDateString();
                //ScriptData[2]= DgvDetails.Rows[e.RowIndex].Cells[StrScriptPriceCol].Value.ToString();
                //ClsDataBase.InsertTrackScripts(ScriptData);
            } 
                
        }

        private void CopyDataGridView(DataGridView dgv_org)
        {
            try
            {
                if (DgvDetails.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        DgvDetails.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }
                DataGridViewButtonColumn NewCol = new DataGridViewButtonColumn();
                
                DgvDetails.Columns.Add(NewCol);
                NewCol.Text = "Add to Track list";
                NewCol.Name = "BtnColAdd";
                NewCol.HeaderText = "Add To List";
                NewCol.Width = 150;
                NewCol.UseColumnTextForButtonValue = true;
                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    DgvDetails.Rows.Add(row);
                    if (ClsDataBase.CheckTrackScript(row.Cells[StrScriptIdCol].Value.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                        
                    }
                }
                DgvDetails.AllowUserToAddRows = false;
                DgvDetails.Refresh();

            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("Copy DataGridViw"+ ex.Message);
            }
            
        }
    }
}
