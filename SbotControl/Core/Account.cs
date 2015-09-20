﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SbotControl
{
    [Serializable]
    public class Account : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _charName;
        public string charName {
            get { return _charName; }
            set
            {
                _charName = value;
                OnPropertyChanged("charName");
            }
        }
        [Browsable(false)]
        public bool autoConnect { get; set; }
        [Browsable(false)]
        public bool hideSBot { get; set; }
        private bool _start;
        public bool Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }
        [Browsable(false)]
        public bool DCRestart { get; set; }
        [Browsable(false)]
        public bool RestartUnknowSpot { get; set; }
        private string _botFilePath;
        public string BotFilePath
        {
            get { return _botFilePath; }
            set
            {
                _botFilePath = value;
                OnPropertyChanged("IbotFilePath");
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        [Browsable(false)]
        public SBot bot { get; set; }
        [Browsable(false)]
        public string CommandLineArg
        {
            get
            {
                string command = " -s";
                return command;
            }
        }

        public Account()
        {
        }
        public Account(string AutoSelectChar, bool AutoConnect, bool HideSBot, bool start, bool dcRestart, bool scrollUnknowSpot, string ibotFilePath)
        {
            charName = AutoSelectChar;
            autoConnect = AutoConnect;
            hideSBot = HideSBot;
            Start = start;
            DCRestart = dcRestart;
            RestartUnknowSpot = scrollUnknowSpot;
            BotFilePath = ibotFilePath;
        }
        public void Dispose()
        {
            if (bot != null)
                bot = null;
        }
    }
}
