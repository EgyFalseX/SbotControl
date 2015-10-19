using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SbotControl.Manager
{
    public static class NotifyManager
    {
        private static DevExpress.XtraBars.Alerter.AlertControl Alert = new DevExpress.XtraBars.Alerter.AlertControl() { AutoFormDelay = 4000, AutoHeight = true };
        //private static readonly SynchronizationContext ctx = SynchronizationContext.Current;
        public enum MSG_Type
        {
            Connect,
            Disconnect,
            Died,
            UnknownBotLogin,
        }
        public static void ShowAlert(string CharName, string Msg, MSG_Type MSG)
        {
            //info.Image = Properties.Resources.Info;
            //info.Image = Properties.Resources.Exit;
            //info.Image = Properties.Resources.apply_16x16;
            
            DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo(CharName, Msg);
            switch (MSG)
            {
                case MSG_Type.Connect:
                    if (!Properties.Settings.Default.Alert_Connect_Disconnect)
                        return;
                    info.Image = Properties.Resources.apply_16x16;
                    break;
                case MSG_Type.Disconnect:
                    if (!Properties.Settings.Default.Alert_Connect_Disconnect)
                        return;
                    info.Image = Properties.Resources.Exit;
                    break;
                case MSG_Type.Died:
                    if (!Properties.Settings.Default.Alert_Died)
                        return;
                    info.Image = Properties.Resources.Info;
                    break;
                case MSG_Type.UnknownBotLogin:
                    info.Image = Properties.Resources.Exit;
                    break;
                default:
                    break;
            }
            if (Application.OpenForms.Count == 0)
                return;
            Application.OpenForms[0].Invoke(new MethodInvoker(() => { Alert.Show(Application.OpenForms[0], info); }));
        }
    }
}
