namespace SbotControl.UI
{
    partial class WaitWindowFrm
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
            this.proPnl = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // proPnl
            // 
            this.proPnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.proPnl.Appearance.Options.UseBackColor = true;
            this.proPnl.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.proPnl.AppearanceCaption.Options.UseFont = true;
            this.proPnl.AppearanceCaption.Options.UseTextOptions = true;
            this.proPnl.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.proPnl.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.proPnl.AppearanceDescription.Options.UseFont = true;
            this.proPnl.AppearanceDescription.Options.UseTextOptions = true;
            this.proPnl.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.proPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proPnl.ImageHorzOffset = 20;
            this.proPnl.Location = new System.Drawing.Point(0, 17);
            this.proPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.proPnl.Name = "proPnl";
            this.proPnl.Size = new System.Drawing.Size(246, 39);
            this.proPnl.TabIndex = 0;
            this.proPnl.Text = "Please wait";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.proPnl, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(0, 14, 0, 14);
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(246, 73);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // WaitWindowFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(246, 73);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.Name = "WaitWindowFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wait Please";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel proPnl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    }
}
