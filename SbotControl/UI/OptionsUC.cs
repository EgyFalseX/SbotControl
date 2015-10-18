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
    public partial class OptionsUC : DevExpress.XtraEditors.XtraUserControl
    {
        public OptionsUC()
        {
            InitializeComponent();

            try
            {
                ceRunAtStartup.Checked = Properties.Settings.Default.RunAtStartup;
                DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(galleryControlMain, true);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void ceRunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["RunAtStartup"] = ceRunAtStartup.Checked;
                Properties.Settings.Default.Save();
                Program.AddRemoveStartup(Properties.Settings.Default.RunAtStartup);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void galleryControlMain_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default["SkinName"] = e.Item.Caption;
            Properties.Settings.Default.Save();
        }
        private void ceAlert_Connect_Disconnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        private void ceAlert_Died_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
