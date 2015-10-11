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
    public partial class MapUC : DevExpress.XtraEditors.XtraUserControl
    {
        public MapUC()
        {
            InitializeComponent();
            pe.LoadAsync(Program.WorldMapPath);
        }
    }
}
