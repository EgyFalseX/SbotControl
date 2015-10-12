namespace SbotControl.UI
{
    partial class MapUC
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
            this.pe = new DevExpress.XtraEditors.PictureEdit();
            this.peCharName = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCharName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pe
            // 
            this.pe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pe.Location = new System.Drawing.Point(0, 0);
            this.pe.Name = "pe";
            this.pe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pe.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pe.Size = new System.Drawing.Size(974, 594);
            this.pe.TabIndex = 0;
            // 
            // peCharName
            // 
            this.peCharName.EditValue = global::SbotControl.Properties.Resources.geopoint_16x16;
            this.peCharName.Location = new System.Drawing.Point(414, 120);
            this.peCharName.Name = "peCharName";
            this.peCharName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peCharName.Properties.ShowMenu = false;
            this.peCharName.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peCharName.Size = new System.Drawing.Size(16, 16);
            this.peCharName.TabIndex = 1;
            // 
            // MapUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peCharName);
            this.Controls.Add(this.pe);
            this.Name = "MapUC";
            this.Size = new System.Drawing.Size(974, 594);
            ((System.ComponentModel.ISupportInitialize)(this.pe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCharName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pe;
        private DevExpress.XtraEditors.PictureEdit peCharName;
    }
}
