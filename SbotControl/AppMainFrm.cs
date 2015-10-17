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
        Core.CtrLayout tabbedViewMainlayout;
        Core.CtrLayout dockManagerMainlayout;
        UI.AccountUC docAccountCtr = new UI.AccountUC();
        UI.OptionsUC docOptionCtr = new UI.OptionsUC();
        UI.OnlineBotUC docOnlineCtr = new UI.OnlineBotUC();
        UI.BotLogUC docBotLogCtr = new UI.BotLogUC();
        UI.OutputUC docOutputCtr = new UI.OutputUC();
        UI.HistoryUC docHistoryCtr = new UI.HistoryUC();
        UI.MapUC docMapCtr = new UI.MapUC();
        bool _autoStart = false;
        public AppMainFrm(bool AutoStart)
        {
            InitializeComponent();
            LayoutInti();
            //docAccount.Control = new UI.AccountUC();
            _autoStart = AutoStart;
        }
       
        private void LayoutInti()
        {
            try
            {
                //tabbedViewMain
                System.IO.MemoryStream tabbedViewMainDefaultLayout = new System.IO.MemoryStream();
                tabbedViewMain.SaveLayoutToStream(tabbedViewMainDefaultLayout);
                tabbedViewMainlayout = Program.LM.GetLayout(this.GetType().ToString() + ".tabbedViewMain", Convert.ToInt32(tabbedViewMain.OptionsLayout.LayoutVersion == null ? "1" : tabbedViewMain.OptionsLayout.LayoutVersion), tabbedViewMainDefaultLayout.ToArray());
                tabbedViewMain.RestoreLayoutFromStream(new System.IO.MemoryStream(tabbedViewMainlayout.LayoutUser));//Load Layout From File
                                                                                                                    //dockManagerMain
                System.IO.MemoryStream dockManagerMainDefaultLayout = new System.IO.MemoryStream();
                dockManagerMain.SaveLayoutToStream(dockManagerMainDefaultLayout);
                dockManagerMainlayout = Program.LM.GetLayout(this.GetType().ToString() + ".dockManagerMain", Convert.ToInt32(dockManagerMain.LayoutVersion == null ? "1" : dockManagerMain.LayoutVersion), dockManagerMainDefaultLayout.ToArray());
                dockManagerMain.RestoreLayoutFromStream(new System.IO.MemoryStream(dockManagerMainlayout.LayoutUser));//Load Layout From File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void tabbedViewMain_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            try
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
                else if (e.Document.ControlName == "docOutput")
                {
                    e.Control = docOutputCtr;
                }
                else if (e.Document.ControlName == "docHistory")
                {
                    e.Control = docHistoryCtr;
                }
                else if (e.Document.ControlName == "docMap")
                {
                    e.Control = docMapCtr;
                }
                else if (e.Document.Tag != null && e.Document.Tag.GetType() == typeof(SBot))
                {
                    e.Control = new UI.BotInfoUC((SBot)e.Document.Tag);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Program.BM.Stop();
                bbiStart.Enabled = true;
                bbiStop.Enabled = false;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void notifyIconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left)
                    return;
                this.Visible = !this.Visible;
                if (Visible)
                    this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tabbedViewMain_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            try
            {
                if (e.Document.ControlName == "docOnline")
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.Document.Control != null && !e.Document.Control.IsDisposed)
                        e.Document.Control.Dispose();
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiOnlinebot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiBotLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var doc in tabbedViewMain.Documents)
                {
                    if (doc.ControlName == "docOutput")
                        return;
                }
                DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
                nDoc.Caption = "Output";
                nDoc.ControlName = "docOutput";
                nDoc.Image = global::SbotControl.Properties.Resources.bugreport_16x16;
                docOutputCtr = new UI.OutputUC();
                tabbedViewMain.Documents.Add(nDoc);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var doc in tabbedViewMain.Documents)
                {
                    if (doc.ControlName == "docHistory")
                        return;
                }
                DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
                nDoc.Caption = "History";
                nDoc.ControlName = "docHistory";
                nDoc.Image = global::SbotControl.Properties.Resources.historyitem_16x16;
                docHistoryCtr = new UI.HistoryUC();
                tabbedViewMain.Documents.Add(nDoc);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiWorldMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var doc in tabbedViewMain.Documents)
                {
                    if (doc.ControlName == "docMap")
                        return;
                }
                DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
                nDoc.Caption = "World Map";
                nDoc.ControlName = "docMap";
                nDoc.Image = global::SbotControl.Properties.Resources.shapelabels_16x16;
                docMapCtr = new UI.MapUC();
                tabbedViewMain.Documents.Add(nDoc);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiAboutMe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("BETA TEST" + Environment.NewLine + "Programmed by: [Egy]FalseX" + Environment.NewLine + "mohamed.aly.omer@gmail.com" + Environment.NewLine + Application.ProductVersion);
            new AboutUs().ShowDialog();
        }
        private void bbiSaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //tabbedViewMain
                System.IO.MemoryStream msTab = new System.IO.MemoryStream();
                tabbedViewMain.SaveLayoutToStream(msTab); tabbedViewMainlayout.LayoutUser = msTab.ToArray();
                //dockManagerMain
                System.IO.MemoryStream msDoc = new System.IO.MemoryStream();
                dockManagerMain.SaveLayoutToStream(msDoc); dockManagerMainlayout.LayoutUser = msDoc.ToArray();

                Program.LM.SaveLayout();//Save Layout into File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiLoadLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //tabbedViewMain
                tabbedViewMain.RestoreLayoutFromStream(new System.IO.MemoryStream(tabbedViewMainlayout.LayoutDefault));
                Program.LM.SaveLayout();//Save Layout into File
                                        //dockManagerMain
                dockManagerMain.RestoreLayoutFromStream(new System.IO.MemoryStream(dockManagerMainlayout.LayoutDefault));
                Program.LM.SaveLayout();//Save Layout into File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void ShowBotDetailsTab(SBot sbot)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }

        }
        private void AppMainFrm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (_autoStart)
                {
                    bbiStart_ItemClick(bbiStart, null);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }

        
    }
}