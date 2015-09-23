using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl
{
    public partial class AppMainFrm : DevExpress.XtraEditors.XtraForm
    {
        public AppMainFrm()
        {
            InitializeComponent();
        }

        private void tabbedViewMain_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control != null)
                return;
            if (e.Document == docAccount)
            {
                e.Control = new UI.AccountUC();
            }
            else if (e.Document == docOption)
            {
                e.Control = new UI.OptionsUC();
            }
            else if (e.Document == docOnline)
            {
                e.Control = new UI.OnlineBotUC();
            }
        }
        private void bbiStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MethodInvoker action = new MethodInvoker(() =>
            {
                bbiStart.Enabled = false;
                bbiStop.Enabled = true;
                if (Program.BM.Bots.Count == 0)
                    Program.BM.Start(false);
                else
                    Program.BM.Start(true);
            });
            this.Invoke(action);
        }
        private void bbiStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.BM.Stop();
            bbiStart.Enabled = true;
            bbiStop.Enabled = false;
        }
        private void notifyIconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            this.Visible = !this.Visible;
            if (Visible)
                this.WindowState = FormWindowState.Normal;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}