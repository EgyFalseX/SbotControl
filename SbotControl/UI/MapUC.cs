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
        const int SroMapEndY = -4200;
        int SroAllX = Math.Abs(SroMapStartX) + Math.Abs(SroMapEndX);
        int SroAllY = Math.Abs(SroMapStartX) + Math.Abs(SroMapEndX);
        private struct stc_Cord
        {
            public SBot bot;
            public PictureEdit pe;
        }
        Dictionary<int, stc_Cord> OnlineList = new Dictionary<int, stc_Cord>();

        #region  - Functions - 
        public MapUC()
        {
            InitializeComponent();
            pe.LoadAsync(Program.WorldMapPath);
            //Assgin Events
            foreach (SBot bot in Program.BM.Bots)
            {
                bot.StateChanged += Bot_StateChanged;
                bot.PropertyChanged += Bot_PropertyChanged;
            }
            Program.BM.BotListChanged += BM_BotListChanged;
            Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
            this.Disposed += MapUC_Disposed;
        }
        private void AddBotVisual(SBot bot)
        {
            //if (bot.Status != SBot.StatusType.Online)
            //    return;
            PictureEdit peNew = new PictureEdit()
            {
                Name = "pe" + bot.CharName,
                EditValue = global::SbotControl.Properties.Resources.geopoint_16x16,
                Location = ConvertToPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY)),
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder,
                Size = new Size(16, 16),
                TabIndex = 1,
                Tag = bot.ID,
            };
            peNew.Properties.ShowMenu = false;
            peNew.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            
            Controls.Add(peNew);

            OnlineList.Add(bot.ID, new stc_Cord() { bot = bot, pe = peNew });
        }
        private void RemoveBotVisual(SBot bot)
        {
            stc_Cord item = new stc_Cord();
            if (!OnlineList.TryGetValue(bot.ID, out item))
                return;
            item.pe.Dispose();
            OnlineList.Remove(bot.ID);

        }
        private Point ConvertToPoint(int x, int y)
        {
            Point point = new Point();
            float Per_X = pe.Size.Width / SroAllX;
            float Per_Y = pe.Size.Height / SroAllY;

            point.X = Convert.ToInt32(Math.Abs(x) * Per_X);
            point.Y = Convert.ToInt32(Math.Abs(y) * Per_Y);

            return point;
        }
        #endregion
        #region  - Events Handlers - 
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
                    bot.StateChanged += Bot_StateChanged;
                    bot.PropertyChanged += Bot_PropertyChanged;
                    break;
                case BotsManager.ChangesType.Deleted:
                    bot.StateChanged -= Bot_StateChanged;
                    bot.PropertyChanged -= Bot_PropertyChanged;
                    break;
                default:
                    break;
            }

        }

        private void Bot_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SBot bot = (SBot)sender;
            if (e.PropertyName == "PosX" || e.PropertyName == "PosY")
            {
                stc_Cord item = new stc_Cord();
                if (!OnlineList.TryGetValue(bot.ID, out item))
                    return;
                item.pe.Location = ConvertToPoint(Convert.ToInt32(bot.PosX), Convert.ToInt32(bot.PosY));
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
        } 
        #endregion

    }
}
