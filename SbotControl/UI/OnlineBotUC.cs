using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SbotControl.UI
{
    public partial class OnlineBotUC : DevExpress.XtraEditors.XtraUserControl
    {
        public OnlineBotUC()
        {
            InitializeComponent();
        }
        private void OnlineBotUC_Load(object sender, EventArgs e)
        {
            if (Program.BM != null)
            {
                //Binding Gridcontrol
                gridControlOverall.DataSource = Program.BM.Bots;
                Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
                BM_ManagerStatusChanged(Program.BM, Program.BM.ManagerStatus);
                
            }
        }
        private void BM_ManagerStatusChanged(object sender, BotsManager.ManagerStatusType e)
        {
            if (e == BotsManager.ManagerStatusType.Started)
            {
                this.Invoke(new MethodInvoker(() => 
                {
                    TmrUIBotInfo.Start();
                }));
                
            }
            else if (e == BotsManager.ManagerStatusType.Stoped)
            {
                TmrUIBotInfo.Enabled = false;
            }
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

        #region ContextMenu
        private void GridMain_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                popupMenuGrid.ShowPopup(barManagerMain, view.GridControl.PointToScreen(e.Point));
            }
        }
        private void bbiShowDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            AppMainFrm frm = (AppMainFrm)this.ParentForm;
            frm.ShowBotDetailsTab(bot);
        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            Program.BM.RemoveBot(bot);
        }
        private void bbiCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (SBot bot in Program.BM.Bots)
                bot.Stop();
        }
        private void bbiShowHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.Visable = !bot.Visable;
        }
        private void bbiShowAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (SBot bot in Program.BM.Bots)
                bot.Visable = true;
        }
        private void bbiHideAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (SBot bot in Program.BM.Bots)
                bot.Visable = false;
        }
        private void bbiStartGame_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickStartGameButton();
        }
        private void bbiGoClientless_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickGoClienlessButton();
        }
        private void bbiDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickDisconnectButton();
        }
        private void bbiResetStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickResetButton();
        }
        private void bbiSaveSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickSaveSettingsButton();
        }
        private void bbiShowHideClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickShowHideClientButton();
        }
        private void bbiStartTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickStartTrainingButton();
        }
        private void bbiStopTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
            if (bot == null)
                return;
            bot.ClickStopTrainingButton();
        }


        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GridMain.SaveLayoutToXml("C:\\Layout.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
            MessageBox.Show("Done ...");
        }
    }
}
