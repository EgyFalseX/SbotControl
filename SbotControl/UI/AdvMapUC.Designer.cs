namespace SbotControl.UI
{
    partial class AdvMapUC
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
            DevExpress.XtraMap.InformationLayer informationLayer3 = new DevExpress.XtraMap.InformationLayer();
            this.MCMain = new DevExpress.XtraMap.MapControl();
            this.popupMenuGrid = new DevExpress.XtraBars.PopupMenu();
            this.barManagerMain = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bsiSetFocus = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.MCMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            this.SuspendLayout();
            // 
            // MCMain
            // 
            this.MCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            informationLayer3.HighlightedItemStyle.TextGlowColor = System.Drawing.Color.Lime;
            informationLayer3.Name = "informationLayerChar";
            informationLayer3.SelectedItemStyle.TextGlowColor = System.Drawing.Color.Lime;
            this.MCMain.Layers.Add(informationLayer3);
            this.MCMain.Location = new System.Drawing.Point(0, 0);
            this.MCMain.MaxZoomLevel = 7D;
            this.MCMain.Name = "MCMain";
            this.MCMain.Size = new System.Drawing.Size(954, 615);
            this.MCMain.TabIndex = 0;
            this.MCMain.ZoomLevel = 3D;
            this.MCMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MCMain_MouseClick);
            // 
            // popupMenuGrid
            // 
            this.popupMenuGrid.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetFocus)});
            this.popupMenuGrid.Manager = this.barManagerMain;
            this.popupMenuGrid.Name = "popupMenuGrid";
            // 
            // barManagerMain
            // 
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bsiSetFocus});
            this.barManagerMain.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(954, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 615);
            this.barDockControlBottom.Size = new System.Drawing.Size(954, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 615);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(954, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 615);
            // 
            // bsiSetFocus
            // 
            this.bsiSetFocus.Caption = "Set Focus";
            this.bsiSetFocus.Glyph = global::SbotControl.Properties.Resources.show_16x16;
            this.bsiSetFocus.Id = 0;
            this.bsiSetFocus.LargeGlyph = global::SbotControl.Properties.Resources.show_32x32;
            this.bsiSetFocus.Name = "bsiSetFocus";
            // 
            // AdvMapUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MCMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AdvMapUC";
            this.Size = new System.Drawing.Size(954, 615);
            ((System.ComponentModel.ISupportInitialize)(this.MCMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraMap.MapControl MCMain;
        private DevExpress.XtraBars.PopupMenu popupMenuGrid;
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem bsiSetFocus;
        
    }
}
