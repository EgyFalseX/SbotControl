using System;
using System.Collections.Generic;

using System.Text;

namespace SbotControl
{
    [Serializable]
    public class Account
    {
        public string charName { get; set; }
        public bool autoConnect { get; set; }
        public bool hideSBot { get; set; }
        public bool Start { get; set; }
        public bool DCRestart { get; set; }
        public bool RestartUnknowSpot { get; set; }
        public string IbotFilePath { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public SBot bot { get; set; }
        
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
            IbotFilePath = ibotFilePath;
        }

        public string CommandLineArg
        {
            get
            {
                string command = string.Empty;
                return command;
            }
        }

    }
}
