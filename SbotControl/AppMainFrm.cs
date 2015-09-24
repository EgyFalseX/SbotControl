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
        UI.AccountUC docAccountCtr = new UI.AccountUC();
        UI.OptionsUC docOptionCtr = new UI.OptionsUC();
        UI.OnlineBotUC docOnlineCtr = new UI.OnlineBotUC();
        UI.BotLogUC docBotLogCtr = new UI.BotLogUC();
        public AppMainFrm()
        {
            InitializeComponent();

            //docAccount.Control = new UI.AccountUC();
        }

        private void tabbedViewMain_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control != null)
                return;
            if (e.Document.ControlName == "docAccount")
            {
                e.Control = docAccountCtr;
            }
            else if (e.Document.ControlName == "docOption")
            {
                e.Control = docOptionCtr;
            }
            else if (e.Document.ControlName == "docOnline")
            {
                e.Control = docOnlineCtr;
            }
            else if (e.Document.ControlName == "docBotLog")
            {
                e.Control = docBotLogCtr;
            }
            else if (e.Document.Tag != null && e.Document.Tag.GetType() == typeof(SBot))
            {
                e.Control = new UI.BotInfoUC((SBot)e.Document.Tag);
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
        private void tabbedViewMain_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            if (e.Document.ControlName == "docOnline")
            {
                e.Cancel = true;
            }
        }
        private void bbiAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var doc in tabbedViewMain.Documents)
            {
                if (doc.ControlName == "docAccount")
                    return;
            }
            DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            nDoc.Caption = "Accounts";
            nDoc.ControlName = "docAccount";
            nDoc.FloatLocation = new System.Drawing.Point(57, 178);
            nDoc.FloatSize = new System.Drawing.Size(985, 375);
            nDoc.Image = global::SbotControl.Properties.Resources.usergroup_16x16;
            docAccountCtr = new UI.AccountUC();
            tabbedViewMain.Documents.Add(nDoc);
        }
        private void bbiOnlinebot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var doc in tabbedViewMain.Documents)
            {
                if (doc.ControlName == "docOnline")
                    return;
            }
            DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            nDoc.Caption = "Online Bots";
            nDoc.ControlName = "docOnline";
            nDoc.Image = global::SbotControl.Properties.Resources.enableclustering_16x16;
            docOnlineCtr = new UI.OnlineBotUC();
            tabbedViewMain.Documents.Add(nDoc);
        }
        private void bbiBotLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var doc in tabbedViewMain.Documents)
            {
                if (doc.ControlName == "docBotLog")
                    return;
            }
            DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            nDoc.Caption = "Bot Logs";
            nDoc.ControlName = "docBotLog";
            nDoc.Image = global::SbotControl.Properties.Resources.pageorientation_16x16;
            docBotLogCtr = new UI.BotLogUC();
            tabbedViewMain.Documents.Add(nDoc);
        }
        private void bbiOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var doc in tabbedViewMain.Documents)
            {
                if (doc.ControlName == "docOption")
                    return;
            }
            DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            nDoc.Caption = "Options";
            nDoc.ControlName = "docOption";
            nDoc.Image = global::SbotControl.Properties.Resources.technology_16x16;
            docOptionCtr = new UI.OptionsUC();
            tabbedViewMain.Documents.Add(nDoc);
        }
        public void ShowBotDetailsTab(SBot sbot)
        {
            foreach (var doc in tabbedViewMain.Documents)
            {
                if (doc.ControlName == "docBot" + sbot.CharName)
                {
                    tabbedViewMain.ActivateDocument(doc.Control);
                    return;
                }
            }
            this.Invoke(new MethodInvoker(() => 
            {
                DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
                nDoc.Caption = sbot.CharName;
                nDoc.ControlName = "docBot" + sbot.CharName;
                nDoc.Tag = sbot;
                //nDoc.Image = global::SbotControl.Properties.Resources.usergroup_16x16;
                tabbedViewMain.Documents.Add(nDoc);
                tabbedViewMain.ActivateDocument(nDoc.Control);
            }));
            
        }
    }
}