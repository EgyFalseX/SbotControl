using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbotControl.Core
{
    public class BotLogUnit
    {
        public string CharName { get; set; }
        public string Time { get; set; }
        public string LogData { get; set; }
        public BotLogUnit()
        {

        }
        public BotLogUnit(string charname, string time, string logdata)
        {
            CharName = charname;
            Time = time;
            LogData = logdata;
        }
    }
}
