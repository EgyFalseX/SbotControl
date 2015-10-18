namespace SbotControl.UI
{
    partial class OptionsUC
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ceAlert_Died = new DevExpress.XtraEditors.CheckEdit();
            this.ceAlert_Connect_Disconnect = new DevExpress.XtraEditors.CheckEdit();
            this.galleryControlMain = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.ceRunAtStartup = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceAlert_Died.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAlert_Connect_Disconnect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlMain)).BeginInit();
            this.galleryControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceRunAtStartup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ceAlert_Died);
            this.layoutControl1.Controls.Add(this.ceAlert_Connect_Disconnect);
            this.layoutControl1.Controls.Add(this.galleryControlMain);
            this.layoutControl1.Controls.Add(this.ceRunAtStartup);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(654, 390, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(581, 306);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ceAlert_Died
            // 
            this.ceAlert_Died.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", global::SbotControl.Properties.Settings.Default, "Alert_Died", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ceAlert_Died.EditValue = global::SbotControl.Properties.Settings.Default.Alert_Died;
            this.ceAlert_Died.Location = new System.Drawing.Point(24, 263);
            this.ceAlert_Died.Name = "ceAlert_Died";
            this.ceAlert_Died.Properties.Caption = "Alert Died";
            this.ceAlert_Died.Size = new System.Drawing.Size(533, 19);
            this.ceAlert_Died.StyleController = this.layoutControl1;
            this.ceAlert_Died.TabIndex = 6;
            this.ceAlert_Died.CheckedChanged += new System.EventHandler(this.ceAlert_Died_CheckedChanged);
            // 
            // ceAlert_Connect_Disconnect
            // 
            this.ceAlert_Connect_Disconnect.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", global::SbotControl.Properties.Settings.Default, "Alert_Connect_Disconnect", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ceAlert_Connect_Disconnect.EditValue = global::SbotControl.Properties.Settings.Default.Alert_Connect_Disconnect;
            this.ceAlert_Connect_Disconnect.Location = new System.Drawing.Point(24, 240);
            this.ceAlert_Connect_Disconnect.Name = "ceAlert_Connect_Disconnect";
            this.ceAlert_Connect_Disconnect.Properties.Caption = "Alert Connect/Disconnect";
            this.ceAlert_Connect_Disconnect.Size = new System.Drawing.Size(533, 19);
            this.ceAlert_Connect_Disconnect.StyleController = this.layoutControl1;
            this.ceAlert_Connect_Disconnect.TabIndex = 5;
            this.ceAlert_Connect_Disconnect.CheckedChanged += new System.EventHandler(this.ceAlert_Connect_Disconnect_CheckedChanged);
            // 
            // galleryControlMain
            // 
            this.galleryControlMain.Controls.Add(this.galleryControlClient1);
            this.galleryControlMain.DesignGalleryGroupIndex = 0;
            this.galleryControlMain.DesignGalleryItemIndex = 0;
            // 
            // 
            // 
            this.galleryControlMain.Gallery.ShowItemText = true;
            this.galleryControlMain.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlMain_Gallery_ItemClick);
            this.galleryControlMain.Location = new System.Drawing.Point(12, 35);
            this.galleryControlMain.Name = "galleryControlMain";
            this.galleryControlMain.Size = new System.Drawing.Size(557, 171);
            this.galleryControlMain.StyleController = this.layoutControl1;
            this.galleryControlMain.TabIndex = 0;
            this.galleryControlMain.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControlMain;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(536, 167);
            // 
            // ceRunAtStartup
            // 
            this.ceRunAtStartup.Location = new System.Drawing.Point(12, 12);
            this.ceRunAtStartup.Name = "ceRunAtStartup";
            this.ceRunAtStartup.Properties.Caption = "Start with windows [Automation]";
            this.ceRunAtStartup.Size = new System.Drawing.Size(557, 19);
            this.ceRunAtStartup.StyleController = this.layoutControl1;
            this.ceRunAtStartup.TabIndex = 4;
            this.ceRunAtStartup.CheckedChanged += new System.EventHandler(this.ceRunAtStartup_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(581, 306);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ceRunAtStartup;
            this.layoutControlItem1.CustomizationFormText = "ceRunAtStartup";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(561, 23);
            this.layoutControlItem1.Text = "ceRunAtStartup";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.galleryControlMain;
            this.layoutControlItem2.CustomizationFormText = "Themes";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(561, 175);
            this.layoutControlItem2.Text = "Themes";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceAlert_Connect_Disconnect;
            this.layoutControlItem3.CustomizationFormText = "ceAlert_Connect_Disconnect";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(537, 23);
            this.layoutControlItem3.Text = "ceAlert_Connect_Disconnect";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ceAlert_Died;
            this.layoutControlItem4.CustomizationFormText = "ceAlert_Died";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(537, 23);
            this.layoutControlItem4.Text = "ceAlert_Died";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Alert";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 198);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(561, 88);
            this.layoutControlGroup2.Text = "Alert";
            // 
            // OptionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "OptionsUC";
            this.Size = new System.Drawing.Size(581, 306);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceAlert_Died.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAlert_Connect_Disconnect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlMain)).EndInit();
            this.galleryControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceRunAtStartup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckEdit ceRunAtStartup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControlMain;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit ceAlert_Died;
        private DevExpress.XtraEditors.CheckEdit ceAlert_Connect_Disconnect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
    }
}
