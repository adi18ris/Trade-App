using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace TradeApp
{
    public partial class FrmScriptSelection : Form
    {

        Collection<ClsScriptsMaster> ColScript = new Collection<ClsScriptsMaster>();
        string[] Data = new string[5];
        string ScriptId;
        int SwingMargin;
        public FrmScriptSelection()
        {
            InitializeComponent();
            DgvScriptName.AutoGenerateColumns = false;
            TxtLowerLimit.Maximum = 100000;
            TxtUpperLimit.Maximum = 100000;
            ColScript = ClsDataBase.GetScriptsCode(false);
            DgvScriptName.DataSource =ColScript;
            SwingMargin = Convert.ToInt16(ClsDataBase.GetConfigValue("SwingMargin"));
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (TxtSearch.Text.Length >= 3)
            {
                //var Item = ColScript.Where(Script => Script.ScriptsName.Contains(TxtSearch.Text,StringComparison.OrdinalIgnoreCase));
                DgvScriptName.DataSource = ColScript.Where(Script => Script.ScriptsName.Contains(TxtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();

            }
            else
                DgvScriptName.DataSource = ColScript;
        }

        private void DgvScriptName_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvScriptName.SelectedRows.Count > 0)
            {
                LabSelScript.Text = DgvScriptName.SelectedRows[0].Cells["ScriptNameSearch"].Value.ToString();
                ScriptId= DgvScriptName.SelectedRows[0].Cells["ID"].Value.ToString();
                var item= ClsDataBase.GetSwingScriptById(ScriptId);
                if(item!=null && item.Length>0)
                {
                    TxtUpperLimit.Value = Convert.ToDecimal(item[0]);
                    TxtLowerLimit.Value = Convert.ToDecimal(item[1]);
                    txtComment.Text =item[2];
                    BtnAddScript.Text = "Update Script";
                }
                else
                {
                    TxtUpperLimit.Value =0;
                    TxtLowerLimit.Value = 0;
                    txtComment.Text = "";
                    BtnAddScript.Text = "Add Script";
                }
            }
        }

        private void TxtUpperLimit_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddScript_Click(object sender, EventArgs e)
        {
            bool Result;
            if ((TxtUpperLimit.Value > 0 && TxtLowerLimit.Value > 0) && (TxtUpperLimit.Value > TxtLowerLimit.Value))
            {
                Data[0] = ScriptId;
                Data[1] = TxtUpperLimit.Value.ToString();
                Data[2] = TxtLowerLimit.Value.ToString();
                Data[3] = txtComment.Text;
                Data[4] = ((TxtLowerLimit.Value * SwingMargin) / 100).ToString();
                if (BtnAddScript.Text == "Update Script")
                    Result = ClsDataBase.InsertSwingScripts(Data, true);
                else
                    Result = ClsDataBase.InsertSwingScripts(Data, false);

                if (Result)
                {
                    LBoxScripts.Items.Add(LabSelScript.Text);
                    TxtLowerLimit.Value = 0;
                    TxtUpperLimit.Value = 0;
                    txtComment.Text = "";
                }
                else
                {
                    MessageBox.Show("Issue saving data!!");
                }
            }
            else
            {
                MessageBox.Show("Please check the values...");
            }
        }

        private void FrmScriptSelection_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
