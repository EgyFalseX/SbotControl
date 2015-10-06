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

            ceRunAtStartup.Checked = Properties.Settings.Default.RunAtStartup;
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(galleryControlMain, true);
        }
        private void ceRunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["RunAtStartup"] = ceRunAtStartup.Checked;
            Properties.Settings.Default.Save();
            Program.AddRemoveStartup(Properties.Settings.Default.RunAtStartup);
        }
        private void galleryControlMain_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default["SkinName"] = e.Item.Caption;
            Properties.Settings.Default.Save();
        }
    }
}
