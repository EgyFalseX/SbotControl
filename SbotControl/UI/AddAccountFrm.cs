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
    }
}