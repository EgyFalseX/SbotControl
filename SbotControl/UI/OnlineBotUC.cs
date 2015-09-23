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
    public partial class OnlineBotUC : DevExpress.XtraEditors.XtraUserControl
    {
        public OnlineBotUC()
        {
            InitializeComponent();
            if (Program.BM != null)
            {
                //Binding Gridcontrol
                gridControlOverall.DataSource = Program.BM.Bots;
                Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
            }
        }
        private void BM_ManagerStatusChanged(object sender, BotsManager.ManagerStatusType e)
        {
            if (e == BotsManager.ManagerStatusType.Started)
                TmrUIBotInfo.Start();
            else if (e == BotsManager.ManagerStatusType.Stoped)
                TmrUIBotInfo.Stop();
        }
        private void TmrUIBotInfo_Tick(object sender, EventArgs e)
        {
            gridControlOverall.Invoke(new MethodInvoker(() =>
            {
                gridControlOverall.RefreshDataSource();
            }));
        }
        private void repositoryItemCheckEditVisable_Click(object sender, EventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            DevExpress.XtraEditors.CheckEdit ctr = (DevExpress.XtraEditors.CheckEdit)sender;
            bot.Visable = !bot.Visable;
            ctr.Checked = !ctr.Checked;
        }

        private void repositoryItemButtonEditCommands_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            if (e.Button.Caption == "Start Game")
                bot.ClickStartGameButton();
            else if (e.Button.Caption == "Go Clientless")
                bot.ClickGoClienlessButton();
            else if (e.Button.Caption == "Disconnect")
                bot.ClickDisconnectButton();
            else if (e.Button.Caption == "Resert")
                bot.ClickResetButton();
            else if (e.Button.Caption == "Save Settings")
                bot.ClickSaveSettingsButton();
            else if (e.Button.Caption == "Show/Hide Client")
                bot.ClickShowHideClientButton();
            else if (e.Button.Caption == "Start Training")
                bot.ClickStartTrainingButton();
            else if (e.Button.Caption == "End Training")
                bot.ClickStopTrainingButton();
        }
    }
}
