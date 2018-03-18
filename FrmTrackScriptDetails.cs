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
    public partial class FrmTrackScriptDetails : Form
    {
        public FrmTrackScriptDetails()
        {
            InitializeComponent();
        }
        public static string _ScriptName;
        public static string _ScriptPrice;
        private void FrmTrackScriptDetails_Load(object sender, EventArgs e)
        {
            LabScriptName.Text = "Script Name:"+_ScriptName+". Current Price:"+_ScriptPrice;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
