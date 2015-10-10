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
            try
            {
                this.Disposed += OutputUC_Disposed;
                Program.Logger.AddUI(rtbLogs, Log.LogLevel.Debug);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void OutputUC_Disposed(object sender, EventArgs e)
        {
            try
            {
                Program.Logger.RemoveUI(rtbLogs, Log.LogLevel.Debug);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
    }
}
