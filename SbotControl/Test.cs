using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SbotControl
{
    public static class Test
    {
        public static void GetStartedBots()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (!process.MainWindowTitle.Contains(SBot.BotTitle))
                {
                    continue;
                }
                
                
                IntPtr windowHandle = FindMainWindowInProcess(SBot.BOTPROOF, process);
                if (windowHandle != IntPtr.Zero)
                {
                    break;
                }
            }
        }
        private static IntPtr FindMainWindowInProcess(string compareTitle, Process pro)
        {
            IntPtr windowHandle = IntPtr.Zero;

            foreach (ProcessThread t in pro.Threads)
            {
                windowHandle = FindMainWindowInThread(t.Id, compareTitle);
                if (windowHandle != IntPtr.Zero)
                {
                    break;
                }
            }

            return windowHandle;
        }
        private static IntPtr FindMainWindowInThread(int threadId, string compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            Win32.EnumThreadWindows(threadId, (hWnd, lParam) =>
            {
                StringBuilder text = new StringBuilder(200);
                Win32.GetWindowText(hWnd, text, 200);
                if (text.ToString().Contains(SBot.BotTitle))
                {
                    windowHandle = hWnd;
                    return false;
                }
                else
                    return true;
            }, IntPtr.Zero);

            return windowHandle;
        }

        const int WM_USER = 0x400;
        const int PBM_SETSTATE = WM_USER + 16;
        const int PBM_GETSTATE = WM_USER + 17;
        public const int PBM_GETPOS = 0x0408;

        public static void XXX()
        {
            int[] outInt = new int[3];
            //IntPtr HWnd = new IntPtr(0x000567BC);//Sbot
            IntPtr HWnd = new IntPtr(0x007962AC);
            
            object obj1 = Win32.SendMessage(HWnd, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, true, 0);
            object obj2 = Win32.SendMessage(HWnd, (uint)Win32.ProgressBar_Cmd.PBM_GETRANGE, false, 0);
            object obj3 = Win32.SendMessage(HWnd, (int)Win32.ProgressBar_Cmd.PBM_GETPOS, 0, 0);

            //StringBuilder data = new StringBuilder(100 + 1);
            //object xxx = Win32.SendMessage(HWnd, PBM_GETPOS, 0, 0).ToString();
            //object xxx = Win32.SendMessage(HWnd, Win32.WM_GETTEXT, 0, 0);
        }

    }
}
