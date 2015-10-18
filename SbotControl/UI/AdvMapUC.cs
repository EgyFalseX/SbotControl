using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;

namespace SbotControl.UI
{
    public partial class AdvMapUC : DevExpress.XtraEditors.XtraUserControl
    {
        int Start_X = -20928;
        int End_X = 22656;
        int Start_Y = 7761;
        int End_Y = -16418;
        private struct stc_Cord
        {
            public SBot bot;
            public MapPushpin mp;
            public DevExpress.XtraBars.BarButtonItem menu;
        }
        Dictionary<string, stc_Cord> OnlineList = new Dictionary<string, stc_Cord>();
        string _focusedCharName = string.Empty;
        #region  - Functions - 
        public AdvMapUC()
        {
            InitializeComponent();
            this.HandleCreated += MapUC_HandleCreated;
        }
        private GeoPoint ConvertToGeoPoint(int sro_x, int sro_y)
        {
            if (sro_x < Start_X || sro_x > End_X || sro_y > Start_Y || sro_y < End_Y)
            {
                return new GeoPoint(0, 0);
            }
            double X_Per = (180 * 2 * 1.00) / (Math.Abs(Start_X) + Math.Abs(End_X));
            double Y_Per = (85.1 * 2 * 1.00) / (Math.Abs(Start_Y) + Math.Abs(End_Y));
            double NewX = (sro_x * X_Per) + (sro_x < 0 ? -7 : -7.15);
            double NewY = (sro_y * Y_Per) + (sro_y < 0 ? 21 : 22.6);
            return new GeoPoint(NewY, NewX);
        }
        private void AddBotVisual(SBot bot)
        {
            lock (this)
            {
                //Program.BM.Bots
                stc_Cord found = new stc_Cord();
                if (OnlineList.TryGetValue(bot.CharName, out found))
                    return;
                this.Invoke(new MethodInvoker(() =>
                {
                    DevExpress.XtraMap.MapPushpin mp = new MapPushpin()
                    {
                        //Image = global::SbotControl.Properties.Resources.Info,
                        Location = ConvertToGeoPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY)),
                        Text = bot.CharName,
                        TextColor = System.Drawing.Color.Lime,
                        TextGlowColor = System.Drawing.Color.Gray,
                        ToolTipPattern = string.Format("Lv. {0}\n\r{1}\n\r{2}\n\rKills: {3}\n\rXP Gained: {4}\n\rSP Gained: {5}\n\rGold: {6}\n\rDied: {7}\n\rDrops: {8}",
                        bot.Level, bot.SilkroadServerStatus, bot.BotStatus, bot.Kills, bot.XPGained, bot.SPGained, bot.Gold, bot.Died, bot.ItemDrops),
                        UseAnimation = true,
                    };
                    ((DevExpress.XtraMap.InformationLayer)MCMain.Layers[0]).Data.Items.Add(mp);
                    stc_Cord stc = new stc_Cord() { bot = bot, mp = mp };
                    //Create Context menu item
                    DevExpress.XtraBars.BarButtonItem bbiNew = new DevExpress.XtraBars.BarButtonItem();
                    barManagerMain.Items.Add(bbiNew);
                    bsiSetFocus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {new DevExpress.XtraBars.LinkPersistInfo(bbiNew)});
                    bbiNew.Caption = bot.CharName;
                    bbiNew.Glyph = global::SbotControl.Properties.Resources.geopoint_16x16;
                    //bbiNew.Id = 1;
                    bbiNew.Tag = stc;
                    bbiNew.ItemClick += BbiSetFocus_ItemClick;
                    bbiNew.Name = "bbiNew" + bot.CharName;

                    stc.menu = bbiNew;
                OnlineList.Add(bot.CharName, stc);
                }));
            }
        }
        private void RemoveBotVisual(SBot bot)
        {
            stc_Cord item = new stc_Cord();
            if (!OnlineList.TryGetValue(bot.CharName, out item))
                return;
            ((DevExpress.XtraMap.InformationLayer)MCMain.Layers[0]).Data.Items.Remove(item.mp);
            item.mp = null;

            item.menu.ItemClick -= BbiSetFocus_ItemClick;
            barManagerMain.Items.Remove(item.menu);
            item.menu.Dispose();

            OnlineList.Remove(bot.CharName);
        }
        #endregion
        #region  - Events Handlers - 
        private void MapUC_HandleCreated(object sender, EventArgs e)
        {
            ImageTilesLayer imageTilesLayer = new ImageTilesLayer();
            MCMain.Layers.Add(imageTilesLayer);
            imageTilesLayer.DataProvider = new Core.LocalProvider();

            //Assgin Events
            foreach (SBot bot in Program.BM.Bots)
            {
                bot.StateChanged += Bot_StateChanged;
                bot.PropertyChanged += Bot_PropertyChanged;
                AddBotVisual(bot);
            }
            Program.BM.BotListChanged += BM_BotListChanged;
            Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
            this.Disposed += MapUC_Disposed;
        }
        private void BM_ManagerStatusChanged(object sender, BotsManager.ManagerStatusType e)
        {
            switch (e)
            {
                case BotsManager.ManagerStatusType.Started:
                    break;
                case BotsManager.ManagerStatusType.Stoped:
                    break;
                default:
                    break;
            }
        }
        private void BM_BotListChanged(object sender, BotsManager.ChangesType e)
        {
            SBot bot = (SBot)sender;
            switch (e)
            {
                case BotsManager.ChangesType.Added:
                    AddBotVisual(bot);
                    bot.StateChanged += Bot_StateChanged;
                    bot.PropertyChanged += Bot_PropertyChanged;
                    break;
                case BotsManager.ChangesType.Deleted:
                    bot.StateChanged -= Bot_StateChanged;
                    bot.PropertyChanged -= Bot_PropertyChanged;
                    RemoveBotVisual(bot);
                    break;
                default:
                    break;
            }

        }
        private void Bot_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SBot bot = (SBot)sender;
            if (e.PropertyName == "PosX" || e.PropertyName == "PosY" || e.PropertyName == "Level" || e.PropertyName == "Status" || e.PropertyName == "SilkroadServerStatus" || e.PropertyName == "Kills" || e.PropertyName == "XPGained"
                || e.PropertyName == "SPGained" || e.PropertyName == "Gold" || e.PropertyName == "Died" || e.PropertyName == "ItemDrops")
            {
                stc_Cord item = new stc_Cord();
                if (!OnlineList.TryGetValue(bot.CharName, out item))
                    return;
                
                MCMain.Invoke(new MethodInvoker(() =>
                {
                    item.mp.ToolTipPattern = string.Format("Lv. {0}\n\r{1}\n\r{2}\n\rKills: {3}\n\rXP Gained: {4}\n\rSP Gained: {5}\n\rGold: {6}\n\rDied: {7}\n\rDrops: {8}",
                            bot.Level, bot.SilkroadServerStatus, bot.BotStatus, bot.Kills, bot.XPGained, bot.SPGained, bot.Gold, bot.Died, bot.ItemDrops);
                    if (e.PropertyName == "PosX" || e.PropertyName == "PosY")
                    {
                        item.mp.Location = ConvertToGeoPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY));
                        if (item.bot.CharName == _focusedCharName)
                            MCMain.SetCenterPoint(item.mp.Location, true);
                    }
                    
                }));
            }
        }
        private void Bot_StateChanged(SBot sender, SBot.StatusType e)
        {
            switch (e)
            {
                case SBot.StatusType.Nothing:
                    break;
                case SBot.StatusType.Unknown:
                    break;
                case SBot.StatusType.Disconnected:
                    break;
                case SBot.StatusType.Try_to_login:
                    break;
                case SBot.StatusType.Online:
                    break;
                case SBot.StatusType.bot_Process_Terminated:
                    break;
                case SBot.StatusType.BotStuck_NPC:
                    break;
                default:
                    break;
            }
        }
        private void MCMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                _focusedCharName = string.Empty;
            else
                popupMenuGrid.ShowPopup(new Point(e.X, e.Y));
        }
        private void BbiSetFocus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem item = (DevExpress.XtraBars.BarButtonItem)e.Item;
            if (item.Tag.GetType() != typeof(stc_Cord))
                return;
            stc_Cord stc = (stc_Cord)item.Tag;
            if (stc.mp == null)
                return;
            DevExpress.XtraMap.MapPushpin mp = (DevExpress.XtraMap.MapPushpin)stc.mp;
            MCMain.SetCenterPoint(mp.Location, true);
            _focusedCharName = stc.bot.CharName;
        }
        private void MapUC_Disposed(object sender, EventArgs e)
        {
            Program.BM.BotListChanged -= BM_BotListChanged;
            Program.BM.ManagerStatusChanged -= BM_ManagerStatusChanged;
            foreach (SBot bot in Program.BM.Bots)
            {
                bot.StateChanged -= Bot_StateChanged;
                bot.PropertyChanged -= Bot_PropertyChanged;
            }
            OnlineList.Clear();
            MCMain.Dispose();
        }

        #endregion

       
    }
}
