using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl.UI
{
    public partial class OutputUC : DevExpress.XtraEditors.XtraUserControl
    {
        public OutputUC()
        {
            InitializeComponent();
            this.Disposed += OutputUC_Disposed;
            Program.Logger.AddUI(rtbLogs, Log.LogLevel.Debug);
        }
        private void OutputUC_Disposed(object sender, EventArgs e)
        {
            Program.Logger.RemoveUI(rtbLogs, Log.LogLevel.Debug);
        }
    }
}
