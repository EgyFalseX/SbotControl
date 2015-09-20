using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl
{
    public partial class AppMainFrm : DevExpress.XtraEditors.XtraForm
    {
        public AppMainFrm()
        {
            InitializeComponent();
        }

        private void tabbedViewMain_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control != null)
                return;
            if (e.Document == docAccount)
            {
                e.Control = new UI.AccountUC();
            }
            else if (e.Document == docOption)
            {
                e.Control = new UI.OptionsUC();
            }
        }
    }
}