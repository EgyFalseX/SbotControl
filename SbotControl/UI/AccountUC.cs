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
            try
            {
                gridControlMain.DataSource = Program.DM.Accounts;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void ReloadData()
        {
            try
            {
                gridControlMain.DataSource = Program.DM.Accounts;
                gridControlMain.RefreshDataSource();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SbotControl.Account acc = new SbotControl.Account(string.Empty, true, true, true, true, true, string.Empty, 300);
                AddAccountFrm frm = new AddAccountFrm(acc);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Program.DM.AddAccount(acc);
                    Program.DM.SaveSettings();
                }
                ReloadData();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void repositoryItemButtonEditEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
                AddAccountFrm frm = new AddAccountFrm(acc);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Program.DM.SaveSettings();
                }
                ReloadData();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void repositoryItemButtonEditDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
                if (MessageBox.Show("Are you sure ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                Program.DM.RemoveAccount(acc);
                Program.DM.SaveSettings();
                ReloadData();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                Program.DM.LoadSettings();
                ReloadData();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void repositoryItemCheckEditActive_Click(object sender, EventArgs e)
        {
            try
            {
                CheckEdit ce = (CheckEdit)sender;
                SbotControl.Account acc = (SbotControl.Account)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
                acc.Start = !acc.Start; ce.Checked = !ce.Checked;

                Program.DM.SaveSettings();
                ReloadData();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
    }
}
