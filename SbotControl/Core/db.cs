using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace SbotControl.Core
{
    public class db
    {
        OleDbConnection con;
        OleDbCommand cmd;
        bool dbOnline = false;
        public enum LogType
        {
            BotLog,
            StatusLog
        }
        public db()
        {
            con = new OleDbConnection(Properties.Settings.Default.LogDataConnectionString);
            cmd = new OleDbCommand("", con);
            try
            {
                con.Open();
                dbOnline = true;
            }
            catch (Exception ex)
            {
                Program.Logger.AddLog(Log.LogType.Error, Log.LogLevel.Stander, ex.Message);
            }
        }
        public void SaveToLog(LogType type, string CharName, string Details)
        {
            if (!dbOnline)
                return;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                lock (cmd)
                {
                    cmd.CommandText = string.Format("INSERT INTO BotLog (log_Date, log_Type, log_CharName, log_Details) VALUES (NOW(), '{0}', '{1}', '{2}')", type.ToString(), CharName, Details);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void SaveToEx(string ExClassType, string ExMsg, string Details)
        {
            if (!dbOnline)
                return;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                lock (cmd)
                {
                    cmd.CommandText = string.Format("INSERT INTO Exception (ExDate, ExClassType, ExMsg, Details) VALUES (NOW(), '{0}', '{1}', '{1}')", ExClassType, ExMsg, Details);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}
