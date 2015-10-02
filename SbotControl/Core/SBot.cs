﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace SbotControl
{
    //[Bind(Exclude = "Id,SomeOtherProperty")]
    public class SBot : IDisposable , INotifyPropertyChanged
    {
        #region Vars
        public int ID = new Random().Next(60000);
        private DateTime StartupTime = DateTime.Now;
        public const string BOTPROOF = "ID_PANEL1!";
        public const string BotTitle = "by bot-cave.net";
        public const string InventoryTitle = "Player inventory";
        private const string ProcessName = "SBot_2.0.14";
        private const string BotStuck_NPC = "No information about current npc";//[08:15:44] * No information about current npc (26766). Too much lag on your computer? Try to use return scroll to fix this problem!

        private const string MapWindowTitle = "[iBot] Silkroad Map";
        public const string DisconnectedMSG = "Disconnected from server";
        public const string LoginSuccessfulMSG = "Login Successful";
        public const string EmptySlotTitle = "[Empty]";
        public const string ErrorScriptSteps = "Error - Next position is too far!";
        public const string ErrorHSIsDown = "* HS Server is busy or down!";
        public const string ErrorC9PingTimeOut = "C9 Error (Ping timeout)";
        public const string botTerminatedString = "Ibot Process Terminated";
        public const string ErrorStuckOnLogin = "Error_Stuck_On_Login";
        private Process _process;
        private Account _account;
        private StatusType _status = StatusType.Nothing;
        public System.Threading.Timer tmrPuls;
        public System.Threading.Timer tmrLogin;
        private int _LastLogLength = 0;
        public int LoginTimerInterval = 1000 * 120;
        //public bool HSState = true;

        private double _StartupSkill, _StartupGold, _StartupExperience = 0;

        public delegate void ChangedEventhandler(SBot sender, StatusType e); public event ChangedEventhandler StateChanged;
        public delegate void LogAddedEventhandler(SBot sender, string Log); public event LogAddedEventhandler LogAdded;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        # region IntPtr
        private IntPtr MainWindowHandle { get; set; }
        private IntPtr MainPanalHandle { get; set; }
        private IntPtr BtnStartGameHandle { get; set; }
        private IntPtr BtnGoClientlessHandle { get; set; }
        private IntPtr BtnDisconnectHandle { get; set; }
        private IntPtr TopPanalHandle { get; set; }
        private IntPtr RightPanalHandle { get; set; }
        private IntPtr ButtomPanalHandle { get; set; }

        //Top Panal Ctr
        private IntPtr BotVersionHandle { get; set; }
        private IntPtr CharHPProgressBarHandle { get; set; }
        private IntPtr CharMPProgressBarHandle { get; set; }
        private IntPtr CharExpProgressBarHandle { get; set; }
        private IntPtr BotServerStatusHandle { get; set; }
        private IntPtr SilkroadServerStatusHandle { get; set; }
        private IntPtr BotStatusHandle { get; set; }
        private IntPtr ConnectionQualityAvgHandle { get; set; }
        private IntPtr ConnectionQualityCurHandle { get; set; }
        //Right Panal Ctr
        private IntPtr PosXHandle { get; set; }
        private IntPtr PosYHandle { get; set; }
        private IntPtr CharNameHandle { get; set; }
        private IntPtr LevelHandle { get; set; }
        private IntPtr GoldHandle { get; set; }
        private IntPtr SkillPointHandle { get; set; }
        private IntPtr LocationNameHandle { get; set; }
        private IntPtr TotaltimeHandle { get; set; }
        private IntPtr KillsHandle { get; set; }
        private IntPtr XPGainedHandle { get; set; }
        private IntPtr XPMinHandle { get; set; }
        private IntPtr XPHHandle { get; set; }
        private IntPtr SPGainedHandle { get; set; }
        private IntPtr SPMinHandle { get; set; }
        private IntPtr SPHHandle { get; set; }
        private IntPtr DiedHandle { get; set; }
        private IntPtr DiedsessHandle { get; set; }
        private IntPtr ItemDropsHandle { get; set; }
        private IntPtr GoldLoopHandle { get; set; }
        private IntPtr BtnResetStatusHandle { get; set; }
        private IntPtr BtnSaveSettingsHandle { get; set; }
        private IntPtr BtnHieClientHandle { get; set; }
        private IntPtr BtnStartTrainingHandle { get; set; }
        private IntPtr BtnStopTrainingHandle { get; set; }
        //Buttom Panal Ctr
        private IntPtr BotLogsHandle { get; set; }
        private IntPtr InventoryMainWindowHandle { get; set; }
        private IntPtr InventoryMainTabHandle { get; set; }
        private IntPtr InventoryGridHandle { get; set; }
        private IntPtr InventoryGridRowsHandle { get; set; }
        # endregion

        # region Types
        private enum CtrID : Int64
        {
            //MainTab = 0x000049D,
            MainTab = 0x00004A0,

            BtnStartGame = 0x00000FC,
            BtnGoClientless = 0x00000FD,
            BtnDisconnect = 0x00000FE,

            TopPanal = 0x00000FB,
            RightPanal = 0x000049D,
            ButtomPanal = 0x000049F,
            //Top Panal Ctr
            BotVersion = 0x00000E9,
            CharHPProgressBar = 0x00000EB,
            CharMPProgressBar = 0x00000ED,
            CharExpProgressBar = 0x00000EF,
            BotServerStatus = 0x00000F1,
            SilkroadServerStatus = 0x00000F3,
            BotStatus = 0x00000F5,
            ConnectionQualityAvg = 0x00000F8,
            ConnectionQualityCur = 0x00000FA,
            //Right Panal Ctr
            PosX = 0x0000470,
            PosY = 0x0000472,
            CharName = 0x0000475,
            Level = 0x0000477,
            Gold = 0x0000479,
            SkillPoint = 0x000047B,
            LocationName = 0x000047D,
            Totaltime = 0x0000480,
            Kills = 0x0000482,
            XPGained = 0x0000484,
            XPMin = 0x0000486,
            XPH = 0x0000488,
            SPGained = 0x000048A,
            SPMin = 0x000048C,
            SPH = 0x000048E,
            Died = 0x0000490,
            Diedsess = 0x0000492,
            ItemDrops = 0x0000494,
            GoldLoop = 0x0000496,
            BtnResetStatus = 0x0000497,
            BtnSaveSettings = 0x0000499,
            BtnHieClient = 0x000049A,
            BtnStartTraining = 0x000049B,
            BtnStopTraining = 0x000049C,
            //Buttom Panal Ctr
            BotLogs = 0x000049E,
            //Inventory Panal Ctr
            InventoryMainTab = 0x00000A9,
            InventoryGrid = 0x00000A8,
            InventoryGridRows = 0xFFFFFF0B,
        }
        public enum StatusType
        {
            Nothing,
            Unknown,
            Disconnected,
            Try_to_login,
            Online,
            bot_Process_Terminated,
            BotStuck_NPC,
        }
        # endregion

        public SBot()
        {
            //InitPulsTimer();
            //InitiTmrLogin();  
            tmrPuls = new System.Threading.Timer(_ => tmrPuls_Tick(), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            tmrLogin = new System.Threading.Timer(_ => tmrLogin_Tick(), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            
        }
        public static SBot CreateSbot(Process botProcess = null)
        {
            SBot bot = new SBot();
            bot._process = botProcess;
            return bot;
        }
        
        public void LoginTimerStart()
        {
            tmrLogin.Change(LoginTimerInterval, System.Threading.Timeout.Infinite);
            Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Stander, string.Format("[{0}]- Stuck while login Provider Online ... ", CharName));
        }
        public void LoginTimerEnd()
        {
            if (tmrLogin != null)
            {
                tmrLogin.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Stander, string.Format("[{0}]- Stuck while login Provider Offline ... ", CharName));
            }
        }

        public void PlusTimerStart()
        {
            tmrPuls.Change(1000, 1000 * 1);
            Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Stander, string.Format("[{0}]- Puls Online ... ", CharName));
        }
        public void PlusTimerEnd()
        {
            tmrPuls.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Stander, string.Format("[{0}]- Puls Online ... ", CharName));
        }
        void tmrPuls_Tick()
        {
            if (_process == null || _process.HasExited)
                return;
            //GetClientlessLoginLog();
            GetStatusLogList();
            if (_status != StatusType.Unknown)
            {
                GetCharInventory();
                GetPetInventory();
                InitiProperties();
            }
        }
        void tmrLogin_Tick()
        {
            Program.Logger.AddLog(Log.LogType.Error, Log.LogLevel.Stander, string.Format("[{0}]- Stuck while login ... ", CharName));
            LoginTimerEnd();
            if (_process == null || _process.HasExited)
                return;
            PerformRestartBot();
            //if (_status != StatusType.Login_Successful)
            //    AddClientlessLoginLogItem("[00:00:00] " + ErrorStuckOnLogin);
        }

        public bool PrepareHandlers()
        {
            
            
            MainWindowHandle = FindMainWindowInProcess(SBot.BotTitle);

            IntPtr MainPanalHandle = Win32.GetWindow(MainWindowHandle, Win32.GetWindow_Cmd.GW_CHILD);
            TopPanalHandle = Win32.GetWindow(MainPanalHandle, Win32.GetWindow_Cmd.GW_CHILD);
            BtnStartGameHandle = Win32.GetWindow(TopPanalHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnGoClientlessHandle = Win32.GetWindow(BtnStartGameHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnDisconnectHandle = Win32.GetWindow(BtnGoClientlessHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr ListView = Win32.GetWindow(BtnDisconnectHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            RightPanalHandle = Win32.GetWindow(ListView, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            ButtomPanalHandle = Win32.GetWindow(RightPanalHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            //MainPanalHandle = Win32.GetDlgItem(MainWindowHandle, (int)CtrID.MainTab);
            //BtnStartGameHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.BtnStartGame);
            //BtnGoClientlessHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.BtnGoClientless);
            //BtnDisconnectHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.BtnDisconnect);
            //TopPanalHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.TopPanal);
            //RightPanalHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.RightPanal);
            //ButtomPanalHandle = Win32.GetDlgItem(MainPanalHandle, (int)CtrID.ButtomPanal);

            //TopPanal Ctr
            IntPtr Tmp_VersionText = Win32.GetWindow(TopPanalHandle, Win32.GetWindow_Cmd.GW_CHILD);// Not Used
            BotVersionHandle = Win32.GetWindow(Tmp_VersionText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_HPText = Win32.GetWindow(BotVersionHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            CharHPProgressBarHandle = Win32.GetWindow(Tmp_HPText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_MPText = Win32.GetWindow(CharHPProgressBarHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            CharMPProgressBarHandle = Win32.GetWindow(Tmp_MPText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_XpText = Win32.GetWindow(CharMPProgressBarHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            IntPtr Tmp_XpBar = Win32.GetWindow(Tmp_XpText, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            IntPtr Tmp_BotServerStatusText = Win32.GetWindow(Tmp_XpBar, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            BotServerStatusHandle = Win32.GetWindow(Tmp_BotServerStatusText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SilkroadServerStatusText = Win32.GetWindow(BotServerStatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            SilkroadServerStatusHandle = Win32.GetWindow(Tmp_SilkroadServerStatusText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_BotStatusText = Win32.GetWindow(SilkroadServerStatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            BotStatusHandle = Win32.GetWindow(Tmp_BotStatusText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_ConnectionQua = Win32.GetWindow(BotStatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            IntPtr Tmp_AvgText = Win32.GetWindow(Tmp_ConnectionQua, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            ConnectionQualityAvgHandle = Win32.GetWindow(Tmp_AvgText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_CurText = Win32.GetWindow(ConnectionQualityAvgHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            ConnectionQualityCurHandle = Win32.GetWindow(Tmp_CurText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            //BotVersionHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.BotVersion);
            //CharHPProgressBarHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.CharHPProgressBar);
            //CharMPProgressBarHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.CharMPProgressBar);
            //CharExpProgressBarHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.CharExpProgressBar);
            //BotServerStatusHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.BotServerStatus);
            //SilkroadServerStatusHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.SilkroadServerStatus);
            //BotStatusHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.BotStatus);
            //ConnectionQualityAvgHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.ConnectionQualityAvg);
            //ConnectionQualityCurHandle = Win32.GetDlgItem(TopPanalHandle, (int)CtrID.ConnectionQualityCur);

            //RightPanal Ctr
            IntPtr Tmp_XText = Win32.GetWindow(RightPanalHandle, Win32.GetWindow_Cmd.GW_CHILD);// Not Used
            PosXHandle = Win32.GetWindow(Tmp_XText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_YText = Win32.GetWindow(PosXHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            PosYHandle = Win32.GetWindow(Tmp_YText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_CharLine = Win32.GetWindow(PosYHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            IntPtr Tmp_CharText = Win32.GetWindow(Tmp_CharLine, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            CharNameHandle = Win32.GetWindow(Tmp_CharText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            if (CharNameHandle == IntPtr.Zero)
                return false;
            //PosXHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.PosX);
            //PosYHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.PosY);
            //CharNameHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.CharName);
            //LevelHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Level);
            //GoldHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Gold);
            //SkillPointHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.SkillPoint);
            //LocationNameHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.LocationName);
            //TotaltimeHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Totaltime);
            //KillsHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Kills);
            //XPGainedHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.XPGained);
            //XPMinHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.XPMin);
            //XPHHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.XPH);
            //SPGainedHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.SPGained);
            //SPMinHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.SPMin);
            //SPHHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.SPH);
            //DiedHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Died);
            //DiedsessHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.Diedsess);
            //ItemDropsHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.ItemDrops);
            //GoldLoopHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.GoldLoop);
            //BtnResetStatusHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.BtnResetStatus);
            //BtnSaveSettingsHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.BtnSaveSettings);
            //BtnHieClientHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.BtnHieClient);
            //BtnStartTrainingHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.BtnStartTraining);
            //BtnStopTrainingHandle = Win32.GetDlgItem(RightPanalHandle, (int)CtrID.BtnStopTraining);
            IntPtr Tmp_LevelText = Win32.GetWindow(CharNameHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            LevelHandle = Win32.GetWindow(Tmp_LevelText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_GoldText = Win32.GetWindow(LevelHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            GoldHandle = Win32.GetWindow(Tmp_GoldText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SPText = Win32.GetWindow(GoldHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            SkillPointHandle = Win32.GetWindow(Tmp_SPText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_LocationText = Win32.GetWindow(SkillPointHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            LocationNameHandle = Win32.GetWindow(Tmp_LocationText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_TotalTimeLine = Win32.GetWindow(LocationNameHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            IntPtr Tmp_TotalTimeText = Win32.GetWindow(Tmp_TotalTimeLine, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            TotaltimeHandle = Win32.GetWindow(Tmp_TotalTimeText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_KillsText = Win32.GetWindow(TotaltimeHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            KillsHandle = Win32.GetWindow(Tmp_KillsText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_XPGainedText = Win32.GetWindow(KillsHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            XPGainedHandle = Win32.GetWindow(Tmp_XPGainedText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_XPMinText = Win32.GetWindow(XPGainedHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            XPMinHandle = Win32.GetWindow(Tmp_XPMinText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_XPHText = Win32.GetWindow(XPMinHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            XPHHandle = Win32.GetWindow(Tmp_XPHText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SPGainedText = Win32.GetWindow(XPHHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            SPGainedHandle = Win32.GetWindow(Tmp_SPGainedText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SPMinText = Win32.GetWindow(SPGainedHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            SPMinHandle = Win32.GetWindow(Tmp_SPMinText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SPHText = Win32.GetWindow(SPMinHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            SPHHandle = Win32.GetWindow(Tmp_SPHText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_DiedText = Win32.GetWindow(SPHHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            DiedHandle = Win32.GetWindow(Tmp_DiedText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_DiedsessText = Win32.GetWindow(DiedHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            DiedsessHandle = Win32.GetWindow(Tmp_DiedsessText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_ItemDropsText = Win32.GetWindow(DiedsessHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            ItemDropsHandle = Win32.GetWindow(Tmp_ItemDropsText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_GoldLoopText = Win32.GetWindow(ItemDropsHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            GoldLoopHandle = Win32.GetWindow(Tmp_GoldLoopText, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnResetStatusHandle = Win32.GetWindow(GoldLoopHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Tmp_SaveSettingLine = Win32.GetWindow(BtnResetStatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);// Not Used
            BtnSaveSettingsHandle = Win32.GetWindow(Tmp_SaveSettingLine, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnHieClientHandle = Win32.GetWindow(BtnSaveSettingsHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnStartTrainingHandle = Win32.GetWindow(BtnHieClientHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnStopTrainingHandle = Win32.GetWindow(BtnStartTrainingHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            //RightPanal Ctr
            //BotLogsHandle = Win32.GetDlgItem(ButtomPanalHandle, (int)CtrID.BotLogs);
            BotLogsHandle = Win32.GetWindow(ButtomPanalHandle, Win32.GetWindow_Cmd.GW_CHILD);
            
            //Inventory Handlers
            //InventoryMainWindowHandle = FindMainWindowInProcess(SBot.InventoryTitle);
            //InventoryMainTabHandle = Win32.GetDlgItem(InventoryMainWindowHandle, (int)CtrID.InventoryMainTab);
            //InventoryGridHandle = Win32.GetDlgItem(InventoryMainTabHandle, (int)CtrID.InventoryGrid);
            //InventoryGridRowsHandle = Win32.GetWindow(Win32.GetWindow(InventoryGridHandle, Win32.GetWindow_Cmd.GW_CHILD), Win32.GetWindow_Cmd.GW_HWNDLAST);
            
            return true;
        }
        public void InitiProperties()
        {
            UpdateProperty(BotVersionHandle, ref _botVersion, "BotVersion");
            //GetCharHPProgressBar(); GetCharMPProgressBar(); GetCharExpProgressBar();
            UpdateProperty(BotServerStatusHandle, ref _botServerStatus, "BotServerStatus");
            UpdateProperty(SilkroadServerStatusHandle, ref _silkroadServerStatus, "SilkroadServerStatus");
            UpdateProperty(BotStatusHandle, ref _botStatus, "BotStatus");
            UpdateProperty(ConnectionQualityAvgHandle, ref _connectionQualityAvg, "ConnectionQualityAvg");
            UpdateProperty(ConnectionQualityCurHandle, ref _connectionQualityCur, "ConnectionQualityCur");
            UpdateProperty(PosXHandle, ref _posX, "PosX");
            UpdateProperty(PosYHandle, ref _posY, "PosY");
            if (_charName == null || _charName.Trim() == string.Empty || _charName == "none")
                UpdateProperty(CharNameHandle, ref _charName, "CharName");
            UpdateProperty(LevelHandle, ref _level, "Level");
            UpdateProperty(GoldHandle, ref _gold, "Gold");
            UpdateProperty(SkillPointHandle, ref _skillPoint, "SkillPoint");
            UpdateProperty(LocationNameHandle, ref _locationName, "LocationName");
            UpdateProperty(TotaltimeHandle, ref _totaltime, "Totaltime");
            UpdateProperty(KillsHandle, ref _kills, "Kills");
            UpdateProperty(XPGainedHandle, ref _xPGained, "XPGained");
            UpdateProperty(XPMinHandle, ref _xPMin, "XPMin");
            UpdateProperty(XPHHandle, ref _xPH, "XPH");
            UpdateProperty(SPGainedHandle, ref _sPGained, "SPGained");
            UpdateProperty(SPMinHandle, ref _sPMin, "SPMin");
            UpdateProperty(SPHHandle, ref _sPH, "SPH");
            UpdateProperty(DiedHandle, ref _died, "Died");
            UpdateProperty(DiedsessHandle, ref _diedsess, "Diedsess");
            UpdateProperty(ItemDropsHandle, ref _itemDrops, "ItemDrops");
            UpdateProperty(GoldLoopHandle, ref _goldLoop, "GoldLoop");
            UpdateProperty(BtnResetStatusHandle, ref _btnResetStatus, "BtnResetStatus");
            UpdateProperty(BtnSaveSettingsHandle, ref _btnSaveSettings, "BtnSaveSettings");
            UpdateProperty(BtnHieClientHandle, ref _btnHieClient, "BtnHieClient");
            UpdateProperty(BtnStartTrainingHandle, ref _btnStartTraining, "BtnStartTraining");
            UpdateProperty(BtnStopTrainingHandle, ref _btnStopTraining, "BtnStopTraining");
            //HP Bar
            Bitmap hpBar = null;
            try { hpBar = new Bitmap(PrintWindow(CharHPProgressBarHandle)); } catch { }
            
            if (hpBar != null && !hpBar.Equals(_hpBar))
            {
                _hpBar = hpBar;
                OnPropertyChanged("HPBar");
            }
            //MP Bar
            Bitmap mpBar = null;
            try { mpBar = new Bitmap(PrintWindow(CharMPProgressBarHandle)); } catch { }
            if (mpBar != null && !mpBar.Equals(_mpBar))
            {
                _mpBar = mpBar;
                OnPropertyChanged("MPBar");
            }

            if (_StartupExperience == 0 && _StartupGold == 0 && _StartupExperience == 0)
            {
                if (_skillPoint != string.Empty && _gold != string.Empty && _xPGained != string.Empty)
                {
                    _StartupSkill = Convert.ToDouble(_skillPoint.Replace("%", ""));
                    _StartupGold = Convert.ToDouble(_gold.Replace("%", ""));
                    _StartupExperience = Convert.ToDouble(_xPGained.Replace("%", ""));
                }
            }
            else
            {
                CalcGoldPerHour(); CalcExperiencePerHour();
            }
        }
        public static bool IsProcessbot(Process process)
        {
            if (process.ProcessName.Contains(ProcessName))
                return true;
            else
                return false;
        }
        private void SetMainWindowTitle()
        {
            if (BotAccount != null)
            {
                Win32.SetWindowText(MainWindowHandle, String.Format("{0} - {1}", BotTitle, BotAccount.charName));
            }
        }

        #region Properties
        private void UpdateProperty(IntPtr WHnd, ref string propertyToUpdate, string PropertyName)
        {
            Int32 size = Win32.SendMessage((int)WHnd, Win32.WM_GETTEXTLENGTH, 0, 0).ToInt32();
            StringBuilder data = new StringBuilder(size + 1);
            Win32.SendMessage(WHnd, Win32.WM_GETTEXT, data.Capacity, data);
            if (propertyToUpdate == null || data.ToString() != propertyToUpdate.ToString())
            {
                propertyToUpdate = data.ToString();
                if (PropertyName == "ConnectionQualityAvg" || PropertyName == "ConnectionQualityCur")
                {
                    propertyToUpdate = propertyToUpdate.Replace(" ms", "").Trim();
                }
                OnPropertyChanged(PropertyName);
            }
        }
        [Browsable(false)]
        public Process BotProcess
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
                OnPropertyChanged("BotProcess");
            }
        }
        [Browsable(false)]
        public Account BotAccount
        {
            get { return _account; }
            set 
            {
                _account = value;
                if (value != null)
                {
                    _charName = _account.charName;
                    Group = _account.Group;
                    //SetMainWindowTitle();
                }
            }
        }
        public string Group { get; set; }

        string _botVersion; 
        
        public string BotVersion
        {
            get { return _botVersion; }
        }
        [Browsable(false)]
        private int[] _charHPProgressBar = new int[3];
        private void GetCharHPProgressBar()
        {
            int[] outInt = new int[3];

            outInt[0] = Win32.SendMessage(CharHPProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, true, 0);
            outInt[1] = Win32.SendMessage(CharHPProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, false, 0);
            outInt[2] = Win32.SendMessage(CharHPProgressBarHandle, (int)Win32.ProgressBar_Cmd.PBM_GETPOS, 0, 0);

            if (outInt[0] != _charHPProgressBar[0] || outInt[1] != _charHPProgressBar[1] || outInt[2] != _charHPProgressBar[2])
            {
                _charHPProgressBar[0] = outInt[0]; _charHPProgressBar[1] = outInt[1]; _charHPProgressBar[2] = outInt[2];
                OnPropertyChanged("CharHPProgressBar");
            }
        }
        [Browsable(false)]
        public int[] CharHPProgressBar
        {
            get { return _charHPProgressBar; }
        }
        private int[] _charMPProgressBar = new int[3];
        private void GetCharMPProgressBar()
        {
            int[] outInt = new int[3];

            outInt[0] = Win32.SendMessage(CharMPProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, true, 0);
            outInt[1] = Win32.SendMessage(CharMPProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, false, 0);
            outInt[2] = Win32.SendMessage(CharMPProgressBarHandle, (int)Win32.ProgressBar_Cmd.PBM_GETPOS, 0, 0);
            if (outInt[0] != _charMPProgressBar[0] || outInt[1] != _charMPProgressBar[1] || outInt[2] != _charMPProgressBar[2])
            {
                _charMPProgressBar[0] = outInt[0]; _charMPProgressBar[1] = outInt[1]; _charMPProgressBar[2] = outInt[2];
                OnPropertyChanged("CharMPProgressBar");
            }
        }
        [Browsable(false)]
        public int[] CharMPProgressBar
        {
            get { return _charMPProgressBar; }
        }
        private int[] _charExpProgressBar = new int[3];
        private void GetCharExpProgressBar()
        {
            int[] outInt = new int[3];

            outInt[0] = Win32.SendMessage(CharExpProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, true, 0);
            outInt[1] = Win32.SendMessage(CharExpProgressBarHandle, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, false, 0);
            outInt[2] = Win32.SendMessage(CharExpProgressBarHandle, (int)Win32.ProgressBar_Cmd.PBM_GETPOS, 0, 0);

            if (outInt[0] != _charExpProgressBar[0] || outInt[1] != _charExpProgressBar[1] || outInt[2] != _charExpProgressBar[2])
            {
                _charExpProgressBar[0] = outInt[0]; _charExpProgressBar[1] = outInt[1]; _charExpProgressBar[2] = outInt[2];
                OnPropertyChanged("CharExpProgressBar");
            }
        }
        private Bitmap _hpBar;
        public Bitmap HPBar
        {
            get
            {
                return _hpBar;
            }
            
        }
        private Bitmap _mpBar;
        public Bitmap MPBar
        {
            get
            {
                return _mpBar;
            }

        }

        [Browsable(false)]
        public int[] CharExpProgressBar
        {
            get { return _charExpProgressBar; }
        }
        string _botServerStatus;
        [Browsable(false)]
        public string BotServerStatus
        {
            get { return _botServerStatus; }
        }
        string _silkroadServerStatus;
        public string SilkroadServerStatus
        {
            get { return _silkroadServerStatus; }
        }
        string _botStatus;
        public string BotStatus
        {
            get { return _botStatus; }
        }
        string _connectionQualityAvg;
        public int ConnectionQualityAvg
        {
            get
            {
                int avg = 0;
                Int32.TryParse(_connectionQualityAvg, out avg);
                return avg;
            }
        }
        string _connectionQualityCur;
        public int ConnectionQualityCur
        {
            get
            {
                int cur = 0;
                Int32.TryParse(_connectionQualityCur, out cur);
                return cur;
            }
        }
        string _posX;
        public string PosX
        {
            get { return _posX; }
        }
        string _posY;
        public string PosY
        {
            get { return _posY; }
        }
        string _charName;
        public string CharName
        {
            get { return _charName; }
        }
        string _level;
        public string Level
        {
            get { return _level; }
        }
        string _gold;
        public int Gold
        {
            get
            {
                int output = 0;
                int.TryParse(_gold, out output);
                return Convert.ToInt32(output);
            }
        }
        string _skillPoint;
        public int SkillPoint
        {
            get
            {
                int output = 0;
                int.TryParse(_skillPoint, out output);
                return Convert.ToInt32(output);
            }
        }
        string _locationName;
        public string LocationName
        {
            get { return _locationName; }
        }
        string _totaltime;
        public string Totaltime
        {
            get { return _totaltime; }
        }
        string _kills;
        public string Kills
        {
            get { return _kills; }
        }
        string _xPGained;
        public string XPGained
        {
            get { return _xPGained; }
        }
        string _xPMin;
        public string XPMin
        {
            get { return _xPMin; }
        }
        string _xPH;
        public string XPH
        {
            get { return _xPH; }
        }
        string _sPGained;
        public string SPGained
        {
            get { return _sPGained; }
        }
        string _sPMin;
        public string SPMin
        {
            get { return _sPMin; }
        }
        string _sPH;
        public string SPH
        {
            get { return _sPH; }
        }
        string _died;
        public string Died
        {
            get { return _died; }
        }
        string _diedsess;
        public string Diedsess
        {
            get { return _diedsess; }
        }
        string _itemDrops;
        public string ItemDrops
        {
            get { return _itemDrops; }
        }
        string _goldLoop;
        public string GoldLoop
        {
            get { return _goldLoop; }
        }
        string _btnResetStatus;
        public string BtnResetStatus
        {
            get { return _btnResetStatus; }
        }
        string _btnSaveSettings;
        public string BtnSaveSettings
        {
            get { return _btnSaveSettings; }
        }
        string _btnHieClient;
        public string BtnHieClient
        {
            get { return _btnHieClient; }
        }
        string _btnStartTraining;
        public string BtnStartTraining
        {
            get { return _btnStartTraining; }
        }
        string _btnStopTraining;
        public string BtnStopTraining
        {
            get { return _btnStopTraining; }
        }
        private List<string> _StatusLogList = new List<string>();
        [Browsable(false)]
        public List<string> StatusLogList
        {
            get
            { return _StatusLogList; }
        }
        
        private void CalcGoldPerHour()
        {
            if (_gold == string.Empty)
                return;
            TimeSpan ts = DateTime.Now.Subtract(StartupTime);
            double gained = Convert.ToDouble(_gold) - _StartupGold;
            int NewGoldPetHour = 0;
            if (gained > 0)
                NewGoldPetHour = Convert.ToInt32((gained / ts.TotalSeconds) * 60 * 60);
            //GoldPetHour = Misc.FormateNumber(NewGoldPetHour);
            GoldPetHour = NewGoldPetHour;
            OnPropertyChanged("GoldPetHour");
        }
        public int GoldPetHour
        {
            get;
            private set;
        }
        private void CalcExperiencePerHour()
        {
            if (_xPGained == string.Empty)
                return;
            TimeSpan ts = DateTime.Now.Subtract(StartupTime);
            double gained = Convert.ToDouble(_xPGained.Replace("%", "")) - _StartupExperience;
            int NewExperiencePetHour = 0;
            if (gained > 0)
                NewExperiencePetHour = Convert.ToInt32((gained / ts.TotalSeconds) * 60 * 60);
            //ExperiencePetHour = Misc.FormateNumber(NewExperiencePetHour);
            ExperiencePetHour = NewExperiencePetHour.ToString();
            OnPropertyChanged("ExperiencePetHour");
        }
        public string ExperiencePetHour
        {
            get;
            private set;
        }

        private int _TryConnectCount;
        [Browsable(false)]
        public int TryConnectCount
        {
            get { return _TryConnectCount; }
        }

        //private List<string> _ClientlessLoginLogList = new List<string>();
        //public StatusType LastStatus
        //{
        //    get
        //    {
        //        if (_ClientlessLoginLogList.Count == 0)
        //        {
        //            if (_process == null || _process.HasExited)
        //                return StatusType.Ibot_Process_Terminated;
        //            else
        //                return StatusType.Unknown;
        //        }
        //        else
        //            return ClientlessLoginLogAnalysis(_ClientlessLoginLogList[_ClientlessLoginLogList.Count - 1]);
        //    }
        //}
        [Browsable(false)]
        public int CharInventoryFreeSlot { get; set; }
        private List<string> _CharInventor = new List<string>();
        [Browsable(false)]
        public List<string> CharInventory
        {
            get
            { return _CharInventor; }
        }
        [Browsable(false)]
        public int PetInventoryFreeSlot { get; set; }
        private List<string> _PetInventor = new List<string>();
        [Browsable(false)]
        public List<string> PetInventory
        {
            get
            { return _PetInventor; }
        }
        [Browsable(false)]
        public StatusType Status
        {
            get { return _status; }
        }

        public bool Visable
        {
            get { return Win32.IsWindowVisible(MainWindowHandle.ToInt32()); }
            set
            {
                if (value)
                    MainWindowStyle(Win32.WindowShowStyle.Show);
                else
                    MainWindowStyle(Win32.WindowShowStyle.Hide);
                OnPropertyChanged("Visable");
            }
        }

        // Create the OnPropertyChanged method to raise the event 
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(name));
                //handler(this, new PropertyChangedEventArgs(name));
            }
            //Update Status
            if (name == "SilkroadServerStatus")
            {
                StatusType NewStatusType = StatusAnalysis(SilkroadServerStatus);
                if (_status != NewStatusType)
                {
                    _status = NewStatusType;
                    OnPropertyChanged("Status");
                    if (StateChanged != null)
                        StateChanged(this, _status);
                }
            }
            else if (name == "BotStatus")
            {
                StatusType NewStatusType = StatusAnalysis(BotStatus);
                if (_status != NewStatusType)
                {
                    _status = NewStatusType;
                    OnPropertyChanged("Status");
                    if (StateChanged != null)
                        StateChanged(this, _status);
                }
            }
        }
        # endregion

        private StatusType StatusAnalysis(string stateString)
        {
            stateString = stateString.Trim();
            StatusType typ = StatusType.Nothing;
            if (stateString.Length == 0)
                return typ;
            //string data = stateString.Substring(11);
            switch (stateString)
            {
                case "none":
                case "Disconnected":
                case "Connecting":
                    typ = StatusType.Disconnected;
                    break;
                case "Resolving hosts...":
                case "Checking for updates":
                case "Checking for updates...":
                case "Check finished":
                case "Logged in":
                case "Gameserver login":
                case "Connected":
                    typ = StatusType.Try_to_login;
                    break;
                case "Login success":
                case "Spawned":
                case "Go to trainplace":
                case "Arrived trainplace":
                    typ = StatusType.Online;
                    break;
                default://
                    typ = StatusType.Online;
                    //Program.Logger.AddLog(Log.LogType.Error, Log.LogLevel.Stander, string.Format("[{0}]- Unknown Status: " + stateString, CharName));
                    break;
            }
            if ((typ == StatusType.Disconnected || typ == StatusType.Try_to_login) && _account != null)
                LoginTimerStart();
            else if (typ == StatusType.Online && _status != StatusType.Online && _account != null)
                LoginTimerEnd();
            return typ;
        }

        private void GetCharInventory()
        {
            bool InvChanded = false;
            Int32 size = Win32.SendMessage((int)InventoryGridRowsHandle, Win32.CB_GETCOUNT, 0, 0).ToInt32();
            if (_CharInventor.Count == 0)
                _CharInventor = new List<string>(new string[size]);

            CharInventoryFreeSlot = 0;
            for (int i = 0; i < size; i++)
            {
                int strLen = Win32.SendMessage((int)InventoryGridRowsHandle, Win32.CB_GETLBTEXTLEN, i, 0).ToInt32();
                StringBuilder text = new StringBuilder(255);
                Win32.SendMessage(InventoryGridRowsHandle, Win32.CB_GETLBTEXT, i, text);
                if (text.ToString() != _CharInventor[i])
                    InvChanded = true;
                _CharInventor[i] = text.ToString();
                if (text.ToString() == EmptySlotTitle)
                    CharInventoryFreeSlot++;
            }
            if (InvChanded)
            {
                Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, "Char Inv Changed");
                OnPropertyChanged("CharInventory");
            }
        }
        private void GetPetInventory()
        {
            //bool InvChanded = false;
            //Int32 size = Win32.SendMessage((int)PetInvListHandle, Win32.CB_GETCOUNT, 0, 0).ToInt32();
            //if (_PetInventor.Count == 0)
            //    _PetInventor = new List<string>(new string[size]);
            //PetInventoryFreeSlot = 0;
            //for (int i = 0; i < size; i++)
            //{
            //    int strLen = Win32.SendMessage((int)PetInvListHandle, Win32.CB_GETLBTEXTLEN, i, 0).ToInt32();
            //    StringBuilder text = new StringBuilder(255);
            //    Win32.SendMessage(PetInvListHandle, Win32.CB_GETLBTEXT, i, text);
            //    if (text.ToString() != _PetInventor[i])
            //        InvChanded = true;
            //    _PetInventor[i] = text.ToString();
            //    if (text.ToString() == EmptySlotTitle)
            //        PetInventoryFreeSlot++;
            //}
            //if (InvChanded)
            //    OnPropertyChanged("PetInventory");
        }

        private void AddStatusLogListItem(string item)
        {
            _StatusLogList.Add(item);
            if (LogAdded != null)
                LogAdded(this, item);// Rise event LogAdded
            //Log Ayalysis
            if (item.Contains(BotStuck_NPC))
            {
                Program.Logger.AddLog(Log.LogType.Error, Log.LogLevel.Stander, string.Format("[{0}]- Stuck while Deal with NPC ... ", CharName));
                if (_process == null || _process.HasExited || _account == null)
                    return;
                PerformRestartBot();
            }
        }
        
        private void GetStatusLogList()
        {
            Int32 size = Win32.SendMessage((int)BotLogsHandle, Win32.WM_GETTEXTLENGTH, 0, 0).ToInt32();
            if (_LastLogLength == 0)
            {
                _LastLogLength = size;
                return;
            }
            if (_LastLogLength == size)
                return;
            StringBuilder data = new StringBuilder(size + 1);
            Win32.SendMessage(BotLogsHandle, Win32.WM_GETTEXT, data.Capacity, data);
            if (data.Length < _LastLogLength)
            {
                _LastLogLength = data.Length;
                return;
            }
            AddStatusLogListItem(data.ToString().Substring(_LastLogLength).Trim());
            _LastLogLength = size;
        }

        private IntPtr FindMainWindowInProcess(string compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;

            foreach (ProcessThread t in _process.Threads)
            {
                windowHandle = FindMainWindowInThread(t.Id, compareTitle);
                if (windowHandle != IntPtr.Zero)
                {
                    break;
                }
            }

            return windowHandle;
        }
        private static IntPtr FindMainWindowInThread(int threadId, string compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            Win32.EnumThreadWindows(threadId, (hWnd, lParam) =>
            {
                StringBuilder text = new StringBuilder(200);
                Win32.GetWindowText(hWnd, text, 200);
                if (text.ToString().Contains(compareTitle))
                {
                    windowHandle = hWnd;
                    return false;
                }
                else
                    return true;
            }, IntPtr.Zero);

            return windowHandle;
        }
        public void MainWindowStyle(Win32.WindowShowStyle style)
        {
            Win32.ShowWindowAsync(MainWindowHandle, style);
            //ShowWindow(MainWindowHandle, SW_HIDE);
            //ShowWindow(MainWindowHandle, SW_SHOWNORMAL);
            //SendMessage(MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
        }

        public System.IO.MemoryStream PrintWindow(IntPtr hWnd)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Core.RECT rc;
            Win32.GetWindowRect(hWnd, out rc);
            if (rc.Width == 0 || rc.Height == 0)
                return ms;
            using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                using (Graphics gfxBmp = Graphics.FromImage(bmp))
                {
                    //Win32.SendMessage(hwnd, Win32.WM_ERASEBKGND, gfxBmp.GetHdc().ToInt32(), 0);
                    //gfxBmp.ReleaseHdc();
                    IntPtr hdcBitmap = gfxBmp.GetHdc();
                    try
                    {
                        Win32.PrintWindow(hWnd, hdcBitmap, 2);
                    }
                    finally
                    {
                        gfxBmp.ReleaseHdc(hdcBitmap);
                    }
                }
                
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms;
            }
            //System.Drawing.Rectangle rctForm = System.Drawing.Rectangle.Empty;
            //using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromHdc(Win32.GetWindowDC(hwnd)))
            //{
            //    rctForm = System.Drawing.Rectangle.Round(grfx.VisibleClipBounds);
            //}
            //System.Drawing.Bitmap pImage = new System.Drawing.Bitmap(rctForm.Width, rctForm.Height);
            //System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pImage);
            //IntPtr hDC = graphics.GetHdc();
            ////paint control onto graphics using provided options        
            //try
            //{
            //    PrintWindow(hwnd, hDC, (uint)0);
            //}
            //finally
            //{
            //    graphics.ReleaseHdc(hDC);
            //}
            ////return pImage;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //pImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //return ms;
        }

        private Process Runbot()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(BotAccount.BotFilePath, BotAccount.CommandLineArg)
            {
                WorkingDirectory = BotAccount.BotFilePath.Substring(0, BotAccount.BotFilePath.LastIndexOf(Convert.ToChar("\\")))
            };
            process.Start();
            process.WaitForInputIdle();
            return process;
        }
        public void Start()
        {
            if (_process == null)
            {
                _process = Runbot();
                _process.Exited += _process_Exited;
                System.Threading.ThreadPool.QueueUserWorkItem((o) => 
                {
                    if (_process.HasExited)
                        return;
                        IntPtr wHnd = FindMainWindowInProcess(SBot.BotTitle);
                    while (!Win32.IsWindowVisible(wHnd.ToInt32()))
                        System.Threading.Thread.Sleep(3000);
                    PrepareHandlers();
                    //this._status = StatusType.Nothing;
                    PlusTimerStart();
                    Visable = false;
                    LoginTimerStart();//Timer if bot stuck in logging
                });
            }
            else
            {
                _process.Exited += _process_Exited;
                PlusTimerStart();
                Visable = false;
            }
            
        }
        public void Stop()
        {
            lock (this)
            {
                Dispose();
            }
        }
        private void PerformClick(IntPtr hwnd)
        {
            Win32.SendMessage(hwnd, Win32.WM_SETFOCUS, 0, 0);
            Win32.SendMessage(hwnd, Win32.BM_CLICK, 0, 0);
        }
        public void ClickStartGameButton()
        {
            PerformClick(BtnStartGameHandle);
        }
        public void ClickGoClienlessButton()
        {
            PerformClick(BtnGoClientlessHandle);
        }
        public void ClickDisconnectButton()
        {
            PerformClick(BtnDisconnectHandle);
        }
        public void ClickResetButton()
        {
            PerformClick(BtnResetStatusHandle);
        }
        public void ClickSaveSettingsButton()
        {
            PerformClick(BtnSaveSettingsHandle);
        }
        public void ClickShowHideClientButton()
        {
            PerformClick(BtnHieClientHandle);
        }
        public void ClickStartTrainingButton()
        {
            PerformClick(BtnStartTrainingHandle);
        }
        public void ClickStopTrainingButton()
        {
            PerformClick(BtnStopTrainingHandle);
        }
        public void PerformRestartBot()
        {
            if (_process != null && !_process.HasExited)
            {
                _process.Kill();
                _process.WaitForExit();
            }
            //Start();
        }

        void _process_Exited(object sender, EventArgs e)
        {
            //AddClientlessLoginLogItem("[00:00:00] " + botTerminatedString);
            _status = StatusType.bot_Process_Terminated;
            OnPropertyChanged("Status");
            if (StateChanged != null)
                StateChanged(this, _status);
        }
        
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                PlusTimerEnd();
                LoginTimerEnd();
                if (_process != null)
                {
                    _process.Exited -= _process_Exited;
                    if (!_process.HasExited)
                        _process.Kill();
                    _process.Dispose();
                    _process = null;
                }
                //_ClientlessLoginLogList.Clear();
                _StatusLogList.Clear();
                _CharInventor.Clear();
                _PetInventor.Clear();
            }
        }
        ~SBot()
        {
            Dispose(false);
        }
        # endregion
    }
}
