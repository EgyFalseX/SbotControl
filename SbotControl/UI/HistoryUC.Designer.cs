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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barHistory = new DevExpress.XtraBars.Bar();
            this.bsiExportMenu = new DevExpress.XtraBars.BarSubItem();
            this.bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportCSV = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPDF = new DevExpress.XtraBars.BarButtonItem();
            this.gridControlHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).BeginInit();
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
            this.bbiExportPDF});
            this.barManagerHistory.MainMenu = this.barHistory;
            this.barManagerHistory.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(832, 22);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 524);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(832, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 524);
            // 
            // barHistory
            // 
            this.barHistory.BarName = "Main menu";
            this.barHistory.DockCol = 0;
            this.barHistory.DockRow = 0;
            this.barHistory.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barHistory.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiExportMenu)});
            this.barHistory.OptionsBar.MultiLine = true;
            this.barHistory.OptionsBar.UseWholeRow = true;
            this.barHistory.Text = "Main menu";
            // 
            // bsiExportMenu
            // 
            this.bsiExportMenu.Caption = "barSubItem1";
            this.bsiExportMenu.Id = 0;
            this.bsiExportMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPDF)});
            this.bsiExportMenu.Name = "bsiExportMenu";
            // 
            // bbiExportExcel
            // 
            this.bbiExportExcel.Caption = "Excel";
            this.bbiExportExcel.Id = 1;
            this.bbiExportExcel.Name = "bbiExportExcel";
            // 
            // bbiExportCSV
            // 
            this.bbiExportCSV.Caption = "CSV";
            this.bbiExportCSV.Id = 2;
            this.bbiExportCSV.Name = "bbiExportCSV";
            // 
            // bbiExportPDF
            // 
            this.bbiExportPDF.Caption = "PDF";
            this.bbiExportPDF.Id = 3;
            this.bbiExportPDF.Name = "bbiExportPDF";
            // 
            // gridControlHistory
            // 
            this.gridControlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHistory.Location = new System.Drawing.Point(0, 22);
            this.gridControlHistory.MainView = this.gridViewHistory;
            this.gridControlHistory.MenuManager = this.barManagerHistory;
            this.gridControlHistory.Name = "gridControlHistory";
            this.gridControlHistory.Size = new System.Drawing.Size(832, 524);
            this.gridControlHistory.TabIndex = 4;
            this.gridControlHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHistory});
            // 
            // gridViewHistory
            // 
            this.gridViewHistory.GridControl = this.gridControlHistory;
            this.gridViewHistory.Name = "gridViewHistory";
            this.gridViewHistory.OptionsView.ShowFooter = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).EndInit();
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
    }
}
