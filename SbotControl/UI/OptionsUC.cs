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
    }
}
