using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl.UI
{
    public partial class AddAccountFrm : DevExpress.XtraEditors.XtraForm
    {
        Core.CtrLayout layout;
        string _src_charname;
        bool _src_active;
        string _src_group;
        string _src_botpath;
        SbotControl.Account _account;
        public AddAccountFrm(SbotControl.Account account)
        {
            InitializeComponent();

            _account = account;
            _src_charname= _account.charName;
            _src_active = _account.Start;
            _src_group = _account.Group;
            _src_botpath = _account.BotFilePath;

            tbCharName.DataBindings.Add("EditValue", _account, "CharName");
            beBotPath.DataBindings.Add("EditValue", _account, "BotFilePath");
            tbGroup.DataBindings.Add("EditValue", _account, "Group");
            ceActive.DataBindings.Add("EditValue", _account, "Start");
            LayoutInti();
        }
        private void LayoutInti()
        {
            System.IO.MemoryStream DefaultLayout = new System.IO.MemoryStream();
            layoutControlMain.SaveLayoutToStream(DefaultLayout);
            layout = Program.LM.GetLayout(this.GetType().ToString() + "." + layoutControlMain.Name, Convert.ToInt32(layoutControlMain.LayoutVersion == null ? "1" : layoutControlMain.LayoutVersion), DefaultLayout.ToArray());
            layoutControlMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutUser));//Load Layout From File
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _account.charName = _src_charname;
            _account.Group = _src_group;
            _account.Start = _src_active;
            _account.BotFilePath = _src_botpath;
            DialogResult = DialogResult.Cancel;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void beBotPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            beBotPath.EditValue = ofd.FileName;
        }
        private void bbiSaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            layoutControlMain.SaveLayoutToStream(ms); layout.LayoutUser = ms.ToArray();
            Program.LM.SaveLayout();//Save Layout into File
        }
        private void bbiLoadLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControlMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutDefault));
            Program.LM.SaveLayout();//Save Layout into File
        }
    }
}