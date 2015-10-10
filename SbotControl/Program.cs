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
            try
            {
                //Test.ReadMemoryAddress(1);
                //return;

                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.SkinName;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                DevExpress.Utils.Drawing.Helpers.Win32SubclasserException.Allow = false;
                Init();

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
            try
            {
                DM = new DataManager();
                BM = new BotsManager(DM);
                LM = new Manager.CtrLayoutManager(DataManager.LayoutDataPath);
                //DM.LoadServerList();
                DM.LoadSettings();
                dbOperations = new Core.db();
            }
            catch (Exception ex)
            { dbOperations.SaveToEx("Program", ex.Message, ex.StackTrace);}
        }
        public static void AddRemoveStartup(bool AddReg)
        {
            try
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
            catch (Exception ex)
            { dbOperations.SaveToEx("Program", ex.Message, ex.StackTrace); }
        }
        

    }
}
