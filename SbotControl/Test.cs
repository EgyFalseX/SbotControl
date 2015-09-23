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

        public static void PrintTest()
        {
            //IntPtr Whnd = new IntPtr(276868);
            ////IntPtr Whnd = new IntPtr(6104784);
            //using (System.Drawing.Bitmap screenshot = new System.Drawing.Bitmap(320, 240))
            //using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(screenshot))
            //{
            //    g.FillRectangle(System.Drawing.SystemBrushes.Control, 0, 0, screenshot.Width, screenshot.Height);
            //    try
            //    {
            //        //Win32.SendMessage(Whnd, Win32.WM_PRINT, g.GetHdc().ToInt32(), (int)(Win32.DrawingOptions.PRF_CHILDREN | Win32.DrawingOptions.PRF_CLIENT | Win32.DrawingOptions.PRF_OWNED));
            //        int xxxx =Win32.SendMessage(Whnd, Win32.WM_PRINT, g.GetHdc().ToInt32(), (int)(Win32.DrawingOptions.PRF_CLIENT | Win32.DrawingOptions.PRF_CHILDREN | Win32.DrawingOptions.PRF_NONCLIENT | Win32.DrawingOptions.PRF_OWNED));
            //    }
            //    finally
            //    {
            //        g.ReleaseHdc();
            //    }
            //    screenshot.Save("c:\\aaaaaaaaaaa.bmp");
            //    System.Windows.Forms.MessageBox.Show("done ...");
            //}
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        public static void WIN(IntPtr WHnd)
        {
            const int WM_NCPAINT = 0x85;

            IntPtr hdc = GetWindowDC(WHnd);
            if ((int)hdc != 0)
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromHdc(hdc);
                g.DrawLine(System.Drawing.Pens.Green, 10, 10, 100, 10);
                g.Flush();
                ReleaseDC(WHnd, hdc);
                //System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(screenshot);
            }


        }

    }
}
