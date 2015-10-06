using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl.UI
{
    public partial class AccountUC : DevExpress.XtraEditors.XtraUserControl
    {
        public AccountUC()
        {
            InitializeComponent();
            gridControlMain.DataSource = Program.DM.Accounts;
        }
        private void ReloadData()
        {
            gridControlMain.DataSource = Program.DM.Accounts;
            gridControlMain.RefreshDataSource();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            SbotControl.Account acc = new SbotControl.Account(string.Empty, true, true, true, true, true, string.Empty);
            AddAccountFrm frm = new AddAccountFrm(acc);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Program.DM.AddAccount(acc);
                Program.DM.SaveSettings();
            }
            ReloadData();
        }
        private void repositoryItemButtonEditEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
            AddAccountFrm frm = new AddAccountFrm(acc);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Program.DM.SaveSettings();
            }
            ReloadData();
        }
        private void repositoryItemButtonEditDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
            if (MessageBox.Show("Are you sure ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Program.DM.RemoveAccount(acc);
            Program.DM.SaveSettings();
            ReloadData();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Program.DM.LoadSettings();
            ReloadData();
        }

        private void repositoryItemCheckEditActive_CheckedChanged(object sender, EventArgs e)
        {
            Program.DM.SaveSettings();
        }

        private void repositoryItemCheckEditActive_Click(object sender, EventArgs e)
        {
            CheckEdit ce = (CheckEdit)sender;
            SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
            acc.Start = !acc.Start; ce.Checked = !ce.Checked;
            
            Program.DM.SaveSettings();
            ReloadData();
        }
    }
}
