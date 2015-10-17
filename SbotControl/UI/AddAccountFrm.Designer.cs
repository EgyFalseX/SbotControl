namespace SbotControl.UI
{
    partial class AddAccountFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountFrm));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.seConnectionTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barLayout = new DevExpress.XtraBars.Bar();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoadLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tbGroup = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.ceActive = new DevExpress.XtraEditors.CheckEdit();
            this.beBotPath = new DevExpress.XtraEditors.ButtonEdit();
            this.tbCharName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seConnectionTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBotPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCharName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.seConnectionTimeout);
            this.layoutControlMain.Controls.Add(this.tbGroup);
            this.layoutControlMain.Controls.Add(this.btnCancel);
            this.layoutControlMain.Controls.Add(this.btnSave);
            this.layoutControlMain.Controls.Add(this.ceActive);
            this.layoutControlMain.Controls.Add(this.beBotPath);
            this.layoutControlMain.Controls.Add(this.tbCharName);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.LayoutVersion = "3";
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(650, 390, 412, 473);
            this.layoutControlMain.Root = this.layoutControlGroup1;
            this.layoutControlMain.Size = new System.Drawing.Size(383, 143);
            this.layoutControlMain.TabIndex = 0;
            // 
            // seConnectionTimeout
            // 
            this.seConnectionTimeout.EditValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.seConnectionTimeout.Location = new System.Drawing.Point(260, 84);
            this.seConnectionTimeout.MenuManager = this.barManagerMain;
            this.seConnectionTimeout.Name = "seConnectionTimeout";
            this.seConnectionTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seConnectionTimeout.Properties.MaxValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.seConnectionTimeout.Properties.MinValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.seConnectionTimeout.Size = new System.Drawing.Size(111, 20);
            this.seConnectionTimeout.StyleController = this.layoutControlMain;
            this.seConnectionTimeout.TabIndex = 10;
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barLayout});
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiSaveLayout,
            this.bbiLoadLayout});
            this.barManagerMain.MainMenu = this.barLayout;
            this.barManagerMain.MaxItemId = 4;
            // 
            // barLayout
            // 
            this.barLayout.BarName = "Main menu";
            this.barLayout.DockCol = 0;
            this.barLayout.DockRow = 0;
            this.barLayout.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
            this.barLayout.FloatLocation = new System.Drawing.Point(459, 228);
            this.barLayout.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadLayout)});
            this.barLayout.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.All;
            this.barLayout.OptionsBar.UseWholeRow = true;
            this.barLayout.Text = "Main menu";
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "Save Layout";
            this.bbiSaveLayout.Glyph = global::SbotControl.Properties.Resources.apply_16x16;
            this.bbiSaveLayout.Id = 0;
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            this.bbiSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveLayout_ItemClick);
            // 
            // bbiLoadLayout
            // 
            this.bbiLoadLayout.Caption = "Load Layout";
            this.bbiLoadLayout.Glyph = global::SbotControl.Properties.Resources.cancel_16x16;
            this.bbiLoadLayout.Id = 1;
            this.bbiLoadLayout.Name = "bbiLoadLayout";
            this.bbiLoadLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoadLayout_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(417, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 143);
            this.barDockControlBottom.Size = new System.Drawing.Size(417, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 143);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(383, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(34, 143);
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(135, 60);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(236, 20);
            this.tbGroup.StyleController = this.layoutControlMain;
            this.tbGroup.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::SbotControl.Properties.Resources.Delete;
            this.btnCancel.Location = new System.Drawing.Point(287, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.StyleController = this.layoutControlMain;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SbotControl.Properties.Resources.Edit;
            this.btnSave.Location = new System.Drawing.Point(12, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(271, 22);
            this.btnSave.StyleController = this.layoutControlMain;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ceActive
            // 
            this.ceActive.Location = new System.Drawing.Point(12, 84);
            this.ceActive.Name = "ceActive";
            this.ceActive.Properties.Caption = "Active";
            this.ceActive.Size = new System.Drawing.Size(121, 19);
            this.ceActive.StyleController = this.layoutControlMain;
            this.ceActive.TabIndex = 6;
            // 
            // beBotPath
            // 
            this.beBotPath.Location = new System.Drawing.Point(135, 36);
            this.beBotPath.Name = "beBotPath";
            this.beBotPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBotPath.Size = new System.Drawing.Size(236, 20);
            this.beBotPath.StyleController = this.layoutControlMain;
            this.beBotPath.TabIndex = 5;
            this.beBotPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beBotPath_ButtonClick);
            // 
            // tbCharName
            // 
            this.tbCharName.Location = new System.Drawing.Point(135, 12);
            this.tbCharName.Name = "tbCharName";
            this.tbCharName.Size = new System.Drawing.Size(236, 20);
            this.tbCharName.StyleController = this.layoutControlMain;
            this.tbCharName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(383, 143);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tbCharName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(363, 24);
            this.layoutControlItem1.Text = "Char Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(120, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.beBotPath;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(363, 24);
            this.layoutControlItem2.Text = "Bot Path";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(120, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceActive;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(125, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSave;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(275, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(275, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(88, 27);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.tbGroup;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(363, 24);
            this.layoutControlItem6.Text = "Group";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(120, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.seConnectionTimeout;
            this.layoutControlItem7.Location = new System.Drawing.Point(125, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(238, 24);
            this.layoutControlItem7.Text = "Connection timeout (sec)";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(120, 13);
            // 
            // ofd
            // 
            this.ofd.Filter = "sbot2*.exe|*.exe";
            // 
            // AddAccountFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 143);
            this.Controls.Add(this.layoutControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAccountFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Account";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seConnectionTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBotPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCharName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckEdit ceActive;
        private DevExpress.XtraEditors.ButtonEdit beBotPath;
        private DevExpress.XtraEditors.TextEdit tbCharName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.OpenFileDialog ofd;
        private DevExpress.XtraEditors.TextEdit tbGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barLayout;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiLoadLayout;
        private DevExpress.XtraEditors.SpinEdit seConnectionTimeout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}