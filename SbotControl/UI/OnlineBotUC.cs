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
            try
            {
                if (Program.BM != null)
                {
                    //Binding Gridcontrol
                    gridControlOverall.DataSource = Program.BM.Bots;
                    Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
                    BM_ManagerStatusChanged(Program.BM, Program.BM.ManagerStatus);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void BM_ManagerStatusChanged(object sender, BotsManager.ManagerStatusType e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void TmrUIBotInfo_Tick(object sender, EventArgs e)
        {
            try
            {
                gridControlOverall.Invoke(new MethodInvoker(() =>
                    {
                        gridControlOverall.RefreshDataSource();
                    }));
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void repositoryItemCheckEditVisable_Click(object sender, EventArgs e)
        {
            try
            {
                SBot bot = (SBot)GridMain.GetRow(GridMain.FocusedRowHandle);
                if (bot == null)
                    return;
                DevExpress.XtraEditors.CheckEdit ctr = (DevExpress.XtraEditors.CheckEdit)sender;
                bot.Visable = !bot.Visable;
                ctr.Checked = !ctr.Checked;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void LayoutInti()
        {
            try
            {
                System.IO.MemoryStream DefaultLayout = new System.IO.MemoryStream();
                GridMain.SaveLayoutToStream(DefaultLayout);
                layout = Program.LM.GetLayout(this.GetType().ToString() + "." + GridMain.Name, Convert.ToInt32(GridMain.OptionsLayout.LayoutVersion == null ? "1" : GridMain.OptionsLayout.LayoutVersion), DefaultLayout.ToArray());
                GridMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutUser));//Load Layout From File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiSaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GridMain.SaveLayoutToStream(ms); layout.LayoutUser = ms.ToArray();
                Program.LM.SaveLayout();//Save Layout into File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiLoadLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridMain.RestoreLayoutFromStream(new System.IO.MemoryStream(layout.LayoutDefault));
                Program.LM.SaveLayout();//Save Layout into File
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
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
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                {
                    bot.Stop();
                    Program.BM.RemoveBot(bot);
                }
                gridControlOverall.RefreshDataSource();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (SBot bot in Program.BM.Bots)
                {
                    bot.Stop();
                    Program.BM.RemoveBot(bot);
                }
                gridControlOverall.RefreshDataSource();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiShowHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiShowAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (SBot bot in Program.BM.Bots)
                    bot.Visable = true;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiHideAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (SBot bot in Program.BM.Bots)
                    bot.Visable = false;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiStartGame_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickStartGameButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiGoClientless_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickGoClienlessButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickDisconnectButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiResetStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickResetButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiSaveSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickSaveSettingsButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiShowHideClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickShowHideClientButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiStartTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickStartTrainingButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void bbiStopTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selected = GridMain.GetSelectedRows();
                if (selected.Length == 0)
                    return;
                List<SBot> lst = new List<SBot>();
                for (int i = 0; i < selected.Length; i++)
                {
                    SBot bot = (SBot)GridMain.GetRow(selected[i]);
                    if (bot == null)
                        continue;
                    lst.Add(bot);
                }
                foreach (SBot bot in lst)
                    bot.ClickStopTrainingButton();
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }

        #endregion
        
    }
}
