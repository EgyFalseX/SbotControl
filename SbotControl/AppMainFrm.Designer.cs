namespace SbotControl
{
    partial class AppMainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMainFrm));
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiStart = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStop = new DevExpress.XtraBars.BarButtonItem();
            this.bsiViews = new DevExpress.XtraBars.BarSubItem();
            this.bbiAccount = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnlinebot = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBotLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOption = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOutput = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHistory = new DevExpress.XtraBars.BarButtonItem();
            this.bbiWorldMap = new DevExpress.XtraBars.BarButtonItem();
            this.bsiLayout = new DevExpress.XtraBars.BarSubItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoadLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barDockingMenuItemWindow = new DevExpress.XtraBars.BarDockingMenuItem();
            this.bsiAbout = new DevExpress.XtraBars.BarSubItem();
            this.bbiAboutMe = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingControllerMain = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManagerMain = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedViewMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.docAccount = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docOnline = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docOption = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docHistory = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docMap = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.documentGroup2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.docBotLog = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docOutput = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingControllerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBotLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOutput)).BeginInit();
            this.contextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManagerMain.Controller = this.barAndDockingControllerMain;
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.DockManager = this.dockManagerMain;
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barDockingMenuItemWindow,
            this.bbiStart,
            this.bbiStop,
            this.bsiViews,
            this.bbiAccount,
            this.bbiOnlinebot,
            this.bbiBotLog,
            this.bbiOption,
            this.bsiAbout,
            this.bbiAboutMe,
            this.bbiOutput,
            this.bbiHistory,
            this.bsiLayout,
            this.bbiSaveLayout,
            this.bbiLoadLayout,
            this.bbiWorldMap});
            this.barManagerMain.MainMenu = this.bar2;
            this.barManagerMain.MaxItemId = 16;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStart),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStop),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiViews),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDockingMenuItemWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiAbout)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiStart
            // 
            this.bbiStart.Caption = "Start";
            this.bbiStart.Glyph = global::SbotControl.Properties.Resources.media_16x16;
            this.bbiStart.Id = 1;
            this.bbiStart.LargeGlyph = global::SbotControl.Properties.Resources.media_32x32;
            this.bbiStart.Name = "bbiStart";
            this.bbiStart.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStart_ItemClick);
            // 
            // bbiStop
            // 
            this.bbiStop.Caption = "Stop";
            this.bbiStop.Enabled = false;
            this.bbiStop.Glyph = global::SbotControl.Properties.Resources.borules_16x16;
            this.bbiStop.Id = 2;
            this.bbiStop.LargeGlyph = global::SbotControl.Properties.Resources.borules_32x32;
            this.bbiStop.Name = "bbiStop";
            this.bbiStop.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStop_ItemClick);
            // 
            // bsiViews
            // 
            this.bsiViews.Caption = "Views";
            this.bsiViews.Glyph = global::SbotControl.Properties.Resources.windows_16x16;
            this.bsiViews.Id = 3;
            this.bsiViews.LargeGlyph = global::SbotControl.Properties.Resources.windows_32x32;
            this.bsiViews.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAccount),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOnlinebot),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBotLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOutput),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiHistory),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiWorldMap)});
            this.bsiViews.Name = "bsiViews";
            this.bsiViews.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiAccount
            // 
            this.bbiAccount.Caption = "Accounts";
            this.bbiAccount.Glyph = global::SbotControl.Properties.Resources.usergroup_16x16;
            this.bbiAccount.Id = 4;
            this.bbiAccount.LargeGlyph = global::SbotControl.Properties.Resources.usergroup_32x32;
            this.bbiAccount.Name = "bbiAccount";
            this.bbiAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAccount_ItemClick);
            // 
            // bbiOnlinebot
            // 
            this.bbiOnlinebot.Caption = "OnlineBots";
            this.bbiOnlinebot.Glyph = global::SbotControl.Properties.Resources.enableclustering_16x16;
            this.bbiOnlinebot.Id = 5;
            this.bbiOnlinebot.LargeGlyph = global::SbotControl.Properties.Resources.enableclustering_32x32;
            this.bbiOnlinebot.Name = "bbiOnlinebot";
            this.bbiOnlinebot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOnlinebot_ItemClick);
            // 
            // bbiBotLog
            // 
            this.bbiBotLog.Caption = "BotLogs";
            this.bbiBotLog.Glyph = global::SbotControl.Properties.Resources.pageorientation_16x16;
            this.bbiBotLog.Id = 6;
            this.bbiBotLog.LargeGlyph = global::SbotControl.Properties.Resources.pageorientation_32x32;
            this.bbiBotLog.Name = "bbiBotLog";
            this.bbiBotLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBotLog_ItemClick);
            // 
            // bbiOption
            // 
            this.bbiOption.Caption = "Options";
            this.bbiOption.Glyph = global::SbotControl.Properties.Resources.technology_16x16;
            this.bbiOption.Id = 7;
            this.bbiOption.LargeGlyph = global::SbotControl.Properties.Resources.technology_32x32;
            this.bbiOption.Name = "bbiOption";
            this.bbiOption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOption_ItemClick);
            // 
            // bbiOutput
            // 
            this.bbiOutput.Caption = "Output";
            this.bbiOutput.Glyph = global::SbotControl.Properties.Resources.bugreport_16x16;
            this.bbiOutput.Id = 10;
            this.bbiOutput.LargeGlyph = global::SbotControl.Properties.Resources.bugreport_32x32;
            this.bbiOutput.Name = "bbiOutput";
            this.bbiOutput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOutput_ItemClick);
            // 
            // bbiHistory
            // 
            this.bbiHistory.Caption = "History";
            this.bbiHistory.Glyph = global::SbotControl.Properties.Resources.historyitem_16x16;
            this.bbiHistory.Id = 11;
            this.bbiHistory.LargeGlyph = global::SbotControl.Properties.Resources.historyitem_32x32;
            this.bbiHistory.Name = "bbiHistory";
            this.bbiHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHistory_ItemClick);
            // 
            // bbiWorldMap
            // 
            this.bbiWorldMap.Caption = "WorldMap";
            this.bbiWorldMap.Glyph = global::SbotControl.Properties.Resources.shapelabels_16x16;
            this.bbiWorldMap.Id = 15;
            this.bbiWorldMap.LargeGlyph = global::SbotControl.Properties.Resources.shapelabels_32x32;
            this.bbiWorldMap.Name = "bbiWorldMap";
            this.bbiWorldMap.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiWorldMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiWorldMap_ItemClick);
            // 
            // bsiLayout
            // 
            this.bsiLayout.Caption = "Layout";
            this.bsiLayout.Glyph = global::SbotControl.Properties.Resources.initialstate_16x16;
            this.bsiLayout.Id = 12;
            this.bsiLayout.LargeGlyph = global::SbotControl.Properties.Resources.initialstate_32x32;
            this.bsiLayout.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadLayout)});
            this.bsiLayout.Name = "bsiLayout";
            this.bsiLayout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "SaveLayout";
            this.bbiSaveLayout.Glyph = global::SbotControl.Properties.Resources.apply_16x16;
            this.bbiSaveLayout.Id = 13;
            this.bbiSaveLayout.LargeGlyph = global::SbotControl.Properties.Resources.apply_32x32;
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            this.bbiSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveLayout_ItemClick);
            // 
            // bbiLoadLayout
            // 
            this.bbiLoadLayout.Caption = "LoadLayout";
            this.bbiLoadLayout.Glyph = global::SbotControl.Properties.Resources.cancel_16x16;
            this.bbiLoadLayout.Id = 14;
            this.bbiLoadLayout.LargeGlyph = global::SbotControl.Properties.Resources.cancel_32x32;
            this.bbiLoadLayout.Name = "bbiLoadLayout";
            this.bbiLoadLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoadLayout_ItemClick);
            // 
            // barDockingMenuItemWindow
            // 
            this.barDockingMenuItemWindow.Caption = "Window";
            this.barDockingMenuItemWindow.Glyph = global::SbotControl.Properties.Resources.HideAll;
            this.barDockingMenuItemWindow.Id = 0;
            this.barDockingMenuItemWindow.Name = "barDockingMenuItemWindow";
            this.barDockingMenuItemWindow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsiAbout
            // 
            this.bsiAbout.Caption = "About";
            this.bsiAbout.Glyph = global::SbotControl.Properties.Resources.logical_16x16;
            this.bsiAbout.Id = 8;
            this.bsiAbout.LargeGlyph = global::SbotControl.Properties.Resources.logical_32x32;
            this.bsiAbout.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAboutMe)});
            this.bsiAbout.Name = "bsiAbout";
            this.bsiAbout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiAboutMe
            // 
            this.bbiAboutMe.Caption = "About Me";
            this.bbiAboutMe.Glyph = global::SbotControl.Properties.Resources.borole_16x16;
            this.bbiAboutMe.Id = 9;
            this.bbiAboutMe.LargeGlyph = global::SbotControl.Properties.Resources.borole_32x32;
            this.bbiAboutMe.Name = "bbiAboutMe";
            this.bbiAboutMe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAboutMe_ItemClick);
            // 
            // barAndDockingControllerMain
            // 
            this.barAndDockingControllerMain.PaintStyleName = "Skin";
            this.barAndDockingControllerMain.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingControllerMain.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingControllerMain.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(984, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Size = new System.Drawing.Size(984, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 537);
            // 
            // dockManagerMain
            // 
            this.dockManagerMain.Form = this;
            this.dockManagerMain.LayoutVersion = "2";
            this.dockManagerMain.MenuManager = this.barManagerMain;
            this.dockManagerMain.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // documentManagerMain
            // 
            this.documentManagerMain.ContainerControl = this;
            this.documentManagerMain.View = this.tabbedViewMain;
            this.documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewMain});
            // 
            // tabbedViewMain
            // 
            this.tabbedViewMain.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1,
            this.documentGroup2});
            this.tabbedViewMain.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.docOnline,
            this.docAccount,
            this.docBotLog,
            this.docOption,
            this.docOutput,
            this.docHistory,
            this.docMap});
            this.tabbedViewMain.OptionsLayout.LayoutVersion = "2";
            this.tabbedViewMain.OptionsLayout.PropertiesRestoreMode = DevExpress.XtraBars.Docking2010.Views.PropertiesRestoreMode.All;
            this.tabbedViewMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tabbedViewMain.DocumentClosing += new DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventHandler(this.tabbedViewMain_DocumentClosing);
            this.tabbedViewMain.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.tabbedViewMain_QueryControl);
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.docAccount,
            this.docOnline,
            this.docOption,
            this.docHistory,
            this.docMap});
            // 
            // docAccount
            // 
            this.docAccount.Caption = "Accounts";
            this.docAccount.ControlName = "docAccount";
            this.docAccount.FloatLocation = new System.Drawing.Point(57, 178);
            this.docAccount.FloatSize = new System.Drawing.Size(985, 375);
            this.docAccount.Image = global::SbotControl.Properties.Resources.usergroup_16x16;
            // 
            // docOnline
            // 
            this.docOnline.Caption = "Online Bots";
            this.docOnline.ControlName = "docOnline";
            this.docOnline.Image = global::SbotControl.Properties.Resources.enableclustering_16x16;
            // 
            // docOption
            // 
            this.docOption.Caption = "Options";
            this.docOption.ControlName = "docOption";
            this.docOption.FloatLocation = new System.Drawing.Point(69, 183);
            this.docOption.FloatSize = new System.Drawing.Size(985, 170);
            this.docOption.Image = global::SbotControl.Properties.Resources.technology_16x16;
            // 
            // docHistory
            // 
            this.docHistory.Caption = "History";
            this.docHistory.ControlName = "docHistory";
            this.docHistory.Image = global::SbotControl.Properties.Resources.historyitem_16x16;
            // 
            // docMap
            // 
            this.docMap.Caption = "World Map";
            this.docMap.ControlName = "docMap";
            this.docMap.Image = global::SbotControl.Properties.Resources.shapelabels_16x16;
            // 
            // documentGroup2
            // 
            this.documentGroup2.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.docBotLog,
            this.docOutput});
            // 
            // docBotLog
            // 
            this.docBotLog.Caption = "Bot Logs";
            this.docBotLog.ControlName = "docBotLog";
            this.docBotLog.FloatLocation = new System.Drawing.Point(321, 394);
            this.docBotLog.FloatSize = new System.Drawing.Size(985, 372);
            this.docBotLog.Image = global::SbotControl.Properties.Resources.pageorientation_16x16;
            // 
            // docOutput
            // 
            this.docOutput.Caption = "Output";
            this.docOutput.ControlName = "docOutput";
            this.docOutput.FloatLocation = new System.Drawing.Point(-148, 445);
            this.docOutput.FloatSize = new System.Drawing.Size(978, 237);
            this.docOutput.Image = global::SbotControl.Properties.Resources.bugreport_16x16;
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "bot control";
            this.notifyIconApp.Visible = true;
            this.notifyIconApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconApp_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::SbotControl.Properties.Resources.Exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // AppMainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppMainFrm";
            this.Text = "Sbot Control - BETA TEST";
            this.Shown += new System.EventHandler(this.AppMainFrm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingControllerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBotLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docOutput)).EndInit();
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManagerMain;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedViewMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docAccount;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docOnline;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docOption;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItemWindow;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingControllerMain;
        private DevExpress.XtraBars.BarButtonItem bbiStart;
        private DevExpress.XtraBars.BarButtonItem bbiStop;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docBotLog;
        private DevExpress.XtraBars.BarSubItem bsiViews;
        private DevExpress.XtraBars.BarButtonItem bbiAccount;
        private DevExpress.XtraBars.BarButtonItem bbiOnlinebot;
        private DevExpress.XtraBars.BarButtonItem bbiBotLog;
        private DevExpress.XtraBars.BarButtonItem bbiOption;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup2;
        private DevExpress.XtraBars.BarSubItem bsiAbout;
        private DevExpress.XtraBars.BarButtonItem bbiAboutMe;
        private DevExpress.XtraBars.BarButtonItem bbiOutput;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docOutput;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docHistory;
        private DevExpress.XtraBars.BarButtonItem bbiHistory;
        private DevExpress.XtraBars.BarSubItem bsiLayout;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiLoadLayout;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docMap;
        private DevExpress.XtraBars.BarButtonItem bbiWorldMap;
    }
}