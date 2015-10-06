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
        public static Manager.CtrLayoutManager LM;
        public static Log Logger = new Log();
        public static Core.db dbOperations;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.SkinName;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            DevExpress.Utils.Drawing.Helpers.Win32SubclasserException.Allow = false;
            Init();
            try
            {
                //Test();
                bool AutoStart = false;
                foreach (string item in Args)
                {
                    if (item == "AutoStart")
                        AutoStart = true;
                }
                Application.Run(new AppMainFrm(AutoStart));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbOperations.SaveToEx("Program", ex.Message, ex.StackTrace);
            }
        }
        static void Init()
        {
            DM = new DataManager();
            BM = new BotsManager(DM);
            LM = new Manager.CtrLayoutManager(DataManager.LayoutDataPath);
            //DM.LoadServerList();
            DM.LoadSettings();
            dbOperations = new Core.db();
        }
        public static void AddRemoveStartup(bool AddReg)
        {
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (AddReg)
            {
               add.SetValue(Application.ProductName, "\"" + Application.ExecutablePath.ToString() + "\" AutoStart");
            }
            else
            {
                if (add.GetValue(Application.ProductName) != null)
                    add.DeleteValue(Application.ProductName);
            }
        }
        private  static void Test()
        {
            MessageBox.Show(Environment.NewLine.ToString());
            string x = @"r. 
[20:02:00] * Weapon switching failed! Trying again later.";

            foreach (char item in x)
            {
                MessageBox.Show(Convert.ToString(item));
            }
        }

    }
}
