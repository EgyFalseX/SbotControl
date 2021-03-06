﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Word;

namespace SbotControl.UI
{
    public partial class BotLogUC : DevExpress.XtraEditors.XtraUserControl
    {
        int _lastLogRecord = 0;
        int LogCurrentSize = 0;
        const int LogMaxSize = 1000;
        private string LogTemplate = "<p style=\"text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt;\"><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">[</span><span style=\"color:#808080;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">{0}</span><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">][</span><span style=\"color:#BFBFBF;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:bold;font-style:normal;text-decoration: underline;\">{1}</span><span style=\"color:#000000;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">]: </span><span style=\"color:#00B050;background-color:transparent;font-family:Calibri;font-size:9pt;font-weight:normal;font-style:normal;\">{2}</span></p>";
        public BotLogUC()
        {
            InitializeComponent();
            this.rec.Views.SimpleView.AllowDisplayLineNumbers = true;
        }
        private void BotLogUC_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.BM != null)
                {
                    Program.BM.ManagerStatusChanged += BM_ManagerStatusChanged;
                    BM_ManagerStatusChanged(Program.BM, Program.BM.ManagerStatus);
                }
                this.Disposed += BotLogUC_Disposed;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
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
                TmrUIBotInfo.Enabled = false;
        }
        private void TmrUIBotInfo_Tick(object sender, EventArgs e)
        {
            if (_lastLogRecord == 0 || _lastLogRecord > Program.BM.BotLogs.Count)
                _lastLogRecord = Program.BM.BotLogs.Count;
            for (int i = _lastLogRecord; i < Program.BM.BotLogs.Count; i++)
            {
                _lastLogRecord++;
                AddLog(Program.BM.BotLogs[i]);
            }
            if (ceAutoScroll.Checked)
            {
                rec.Document.CaretPosition = rec.Document.Range.End;
                rec.ScrollToCaret();
            }
        }
        private void AddLog(Core.BotLogUnit unit)
        {
            if (LogCurrentSize > LogMaxSize)
            {
                rec.Document.HtmlText = string.Empty;
                LogCurrentSize = 0;
            }
            rec.Document.AppendHtmlText("&#13;&#10;" + string.Format(LogTemplate, unit.Time, unit.CharName, unit.LogData.Replace("\n", "&#13;&#10;")));
            LogCurrentSize++;
        }
        private void BotLogUC_Disposed(object sender, EventArgs e)
        {
            try
            {
                Program.BM.ManagerStatusChanged -= BM_ManagerStatusChanged;
                TmrUIBotInfo.Tick -= TmrUIBotInfo_Tick;
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
    }
}
