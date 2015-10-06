namespace SbotControl.UI
{
    partial class HistoryUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManagerHistory = new DevExpress.XtraBars.BarManager(this.components);
            this.barHistory = new DevExpress.XtraBars.Bar();
            this.bsiExportMenu = new DevExpress.XtraBars.BarSubItem();
            this.bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportCSV = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPDF = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportText = new DevExpress.XtraBars.BarButtonItem();
            this.btsiAutoRefresh = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlHistory = new DevExpress.XtraGrid.GridControl();
            this.XPSCSData = new DevExpress.Xpo.XPServerCollectionSource(this.components);
            this.sessionData = new DevExpress.Xpo.Session(this.components);
            this.gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.collog_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collog_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEditTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.collog_CharName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collog_Details = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RTSData = new DevExpress.Data.RealTimeSource();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPSCSData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditTime)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerHistory
            // 
            this.barManagerHistory.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barHistory});
            this.barManagerHistory.DockControls.Add(this.barDockControlTop);
            this.barManagerHistory.DockControls.Add(this.barDockControlBottom);
            this.barManagerHistory.DockControls.Add(this.barDockControlLeft);
            this.barManagerHistory.DockControls.Add(this.barDockControlRight);
            this.barManagerHistory.Form = this;
            this.barManagerHistory.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bsiExportMenu,
            this.bbiExportExcel,
            this.bbiExportCSV,
            this.bbiExportPDF,
            this.bbiExportText,
            this.btsiAutoRefresh});
            this.barManagerHistory.MainMenu = this.barHistory;
            this.barManagerHistory.MaxItemId = 6;
            // 
            // barHistory
            // 
            this.barHistory.BarName = "Main menu";
            this.barHistory.DockCol = 0;
            this.barHistory.DockRow = 0;
            this.barHistory.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barHistory.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiExportMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsiAutoRefresh)});
            this.barHistory.OptionsBar.MultiLine = true;
            this.barHistory.OptionsBar.UseWholeRow = true;
            this.barHistory.Text = "Main menu";
            // 
            // bsiExportMenu
            // 
            this.bsiExportMenu.Caption = "Export";
            this.bsiExportMenu.Glyph = global::SbotControl.Properties.Resources.export_16x16;
            this.bsiExportMenu.Id = 0;
            this.bsiExportMenu.LargeGlyph = global::SbotControl.Properties.Resources.export_32x32;
            this.bsiExportMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportText)});
            this.bsiExportMenu.Name = "bsiExportMenu";
            this.bsiExportMenu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiExportExcel
            // 
            this.bbiExportExcel.Caption = "Excel";
            this.bbiExportExcel.Glyph = global::SbotControl.Properties.Resources.exporttoxlsx_16x16;
            this.bbiExportExcel.Id = 1;
            this.bbiExportExcel.LargeGlyph = global::SbotControl.Properties.Resources.exporttoxlsx_32x32;
            this.bbiExportExcel.Name = "bbiExportExcel";
            this.bbiExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportExcel_ItemClick);
            // 
            // bbiExportCSV
            // 
            this.bbiExportCSV.Caption = "CSV";
            this.bbiExportCSV.Glyph = global::SbotControl.Properties.Resources.exporttocsv_16x16;
            this.bbiExportCSV.Id = 2;
            this.bbiExportCSV.LargeGlyph = global::SbotControl.Properties.Resources.exporttocsv_32x32;
            this.bbiExportCSV.Name = "bbiExportCSV";
            this.bbiExportCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportCSV_ItemClick);
            // 
            // bbiExportPDF
            // 
            this.bbiExportPDF.Caption = "PDF";
            this.bbiExportPDF.Glyph = global::SbotControl.Properties.Resources.exporttopdf_16x16;
            this.bbiExportPDF.Id = 3;
            this.bbiExportPDF.LargeGlyph = global::SbotControl.Properties.Resources.exporttopdf_32x32;
            this.bbiExportPDF.Name = "bbiExportPDF";
            this.bbiExportPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportPDF_ItemClick);
            // 
            // bbiExportText
            // 
            this.bbiExportText.Caption = "Text";
            this.bbiExportText.Glyph = global::SbotControl.Properties.Resources.exporttotxt_16x16;
            this.bbiExportText.Id = 4;
            this.bbiExportText.LargeGlyph = global::SbotControl.Properties.Resources.exporttotxt_32x32;
            this.bbiExportText.Name = "bbiExportText";
            this.bbiExportText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportText_ItemClick);
            // 
            // btsiAutoRefresh
            // 
            this.btsiAutoRefresh.BindableChecked = true;
            this.btsiAutoRefresh.Caption = "Auto Refresh";
            this.btsiAutoRefresh.Checked = true;
            this.btsiAutoRefresh.Id = 5;
            this.btsiAutoRefresh.Name = "btsiAutoRefresh";
            this.btsiAutoRefresh.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btsiAutoRefresh_CheckedChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(832, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Size = new System.Drawing.Size(832, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 522);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(832, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 522);
            // 
            // gridControlHistory
            // 
            this.gridControlHistory.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridControlHistory.DataSource = this.XPSCSData;
            this.gridControlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHistory.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlHistory.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlHistory.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlHistory.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlHistory.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlHistory.Location = new System.Drawing.Point(0, 24);
            this.gridControlHistory.MainView = this.gridViewHistory;
            this.gridControlHistory.MenuManager = this.barManagerHistory;
            this.gridControlHistory.Name = "gridControlHistory";
            this.gridControlHistory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEditDate,
            this.repositoryItemTimeEditTime});
            this.gridControlHistory.Size = new System.Drawing.Size(832, 522);
            this.gridControlHistory.TabIndex = 4;
            this.gridControlHistory.UseEmbeddedNavigator = true;
            this.gridControlHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHistory});
            // 
            // XPSCSData
            // 
            this.XPSCSData.ObjectType = typeof(SbotControl.Datasource.dsData.BotLogDataTable);
            this.XPSCSData.Session = this.sessionData;
            // 
            // sessionData
            // 
            this.sessionData.IsObjectModifiedOnNonPersistentPropertyChange = null;
            this.sessionData.TrackPropertiesModifications = false;
            // 
            // gridViewHistory
            // 
            this.gridViewHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.collog_Type,
            this.collog_Date,
            this.colTime,
            this.collog_CharName,
            this.collog_Details});
            this.gridViewHistory.GridControl = this.gridControlHistory;
            this.gridViewHistory.Name = "gridViewHistory";
            this.gridViewHistory.OptionsBehavior.Editable = false;
            this.gridViewHistory.OptionsView.ColumnAutoWidth = false;
            this.gridViewHistory.OptionsView.ShowAutoFilterRow = true;
            this.gridViewHistory.OptionsView.ShowFooter = true;
            // 
            // collog_Type
            // 
            this.collog_Type.AppearanceCell.Options.UseTextOptions = true;
            this.collog_Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_Type.AppearanceHeader.Options.UseTextOptions = true;
            this.collog_Type.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_Type.Caption = "Type";
            this.collog_Type.FieldName = "log_Type";
            this.collog_Type.Name = "collog_Type";
            this.collog_Type.Visible = true;
            this.collog_Type.VisibleIndex = 0;
            this.collog_Type.Width = 83;
            // 
            // collog_Date
            // 
            this.collog_Date.AppearanceCell.Options.UseTextOptions = true;
            this.collog_Date.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_Date.AppearanceHeader.Options.UseTextOptions = true;
            this.collog_Date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_Date.Caption = "Date";
            this.collog_Date.ColumnEdit = this.repositoryItemDateEditDate;
            this.collog_Date.FieldName = "log_Date";
            this.collog_Date.Name = "collog_Date";
            this.collog_Date.Visible = true;
            this.collog_Date.VisibleIndex = 1;
            this.collog_Date.Width = 129;
            // 
            // repositoryItemDateEditDate
            // 
            this.repositoryItemDateEditDate.AutoHeight = false;
            this.repositoryItemDateEditDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditDate.Name = "repositoryItemDateEditDate";
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.ColumnEdit = this.repositoryItemTimeEditTime;
            this.colTime.FieldName = "log_Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 2;
            // 
            // repositoryItemTimeEditTime
            // 
            this.repositoryItemTimeEditTime.AutoHeight = false;
            this.repositoryItemTimeEditTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEditTime.Name = "repositoryItemTimeEditTime";
            // 
            // collog_CharName
            // 
            this.collog_CharName.AppearanceCell.Options.UseTextOptions = true;
            this.collog_CharName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_CharName.AppearanceHeader.Options.UseTextOptions = true;
            this.collog_CharName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_CharName.Caption = "Char Name";
            this.collog_CharName.FieldName = "log_CharName";
            this.collog_CharName.Name = "collog_CharName";
            this.collog_CharName.Visible = true;
            this.collog_CharName.VisibleIndex = 3;
            this.collog_CharName.Width = 106;
            // 
            // collog_Details
            // 
            this.collog_Details.AppearanceHeader.Options.UseTextOptions = true;
            this.collog_Details.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.collog_Details.Caption = "Log";
            this.collog_Details.FieldName = "log_Details";
            this.collog_Details.Name = "collog_Details";
            this.collog_Details.Visible = true;
            this.collog_Details.VisibleIndex = 4;
            this.collog_Details.Width = 484;
            // 
            // RTSData
            // 
            this.RTSData.DisplayableProperties = null;
            this.RTSData.UseWeakEventHandler = true;
            // 
            // HistoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlHistory);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "HistoryUC";
            this.Size = new System.Drawing.Size(832, 546);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPSCSData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerHistory;
        private DevExpress.XtraBars.Bar barHistory;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem bsiExportMenu;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiExportCSV;
        private DevExpress.XtraBars.BarButtonItem bbiExportPDF;
        private DevExpress.XtraGrid.GridControl gridControlHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
        private DevExpress.Data.RealTimeSource RTSData;
        private DevExpress.Xpo.XPServerCollectionSource XPSCSData;
        private DevExpress.Xpo.Session sessionData;
        private DevExpress.XtraGrid.Columns.GridColumn collog_Type;
        private DevExpress.XtraGrid.Columns.GridColumn collog_Date;
        private DevExpress.XtraGrid.Columns.GridColumn collog_CharName;
        private DevExpress.XtraGrid.Columns.GridColumn collog_Details;
        private System.Windows.Forms.SaveFileDialog sfd;
        private DevExpress.XtraBars.BarButtonItem bbiExportText;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEditTime;
        private DevExpress.XtraBars.BarToggleSwitchItem btsiAutoRefresh;
    }
}
