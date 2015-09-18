using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SbotControl
{
    public partial class OutputFrm : Form
    {
        public OutputFrm()
        {
            InitializeComponent();
            Program.Logger.AddUI(rtbLogs, Log.LogLevel.Debug);
        }
    }
}
