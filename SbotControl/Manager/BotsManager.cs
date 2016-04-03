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
        public BotsManager(SbotControl.DataManager dm)
        {
            //ManagerOnline = true;
            //GetStartedIBots();
            BotLogs = new List<Core.BotLogUnit>();
            _queAutoStart = new Queue<SBot>();
            tmrSearch = new System.Threading.Timer(_ => tmrSearch_Tick(), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            dm.AccountListChanged += Dm_AccountListChanged;
            tmrAutoStart = new System.Threading.Timer(_ => tmrAutoStart_Tick(), null, 3 * 1000, 3 * 1000);
        }
        public List<SBot> Bots = new List<SBot>();
        public List<Core.BotLogUnit> BotLogs { get; set; }
        public const int BotLogsMaxSize = 1000;
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
        public System.Threading.Timer tmrAutoStart;
        Queue<SBot> _queAutoStart;
        bool QueueLock = false;
        public System.Threading.Timer tmrSearch;
        private bool ManagerOnline;

        ManagerStatusType _managerStatus;
        public ManagerStatusType ManagerStatus
        {
            get { return _managerStatus; }
        }
        private void Dm_AccountListChanged(Account sender, DataManager.ChangesType e)
        {
            try
            {
                switch (e)
                {
                    case DataManager.ChangesType.Added:
                        AddAccount(sender);
                        break;
                    case DataManager.ChangesType.Deleted:
                        RemoveAccount(sender);
                        break;
                    case DataManager.ChangesType.ActiveTrue:
                        if (sender.Start && ManagerOnline)
                            AddBot(sender);
                        break;
                    case DataManager.ChangesType.ActiveFalse:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace);
            }
        }
        public void AddAccount(Account account)
        {
            try
            {
                //Program.DM.Accounts.Add(account);
                if (AccountListChanged != null)
                    AccountListChanged(account, ChangesType.Added);
                //should replace ManagerOnline with 
                //_managerStatus == ManagerStatusType.Started
                if (account.Start && ManagerOnline)
                    AddBot(account);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void UpdateAccount(int index, string Charname, bool Start, bool DCRestart, bool ScrollUnknowSpot, string SbotFilePath)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void RemoveAccount(int index)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void RemoveAccount(Account account)
        {
            try
            {
                if (account.bot != null)
                {
                    MessageBox.Show("Can't delete bot already processed.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (AccountListChanged != null)
                    AccountListChanged(account, ChangesType.Deleted);
                Program.DM.Accounts.Remove(account);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public Account SearchAccount(string charName)
        {
            Account acc = null;
            try
            {
                for (int i = 0; i < Program.DM.Accounts.Count; i++)
                {
                    if (Program.DM.Accounts[i].charName == charName)
                    {
                        acc = Program.DM.Accounts[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            return acc;
        }
        void tmrAutoStart_Tick()
        {
            //Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, string.Format("Queue Size {0}", _queAutoStart.Count));
            if (_queAutoStart.Count == 0 || !ManagerOnline)
                return;
            if (QueueLock)
                return;
            QueueLock = true;
            
            System.Threading.ThreadPool.QueueUserWorkItem((o) =>
            {
                SBot bot = _queAutoStart.Dequeue();
                //Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, string.Format("Locked to login {0}", bot.CharName));
                try
                {
                    if ((bot.BotAccount != null && bot.BotAccount.Start) || bot.BotProcess != null)
                    {
                        Bots.Add(bot);
                        bot.StateChanged += bot_StateChanged;
                        bot.LogAdded += Bot_LogAdded;
                        bot.PropertyChanged += bot_PropertyChanged;
                        Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, string.Format("[{0}]- Start Login ... ", bot.CharName));
                        if (BotListChanged != null)
                            BotListChanged(bot, ChangesType.Added);
                        bot.Start();
                    }
                }
                catch (Exception ex)
                { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }

                QueueLock = false;
                //Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, string.Format("Lock Release After Login {0}", bot.CharName));

                tmrAutoStart_Tick();
            });
        }
        void tmrSearch_Tick()
        {
            try
            {
                GetStartedBots();
                for (int i = 0; i < Program.DM.Accounts.Count; i++)
                {
                    if (Program.DM.Accounts[i].bot != null || !Program.DM.Accounts[i].Start)
                        continue;
                    AddBot(Program.DM.Accounts[i]);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void AddBot(Account account)
        {
            lock (this)
            {
                try
                {
                    if (SearchBot(account.charName) != null)
                        return;
                    SBot bot = SBot.CreateSbot();
                    account.bot = bot; bot.BotAccount = account;
                    //AddBot(bot);
                    _queAutoStart.Enqueue(bot);
                }
                catch (Exception ex)
                { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            }
        }
        private void Addbot(Process botprocess)
        {
            lock (this)
            {
                try
                {
                    SBot bot = SBot.CreateSbot(botprocess);
                    while (!bot.BotProcess.Responding)
                        return;

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

                    //AddBot(bot);
                    _queAutoStart.Enqueue(bot);
                }
                catch (Exception ex)
                { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            }
        }
        private void Bot_LogAdded(SBot sender, string Log)
        {
            lock (BotLogs)
            {
                try
                {
                    if (BotLogs.Count > BotLogsMaxSize)
                        BotLogs.Clear();
                    BotLogs.Add(new Core.BotLogUnit(sender.CharName, DateTime.Now.ToShortDateString(), Log));
                }
                catch (Exception ex)
                { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            }
            //Save Log
            Program.dbOperations.SaveToLog(Core.db.LogType.BotLog, sender.CharName, Log.Trim());
        }
        public void RemoveBot(SBot bot)
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void GetStartedBots()
        {
            try
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
                        foreach (SBot bot in _queAutoStart)
                        {
                            if (bot.BotProcess != null && bot.BotProcess.Id == process.Id)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        Addbot(process);
                        //System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void KillBotProcess(int botIndex)
        {
            try
            {
                Process process = Bots[botIndex].BotProcess;
                if (process != null)
                {
                    if (!process.HasExited)
                        process.CloseMainWindow();
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public SBot SearchBot(string CharName)
        {
            SBot bot = null;
            try
            {
                for (int i = 0; i < Bots.Count; i++)
                {
                    if (Bots[i].CharName == CharName)
                    {
                        bot = Bots[i];
                        break;
                    }
                }
                if (bot == null)
                {
                    foreach (SBot item in _queAutoStart)
                    {
                        if (item.CharName == CharName)
                        {
                            bot = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            return bot;
        }
        
        void bot_StateChanged(SBot sender, SBot.StatusType e)
        {
            try
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
                        Manager.NotifyManager.ShowAlert(sender.CharName, "Diconnected ..!", Manager.NotifyManager.MSG_Type.Disconnect);
                        logtyp = Log.LogType.Info;
                        loglvl = Log.LogLevel.Debug;
                        break;
                    case SBot.StatusType.Try_to_login:
                        logtyp = Log.LogType.Info;
                        loglvl = Log.LogLevel.Debug;
                        break;
                    case SBot.StatusType.Online:
                        Manager.NotifyManager.ShowAlert(sender.CharName, "Online", Manager.NotifyManager.MSG_Type.Connect);
                        logtyp = Log.LogType.Info;
                        loglvl = Log.LogLevel.Debug;
                        break;
                    case SBot.StatusType.bot_Process_Terminated:
                        logtyp = Log.LogType.Error;
                        loglvl = Log.LogLevel.Debug;
                        sender.Stop();
                        if (sender.BotAccount == null || !sender.BotAccount.Start)
                            RemoveBot(sender);
                        else
                            sender.Start();
                        break;
                    case SBot.StatusType.Unknown:
                        logtyp = Log.LogType.Error;
                        loglvl = Log.LogLevel.Stander;
                        break;
                }
                if (sender.BotAccount == null)
                    Program.Logger.AddLog(logtyp, loglvl, string.Format("[{0}]-{1}", sender.CharName, e.ToString()));
                else
                    Program.Logger.AddLog(logtyp, loglvl, string.Format("[{0}]-{1}", sender.BotAccount.charName, e.ToString()));
                //Save Log
                Program.dbOperations.SaveToLog(Core.db.LogType.StatusLog, sender.CharName.ToString(), e.ToString());
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        void bot_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                switch (e.PropertyName)
                {
                    case "":
                        break;
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void Resume()
        {
            try
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
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void Start(bool resume)
        {
            ThreadPool.QueueUserWorkItem((o) => 
            {
                try
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

                    tmrSearch.Change(1000 * 10, 1000 * 10);
                }
                catch (Exception ex)
                { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            });
            
        }
        public void Stop()
        {
            try
            {
                ManagerOnline = false;
                _managerStatus = ManagerStatusType.Stoped;
                if (ManagerStatusChanged != null)
                    ManagerStatusChanged(this, ManagerStatusType.Stoped);

                tmrSearch.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }

    }
}
