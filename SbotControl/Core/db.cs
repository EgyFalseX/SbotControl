using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using JRO;
using System.IO;

namespace SbotControl.Core
{
    public class db
    {
        OleDbConnection con;
        OleDbCommand cmdLog;
        OleDbParameter ParamLog_Type;
        OleDbParameter ParamLog_Char;
        OleDbParameter ParamLog_Details;

        OleDbCommand cmdEx;
        OleDbParameter ParamExClassType;
        OleDbParameter ParamExMsg;
        OleDbParameter ParamExDetails;

        bool dbOnline = false;
        public enum LogType
        {
            BotLog,
            StatusLog
        }
        public db()
        {
            con = new OleDbConnection(Properties.Settings.Default.LogDataConnectionString);
            cmdLog = new OleDbCommand("INSERT INTO BotLog (log_Date, log_Time, log_Type, log_CharName, log_Details) VALUES (DATE(), TIME(), @log_Type, @log_CharName, @log_Details)", con);
            ParamLog_Type = new OleDbParameter("@log_Type", OleDbType.VarWChar);
            ParamLog_Char = new OleDbParameter("@log_CharName", OleDbType.VarWChar);
            ParamLog_Details = new OleDbParameter("@log_Details", OleDbType.LongVarWChar);
            cmdLog.Parameters.AddRange(new OleDbParameter[] { ParamLog_Type, ParamLog_Char, ParamLog_Details });

            cmdEx = new OleDbCommand("INSERT INTO Exception (ExDate, ExClassType, ExMsg, Details) VALUES (NOW(), @ExClassType, @ExMsg, @Details)", con);
            ParamExClassType = new OleDbParameter("@ExClassType", OleDbType.VarWChar);
            ParamExMsg = new OleDbParameter("@ExMsg", OleDbType.VarWChar);
            ParamExDetails = new OleDbParameter("@Details", OleDbType.LongVarWChar);
            cmdEx.Parameters.AddRange(new OleDbParameter[] { ParamExClassType, ParamExMsg, ParamExDetails });
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
                lock (cmdLog)
                {
                    ParamLog_Type.Value = type.ToString(); ParamLog_Char.Value = CharName; ParamLog_Details.Value = Details;
                    cmdLog.ExecuteNonQuery();
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
                lock (cmdEx)
                {
                    ParamExClassType.Value = ExClassType; ParamExMsg.Value = ExMsg; ParamExDetails.Value = Details;
                    cmdEx.ExecuteNonQuery();
                }
            }
            catch { }
        }
        /// <summary>
        /// Compacts an Access database using Microsoft JET COM
        /// interop.
        /// </summary>
        /// <param name="fileName">
        /// The filename of the Access database to compact. This
        /// filename will be mapped to the appropriate path on the
        /// web server, so use a tilde (~) to specify the web site
        /// root folder. For example, "~/Downloads/Export.mdb".
        /// The ASP.NET worker process must have been granted
        /// permission to read and write this file, as well as to
        /// create files in the folder in which this file resides.
        /// In addition, Microsoft JET 4.0 or later must be
        /// present on the server.
        /// </param>
        /// <returns>
        /// True if the compact was successful. False can indicate
        /// several possible problems including: unable to create
        /// JET COM object, unable to find source file, unable to
        /// create new compacted file, or unable to delete
        /// original file.
        /// </returns>
        public static bool CompactJetDatabase(string fileName)
        {
            // I use this function as part of an AJAX page, so rather
            // than throwing exceptions if errors are encountered, I
            // simply return false and allow the page to handle the
            // failure generically.
            try
            {
                string dbFileName = System.Windows.Forms.Application.StartupPath + "\\LogData";
                string dbTempFileName = System.Windows.Forms.Application.StartupPath + "\\LogDataN";
                // JET will not compact the database in place, so we
                // need to create a temporary filename to use
                // Obtain a reference to the JET engine
                //JetEngine engine = (JetEngine)HttpContext.Current.Server.CreateObject("JRO.JetEngine");
                JetEngine engine = (JetEngine)Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

                // Compact the database (saves the compacted version to
                // newFileName)
                engine.CompactDatabase(Properties.Settings.Default.LogDataConnectionString, Properties.Settings.Default.LogDataConnectionString.Replace("LogData", "LogDataN"));
                // Delete the original database
                File.Delete(dbFileName);
                // Move (rename) the temporary compacted database to
                // the original filename
                File.Move(dbTempFileName, dbFileName);
                // The operation was successful
                return true;
            }
            catch
            {
                // We encountered an error
                return false;
            }
        }
    }
}
