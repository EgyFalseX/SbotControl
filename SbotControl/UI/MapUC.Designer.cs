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
            ((System.ComponentModel.ISupportInitialize)(this.pe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pe
            // 
            this.pe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pe.Location = new System.Drawing.Point(0, 0);
            this.pe.Name = "pe";
            this.pe.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pe.Properties.Appearance.Options.UseBackColor = true;
            this.pe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pe.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pe.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pe.Properties.ShowMenu = false;
            this.pe.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pe.Size = new System.Drawing.Size(974, 594);
            this.pe.TabIndex = 0;
            // 
            // MapUC
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pe);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "MapUC";
            this.Size = new System.Drawing.Size(974, 594);
            ((System.ComponentModel.ISupportInitialize)(this.pe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pe;
    }
}
