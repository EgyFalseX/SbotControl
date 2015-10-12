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
    public partial class HistoryUC : DevExpress.XtraEditors.XtraUserControl
    {
        public System.Threading.Timer tmrPuls;
        private int AutoRefreshInterval = 1000 * 10;
        public HistoryUC()
        {
            InitializeComponent();
            XPSCSData.Session.ConnectionString = Properties.Settings.Default.LogDataConnectionString;
            tmrPuls = new System.Threading.Timer(_ => tmrPuls_Tick(), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
        void tmrPuls_Tick()
        {
            try
            {
                if (!gridControlHistory.Created)
                    return;
                this.Invoke(new MethodInvoker(() =>
                {
                //Save Focused row
                object id = gridViewHistory.GetRowCellValue(gridViewHistory.FocusedRowHandle, gridViewHistory.Columns["AutoId"]);

                    XPSCSData.Session.DropIdentityMap();
                    XPSCSData.Reload();
                //gridControlHistory.RefreshDataSource();
                gridViewHistory.RefreshData();

                //Reselect Focused row
                gridViewHistory.LocateByValue(0, gridViewHistory.Columns["AutoId"], id);
                    gridViewHistory.MakeRowVisible(gridViewHistory.FocusedRowHandle, false);
                }));
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void AutoRefreshSwitch(bool On)
        {
            try
            {
                if (On)
                    tmrPuls.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                else
                    tmrPuls.Change(AutoRefreshInterval, AutoRefreshInterval);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                if (!filename.Contains(".xlsx"))
                    filename += ".xlsx";
                gridControlHistory.ExportToXlsx(filename);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiExportCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                if (!filename.Contains(".csv"))
                    filename += ".csv";
                gridControlHistory.ExportToCsv(filename);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                if (!filename.Contains(".pdf"))
                    filename += ".pdf";
                gridControlHistory.ExportToPdf(filename);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiExportText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                if (!filename.Contains(".Text"))
                    filename += ".Text";
                gridControlHistory.ExportToText(filename);
            }
            catch (Exception ex)
            {
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                if (!filename.Contains(".Text"))
                    filename += ".Text";
                gridControlHistory.ExportToText(filename);
            }
        }
        private void btsiAutoRefresh_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.BarToggleSwitchItem obj = (DevExpress.XtraBars.BarToggleSwitchItem)e.Item;
                AutoRefreshSwitch(obj.Checked);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
    }
}
