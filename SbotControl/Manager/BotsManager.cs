using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

using System.Text;
using System.Windows.Forms;

namespace SbotControl
{
    public class BotsManager
    {
        public BotsManager()
        {
            //ManagerOnline = true;
            //GetStartedIBots();
            BotLogs = new List<Core.BotLogUnit>();
        }
        public List<SBot> Bots = new List<SBot>();
        public List<Core.BotLogUnit> BotLogs { get; set; }
        public enum ChangesType
        {
            Added,
            Updated,
            Deleted
        }
        public enum ManagerStatusType
        {
            Started,
            Stoped,
        }
        public delegate void BotListChangedEventhandler(object sender, ChangesType e);
        public delegate void ManagerStatusChangedEventhandler(object sender, ManagerStatusType e);
        public event BotListChangedEventhandler BotListChanged;
        public event BotListChangedEventhandler AccountListChanged;
        public event ManagerStatusChangedEventhandler ManagerStatusChanged;
        private bool ManagerOnline;

        ManagerStatusType _managerStatus;
        public ManagerStatusType ManagerStatus
        {
            get { return _managerStatus; }
        }

        public void AddAccount(string Charname, bool Start, bool DCRestart, bool ScrollUnknowSpot, string SbotFilePath)
        {
            Account acc = new Account(Charname, true, true, Start, DCRestart, ScrollUnknowSpot, SbotFilePath);
            //Program.DM.Accounts.Add(acc);
            AddAccount(acc);
        }
        public void AddAccount(Account account)
        {
            Program.DM.Accounts.Add(account);
            if (AccountListChanged != null)
                AccountListChanged(account, ChangesType.Added);

            if (account.Start && ManagerOnline)
                AddBot(account);
        }
        public void UpdateAccount(int index, string Charname, bool Start, bool DCRestart, bool ScrollUnknowSpot, string SbotFilePath)
        {
            Account account = Program.DM.Accounts[index];
            account.charName = Charname;
            account.DCRestart = DCRestart;
            account.RestartUnknowSpot = ScrollUnknowSpot;
            if (AccountListChanged != null)
                AccountListChanged(account, ChangesType.Updated);
            account.BotFilePath = SbotFilePath;
            account.Start = Start;
            if (account.Start && ManagerOnline && account.bot == null)
                AddBot(account);
        }
        public void RemoveAccount(int index)
        {
            if (Program.DM.Accounts[index].bot != null)
            {
                MessageBox.Show("Can't delete bot already processed.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (AccountListChanged != null)
                AccountListChanged(Program.DM.Accounts[index], ChangesType.Deleted);
            Program.DM.Accounts.RemoveAt(index);
        }
        public Account SearchAccount(string charName)
        {
            Account acc = null;
            for (int i = 0; i < Program.DM.Accounts.Count; i++)
            {
                if (Program.DM.Accounts[i].charName == charName)
                {
                    acc = Program.DM.Accounts[i];
                    break;
                }
            }
            return acc;
        }

        public void AddBot(Account account)
        {
            lock (this)
            {
                SBot bot = SBot.CreateSbot();
                account.bot = bot; bot.BotAccount = account;
                AddBot(bot);
            }
        }
        private void Addbot(Process botprocess)
        {
            lock (this)
            {
                SBot bot = SBot.CreateSbot(botprocess);
                bot.PrepareHandlers(); bot.InitiProperties(); //bot.GetClientlessLoginLog();
                if (bot.CharName == string.Empty)
                    return;
                Account account = SearchAccount(bot.CharName);
                if (account != null)
                {
                    account.bot = bot;
                    bot.BotAccount = account;
                }
                else
                    bot.Group = "Unknown";
                    
                AddBot(bot);
            }
        }
        private void AddBot(SBot bot)
        {
            Bots.Add(bot);
            bot.StateChanged += bot_StateChanged;
            bot.LogAdded += Bot_LogAdded;
            bot.PropertyChanged += bot_PropertyChanged;

            Program.Logger.AddLog(Log.LogType.Info, Log.LogLevel.Stander, string.Format("[{0}]- Ready", bot.CharName));
            if (BotListChanged != null)
                BotListChanged(bot, ChangesType.Added);
            bot.Start();
        }

        private void Bot_LogAdded(SBot sender, string Log)
        {
            BotLogs.Add(new Core.BotLogUnit(sender.CharName, DateTime.Now.ToShortDateString(), Log));
        }

        public void RemoveBot(SBot bot)
        {
            if (BotListChanged != null)
                BotListChanged(bot, ChangesType.Deleted);
            bot.StateChanged -= bot_StateChanged; bot.PropertyChanged -= bot_PropertyChanged;
            if (bot.BotAccount != null)
            {
                bot.BotAccount.bot = null;
                Program.Logger.AddLog(Log.LogType.Info, Log.LogLevel.Stander, string.Format("[{0}]- Closed", bot.BotAccount.charName));
            }
            else
                Program.Logger.AddLog(Log.LogType.Info, Log.LogLevel.Stander, string.Format("[{0}]- Closed", bot.CharName));
            lock (Bots)
                Bots.Remove(bot);
            bot.Dispose();
        }
        private void GetStartedBots()
        {
            foreach (Process process in Process.GetProcesses())
            {
                bool isbot = SBot.IsProcessbot(process);
                if (!isbot)
                    continue;
                bool found = false;
                foreach (SBot bot in Bots)
                {
                    if (bot.BotProcess != null && bot.BotProcess.Id == process.Id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Addbot(process);
                    //System.Threading.Thread.Sleep(1000);
                }
            }
        }
        public void KillBotProcess(int botIndex)
        {
            Process process = Bots[botIndex].BotProcess;
            if (process != null)
            {
                if (!process.HasExited)
                    process.Kill();
            }
        }
        public SBot SearchBot(string CharName, string ServerName)
        {
            SBot bot = null;
            for (int i = 0; i < Bots.Count; i++)
            {
                if (Bots[i].CharName == CharName)
                {
                    bot = Bots[i];
                    break;
                }
            }
            return bot;
        }
        
        void bot_StateChanged(SBot sender, SBot.StatusType e)
        {
            if (!ManagerOnline)
            {
                if (e == SBot.StatusType.bot_Process_Terminated)
                {
                    sender.Stop();
                    RemoveBot(sender);
                }
                return;
            }
            Log.LogType logtyp = Log.LogType.Stander;
            Log.LogLevel loglvl = Log.LogLevel.Stander;
            switch (e)
            {
                case SBot.StatusType.Disconnected:
                     logtyp = Log.LogType.Info;
                     loglvl = Log.LogLevel.Debug;
                    ///////////////////////////////////////////////////sender.StartLoginTimer();
                    break;
                case SBot.StatusType.Try_to_login:
                     logtyp = Log.LogType.Info;
                     loglvl = Log.LogLevel.Debug;
                     break;
                case SBot.StatusType.Online:
                     logtyp = Log.LogType.Info;
                     loglvl = Log.LogLevel.Debug;
                     break;
                case SBot.StatusType.bot_Process_Terminated:
                    logtyp = Log.LogType.Error;
                    loglvl = Log.LogLevel.Debug;
                    sender.Stop();
                    if (sender.BotAccount == null || !sender.BotAccount.Start)
                        RemoveBot(sender);
                    else if (sender.BotAccount.DCRestart)
                        sender.Start();
                    break;
                //case SBot.StatusType.Error_Stuck_On_Login:
                //    logtyp = Log.LogType.Error;
                //    loglvl = Log.LogLevel.Debug;
                //    try
                //    {
                //        sender.Stop();
                //        if (!sender.BotAccount.Start)
                //            RemoveBot(sender);
                //        else
                //            sender.Start();
                //    }
                //    catch { }
                //    break;
                case SBot.StatusType.Unknown:
                    logtyp = Log.LogType.Error;
                    loglvl = Log.LogLevel.Stander;
                    break;
            }
            if (sender.BotAccount == null)
                Program.Logger.AddLog(logtyp, loglvl, string.Format("[{0}]-{1}", sender.CharName, e.ToString()));
            else
                Program.Logger.AddLog(logtyp, loglvl, string.Format("[{0}]-{1}", sender.BotAccount.charName, e.ToString()));
        }
        void bot_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "":
                    break;
            }
        }

        private void Resume()
        {
            for (int i = 0; i < Bots.Count; i++)
            {
                //if (Bots[i].LastStatus != SBot.StatusType.Unknown)
                    //bot_StateChanged(Bots[i], SBot.StatusType.Unknown);
                    //Bots[i].
            }
            ManagerOnline = true;
            _managerStatus = ManagerStatusType.Started;
            if (ManagerStatusChanged != null)
                ManagerStatusChanged(this, ManagerStatusType.Started);
        }

        public void Start(bool resume)
        {
            ThreadPool.QueueUserWorkItem((o) => 
            {
                ManagerOnline = true;
                GetStartedBots();
                for (int i = 0; i < Program.DM.Accounts.Count; i++)
                {
                    if (Program.DM.Accounts[i].bot != null || !Program.DM.Accounts[i].Start)
                        continue;
                    AddBot(Program.DM.Accounts[i]);
                }
                if (resume)
                {
                    Resume();
                }

                _managerStatus = ManagerStatusType.Started;
                if (ManagerStatusChanged != null)
                    ManagerStatusChanged(this, ManagerStatusType.Started);
            });
            
        }
        public void Stop()
        {
            ManagerOnline = false;
            _managerStatus = ManagerStatusType.Stoped;
            if (ManagerStatusChanged != null)
                ManagerStatusChanged(this, ManagerStatusType.Stoped);
        }

    }
}
