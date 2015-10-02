using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace SbotControl
{
    public static class Test
    {
        private static IntPtr FindMainWindowInProcess(Process _process, string compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;

            foreach (ProcessThread t in _process.Threads)
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
                if (text.ToString().Contains(compareTitle))
                {
                    windowHandle = hWnd;
                    return false;
                }
                else
                    return true;
            }, IntPtr.Zero);

            return windowHandle;
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
        public static void PrintWindow(IntPtr hWnd)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Core.RECT rc;
            Win32.GetWindowRect(hWnd, out rc);
            //if (rc.Width == 0 || rc.Height == 0)
            //    return ms;
            using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                using (Graphics gfxBmp = Graphics.FromImage(bmp))
                {
                    //Win32.SendMessage(hwnd, Win32.WM_ERASEBKGND, gfxBmp.GetHdc().ToInt32(), 0);
                    //gfxBmp.ReleaseHdc();
                    IntPtr hdcBitmap = gfxBmp.GetHdc();
                    try
                    {

                        Win32.PrintWindow(hWnd, hdcBitmap, 2);
                    }
                    finally
                    {
                        gfxBmp.ReleaseHdc(hdcBitmap);
                    }
                }
                bmp.Save("C:\\pic.bmp");

                //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            }

            //System.Drawing.Rectangle rctForm = System.Drawing.Rectangle.Empty;
            //using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromHdc(Win32.GetWindowDC(hwnd)))
            //{
            //    rctForm = System.Drawing.Rectangle.Round(grfx.VisibleClipBounds);
            //}
            //System.Drawing.Bitmap pImage = new System.Drawing.Bitmap(rctForm.Width, rctForm.Height);
            //System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pImage);
            //IntPtr hDC = graphics.GetHdc();
            ////paint control onto graphics using provided options        
            //try
            //{
            //    PrintWindow(hwnd, hDC, (uint)0);
            //}
            //finally
            //{
            //    graphics.ReleaseHdc(hDC);
            //}
            ////return pImage;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //pImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //return ms;
        }
        public static void GetCharInventory()
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
            const int LVM_GETITEM = LVM_FIRST + 75;
            const int LVIF_TEXT = 0x0001;

        List<string> _CharInventor = new List<string>();
            int CharInventoryFreeSlot = 0;
            string EmptySlotTitle = "Empty";
            //163154
            //163150
            //163144
            //163138
            IntPtr InventoryGridRowsHandle = new IntPtr(163144);
            //IntPtr InventoryGridRowsHandle = new IntPtr(163136);
            //IntPtr InventoryGridRowsHandle = new IntPtr(5965556);
            bool InvChanded = false;
            Int32 size = Win32.SendMessage((int)InventoryGridRowsHandle, LVM_GETITEMCOUNT, 0, 0).ToInt32();
            if (_CharInventor.Count == 0)
                _CharInventor = new List<string>(new string[size]);
            _CharInventor = new List<string>(new string[100]);
            CharInventoryFreeSlot = 0;
            for (int i = 0; i < 100; i++)
            {
                //int strLen = Win32.SendMessage((int)InventoryGridRowsHandle, Win32.CB_GETLBTEXTLEN, i, 0).ToInt32();
                StringBuilder text = new StringBuilder(255);
                Win32.SendMessage(InventoryGridRowsHandle, Win32.CB_GETLBTEXT, i, text);
                if (text.ToString() != _CharInventor[i])
                    InvChanded = true;
                _CharInventor[i] = text.ToString();
                if (text.ToString() == EmptySlotTitle)
                    CharInventoryFreeSlot++;
            }
            if (InvChanded)
            {
                Program.Logger.AddLog(Log.LogType.Debug, Log.LogLevel.Debug, "Char Inv Changed");
                //OnPropertyChanged("CharInventory");
            }
        }
        public static void PrintWindowX()
        {
            IntPtr hWnd = new IntPtr(163138);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Core.RECT rc;
            Win32.GetWindowRect(hWnd, out rc);

            using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                using (Graphics gfxBmp = Graphics.FromImage(bmp))
                {
                    //Win32.SendMessage(hwnd, Win32.WM_ERASEBKGND, gfxBmp.GetHdc().ToInt32(), 0);
                    //gfxBmp.ReleaseHdc();
                    IntPtr hdcBitmap = gfxBmp.GetHdc();
                    try
                    {
                        Win32.PrintWindow(hWnd, hdcBitmap, 2);
                    }
                    finally
                    {
                        gfxBmp.ReleaseHdc(hdcBitmap);
                    }
                }

                //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                bmp.Save("C:\\163138.bmp");
            }
        }
        
    }

}
