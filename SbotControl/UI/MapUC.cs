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
        const int SroMapStartX = -17098;
        const int SroMapEndX = 8262;
        const int SroMapStartY = 4185;
        const int SroMapEndY = -4192;
        const double _zeroX_Percent = 0.6720302886890677;
        const double _zeroY_Percent = 0.5007102272727273;
        int SroAllX = Math.Abs(SroMapStartX) + Math.Abs(SroMapEndX);
        int SroAllY = Math.Abs(SroMapStartY) + Math.Abs(SroMapEndY);
        private struct stc_Cord
        {
            public SBot bot;
            public PictureEdit pe;
        }
        Dictionary<string, stc_Cord> OnlineList = new Dictionary<string, stc_Cord>();

        #region  - Functions - 
        public MapUC()
        {
            InitializeComponent();
            pe.LoadAsync(Program.WorldMapPath);
            this.HandleCreated += MapUC_HandleCreated;
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
                    PictureEdit peNew = new PictureEdit()
                    {
                        Name = "pe" + bot.CharName,
                        EditValue = global::SbotControl.Properties.Resources.geopoint_16x16,
                        Location = ConvertToPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY)),
                        BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder,
                        BackColor = Color.Transparent,
                        Size = new Size(16, 16),
                        Anchor = AnchorStyles.None,
                        ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information,
                        ToolTipTitle = bot.CharName,
                        ToolTip = string.Format("Lv. {0}\n\r{1}\n\r{2}\n\rKills: {3}\n\rXP Gained: {4}\n\rSP Gained: {5}\n\rGold: {6}\n\rDied: {7}\n\rDrops: {8}", 
                        bot.Level, bot.SilkroadServerStatus, bot.BotStatus, bot.Kills, bot.XPGained, bot.SPGained, bot.Gold, bot.Died, bot.ItemDrops),
                    };
                    peNew.Properties.ShowMenu = false;
                    peNew.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    peNew.BackColor = Color.Transparent;
                    Controls.Add(peNew);
                    peNew.BringToFront();
                    pe.SendToBack();
                    OnlineList.Add(bot.CharName, new stc_Cord() { bot = bot, pe = peNew });
                    peNew.Parent = pe;
                }));
            }
        }
        private void RemoveBotVisual(SBot bot)
        {
            stc_Cord item = new stc_Cord();
            if (!OnlineList.TryGetValue(bot.CharName, out item))
                return;
            item.pe.Dispose();
            OnlineList.Remove(bot.CharName);
        }
        private Point ConvertToPoint(int x, int y)
        {
            Point point = new Point();

            double Per_X = pe.Size.Width * 1.0 / SroAllX;
            double Per_Y = pe.Size.Height * 1.0 / SroAllY;

            double ZeroX = pe.Size.Width * 1.0 * _zeroX_Percent;
            double ZeroY = pe.Size.Height * 1.0 * _zeroY_Percent;

            double Char_X = x * Per_X;
            double Char_Y = y * Per_Y;

            point.X = Convert.ToInt32(ZeroX + Char_X);
            point.Y = Convert.ToInt32(ZeroY - Char_Y);

            return point;
        }
        #endregion
        #region  - Events Handlers - 
        private void MapUC_HandleCreated(object sender, EventArgs e)
        {
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
            pe.ClientSizeChanged += Pe_ClientSizeChanged;
        }
        private void Pe_ClientSizeChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, stc_Cord> ctr in OnlineList)
            {
                ctr.Value.pe.Location = ConvertToPoint(Convert.ToInt32(ctr.Value.bot.PosX), Convert.ToInt32(ctr.Value.bot.PosY));
            }
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
                if (bot.CharName == "MyRarEIteM")
                {
                    string a = "";
                }
                item.pe.Invoke(new MethodInvoker(() => 
                {
                    item.pe.Location = ConvertToPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY));
                    item.pe.ToolTip = string.Format("Lv. {0}\n\r{1}\n\r{2}\n\rKills: {3}\n\rXP Gained: {4}\n\rSP Gained: {5}\n\rGold: {6}\n\rDied: {7}\n\rDrops: {8}",
                            bot.Level, bot.SilkroadServerStatus, bot.BotStatus, bot.Kills, bot.XPGained, bot.SPGained, bot.Gold, bot.Died, bot.ItemDrops);
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
        private void MapUC_Disposed(object sender, EventArgs e)
        {
            Program.BM.BotListChanged -= BM_BotListChanged;
            Program.BM.ManagerStatusChanged -= BM_ManagerStatusChanged;
            foreach (SBot bot in Program.BM.Bots)
            {
                bot.StateChanged -= Bot_StateChanged;
                bot.PropertyChanged -= Bot_PropertyChanged;
            }
            foreach (KeyValuePair<string, stc_Cord> item in OnlineList)
            {
                item.Value.pe.Dispose();
            }
            OnlineList.Clear();
        }
        #endregion
        
    }
}
