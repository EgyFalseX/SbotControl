using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Microsoft.Win32;

namespace SbotControl
{
    static class Program
    {
        public static DataManager DM;
        public static BotsManager BM;
        public static Log Logger = new Log();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            //Test.XXX();
            //return;
            Init();
            try
            { Application.Run(new MainFrm()); }
            catch { Application.Restart(); }
        }
        static void Init()
        {
            DM = new DataManager();
            BM = new BotsManager();
            DM.LoadServerList();
            DM.LoadSettings();
        }
        public static void AddRemoveStartup(bool AddReg)
        {
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (AddReg)
            {
               add.SetValue(Application.ProductName, "\"" + Application.ExecutablePath.ToString() + "\"");
            }
            else
            {
                if (add.GetValue(Application.ProductName) != null)
                    add.DeleteValue(Application.ProductName);
            }
        }

    }
}
