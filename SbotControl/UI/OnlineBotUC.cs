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
        Core.CtrLayout layout;
        public OnlineBotUC()
        {
            InitializeComponent();
            LayoutInti();
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
        private void LayoutInti()
        {
            System.IO.MemoryStream DefaultLayout = new System.IO.MemoryStream();
            GridMain.SaveLayoutToStream(DefaultLayout);
            layout = Program.LM.GetLayout(this.GetType().ToString() + "." + GridMain.Name, Convert.ToInt32(GridMain.OptionsLayout.LayoutVersion == null ? "1" : GridMain.OptionsLayout.LayoutVersion), DefaultLayout.ToArray());
            GridMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutUser));//Load Layout From File
        }
        private void bbiSaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            GridMain.SaveLayoutToStream(ms); layout.LayoutUser = ms.ToArray();
            Program.LM.SaveLayout();//Save Layout into File
        }
        private void bbiLoadLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutDefault));
            Program.LM.SaveLayout();//Save Layout into File
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
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                AppMainFrm frm = (AppMainFrm)this.ParentForm;
                frm.ShowBotDetailsTab(bot);
            }
        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.Stop();
                Program.BM.RemoveBot(bot);
            }
        }
        private void bbiCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (SBot bot in Program.BM.Bots)
            {
                bot.Stop();
                Program.BM.RemoveBot(bot);
            }
        }
        private void bbiShowHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.Visable = !bot.Visable;
            }
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
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickStartGameButton();
            }
        }
        private void bbiGoClientless_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickGoClienlessButton();
            }
        }
        private void bbiDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickDisconnectButton();
            }
        }
        private void bbiResetStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickResetButton();
            }
        }
        private void bbiSaveSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickSaveSettingsButton();
            }
        }
        private void bbiShowHideClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickShowHideClientButton();
            }
        }
        private void bbiStartTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickStartTrainingButton();
            }
        }
        private void bbiStopTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selected = GridMain.GetSelectedRows();
            if (selected.Length == 0)
                return;
            for (int i = 0; i < selected.Length; i++)
            {
                SBot bot = (SBot)GridMain.GetRow(selected[i]);
                if (bot == null)
                    return;
                bot.ClickStopTrainingButton();
            }
        }


        #endregion
        
    }
}
