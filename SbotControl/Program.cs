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
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Visual Studio 2013 Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            DevExpress.Utils.Drawing.Helpers.Win32SubclasserException.Allow = false;
            Init();
            try
            {
                //Application.Run(new MainFrm());
                //new OutputFrm().Show();

                Application.Run(new AppMainFrm());

                //Test.XXX();
                
                //MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                DataManager.AddEx(ex, "Program");
                //Application.Restart();
            }
        }
        static void Init()
        {
            DM = new DataManager();
            BM = new BotsManager();
            //DM.LoadServerList();
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
