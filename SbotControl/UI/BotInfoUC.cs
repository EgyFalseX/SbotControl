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
    public partial class BotInfoUC : DevExpress.XtraEditors.XtraUserControl
    {
        Core.ThreadedBindingList<SBot> bind = new Core.ThreadedBindingList<SBot>();
        SBot _sbot;
        int _lastLogRecord = 0;
        int _logmaxsize = 1000;
        private string LogTemplate = "<p style=\"text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt;\"><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">[</span><span style=\"color:#808080;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">{0}</span><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">][</span><span style=\"color:#BFBFBF;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:bold;font-style:normal;text-decoration: underline;\">{1}</span><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">]: </span><span style=\"color:#00B050;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">{2}</span></p>";
        public BotInfoUC(SBot sbot)
        {
            InitializeComponent();
            _sbot = sbot;
        }
        private void BotInfoUC_Load(object sender, EventArgs e)
        {
            this.Disposed += BotInfoUC_Disposed;
            BindingSource bindSrc = new BindingSource();
            bind.Add(_sbot);
            bindSrc.DataSource = bind;
            //Fields Binding
            lblCharName.DataBindings.Add("Text", bindSrc, "CharName");
            ceVisable.DataBindings.Add("EditValue", bindSrc, "Visable");
            lblGroup.DataBindings.Add("Text", bindSrc, "Group");

            peHPBar.DataBindings.Add("EditValue", bindSrc, "CharHPProgressBar");
            peMPBar.DataBindings.Add("EditValue", bindSrc, "CharMPProgressBar");
            peExpBar.DataBindings.Add("EditValue", bindSrc, "CharExpProgressBar");

            lblSilkroadServerStatus.DataBindings.Add("Text", bindSrc, "SilkroadServerStatus");
            lblBotStatus.DataBindings.Add("Text", bindSrc, "BotStatus");
            lblConnectionQualityAvg.DataBindings.Add("Text", bindSrc, "ConnectionQualityAvg");
            lblConnectionQualityCur.DataBindings.Add("Text", bindSrc, "ConnectionQualityCur");
            lblPosX.DataBindings.Add("Text", bindSrc, "PosX");
            lblPosY.DataBindings.Add("Text", bindSrc, "PosY");
            lblLevel.DataBindings.Add("Text", bindSrc, "Level");
            lblGold.DataBindings.Add("Text", bindSrc, "Gold");
            lblSkillPoint.DataBindings.Add("Text", bindSrc, "SkillPoint");
            lblLocationName.DataBindings.Add("Text", bindSrc, "LocationName");
            lblTotaltime.DataBindings.Add("Text", bindSrc, "Totaltime");
            lblKills.DataBindings.Add("Text", bindSrc, "Kills");
            lblXPGained.DataBindings.Add("Text", bindSrc, "XPGained");
            lblXPMin.DataBindings.Add("Text", bindSrc, "XPMin");
            lblXPH.DataBindings.Add("Text", bindSrc, "XPH");
            lblSPGained.DataBindings.Add("Text", bindSrc, "SPGained");
            lblSPMin.DataBindings.Add("Text", bindSrc, "SPMin");
            lblSPH.DataBindings.Add("Text", bindSrc, "SPH");
            lblDied.DataBindings.Add("Text", bindSrc, "Died");
            lblDiedsess.DataBindings.Add("Text", bindSrc, "Diedsess");
            lblItemDrops.DataBindings.Add("Text", bindSrc, "ItemDrops");
            lblGoldLoop.DataBindings.Add("Text", bindSrc, "GoldLoop");
            lblGoldPetHour.DataBindings.Add("Text", bindSrc, "GoldPetHour");
            //Log Binding
            foreach (string item in _sbot.StatusLogList)
            {
                AddLog("...", item);
            }
            _sbot.LogAdded += _sbot_LogAdded;
        }
        private void _sbot_LogAdded(SBot sender, string Log)
        {
            rec.Invoke(new MethodInvoker(() =>
            {
                AddLog(DateTime.Now.ToShortDateString(), Log);
                rec.Document.CaretPosition = rec.Document.Range.End;
                rec.ScrollToCaret();
            }));
        }
        private void AddLog(string Time, string log)
        {
            rec.Invoke(new MethodInvoker(() =>
            {
                if (_lastLogRecord > _logmaxsize)
                {
                    rec.Document.HtmlText = string.Empty;
                    _lastLogRecord = 0;
                }
                rec.Document.AppendHtmlText("&#13;&#10;" + string.Format(LogTemplate, Time, _sbot.CharName, log.Replace("\n", "&#13;&#10;")));
                _lastLogRecord++;
            }));
        }
        private void BotInfoUC_Disposed(object sender, EventArgs e)
        {
            try
            {
                _sbot.LogAdded -= _sbot_LogAdded;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void beCommands_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Start Game")
                _sbot.ClickStartGameButton();
            else if (e.Button.Caption == "Go Clientless")
                _sbot.ClickGoClienlessButton();
            else if (e.Button.Caption == "Disconnect")
                _sbot.ClickDisconnectButton();
            else if (e.Button.Caption == "Resert")
                _sbot.ClickResetButton();
            else if (e.Button.Caption == "Save Settings")
                _sbot.ClickSaveSettingsButton();
            else if (e.Button.Caption == "Show/Hide Client")
                _sbot.ClickShowHideClientButton();
            else if (e.Button.Caption == "Start Training")
                _sbot.ClickStartTrainingButton();
            else if (e.Button.Caption == "End Training")
                _sbot.ClickStopTrainingButton();
        }
        
    }
}
