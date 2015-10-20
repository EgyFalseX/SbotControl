using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace SbotControl.UI
{
    public partial class WaitWindowFrm : WaitForm
    {
        public WaitWindowFrm()
        {
            InitializeComponent();
            this.proPnl.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.proPnl.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.proPnl.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}