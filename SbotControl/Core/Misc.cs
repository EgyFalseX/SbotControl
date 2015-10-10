using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SbotControl
{
    class Misc
    {
        public static string FormateNumber(object str)
        {
            if (str.ToString() == string.Empty)
                return "0";
            double value = Convert.ToDouble(str);
            
            if (value < 1000)// Displays 1,234,567,890 
            {
                return value.ToString("#,#", CultureInfo.InvariantCulture);
            }
            else if (value < 1000000)// Displays 1,234,568K
            {
                //return value.ToString("#,##0,K", CultureInfo.InvariantCulture);
                return string.Format("{0} K", Math.Round(value / 1000, 3));
            }
            else if (value < 1000000000)// Displays 1,235M
            {
                //return value.ToString("#,##0,,M", CultureInfo.InvariantCulture);
                return string.Format("{0} M", Math.Round(value / 1000000, 3));
            }
            else// Displays 1B
            {
                //return value.ToString("#,##0,,,B", CultureInfo.InvariantCulture);
                return string.Format("{0} B", Math.Round(value / 1000000000, 3));
            }

        }
        public static ulong ConvertoToULong(byte[] buffer)
        {
            int pos = 0;
            ulong result = 0;
            foreach (byte byt in buffer)
            {
                result += (ulong)(byt << pos);
                pos += 8;
            }
            return result;
        }
        public static long ConvertoToLong(byte[] buffer)
        {
            return BitConverter.ToInt64(buffer, 0);
        }
         public uint COLORREF(Color color)
         {
             return (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
         }
         public uint COLORREF(uint r, uint g, uint b)
         {
             return r + (g << 8) + (b << 16);
         }
         public Color GetColor(uint ColorDWORD)
         {
            return Color.FromArgb((int)(0x000000FFU & ColorDWORD), (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
         }
         public uint SetColor(Color color)
         {
             return (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
         }

         public class ProgressBarEx : ProgressBar
         {
             public ProgressBarEx()
             {
                 this.SetStyle(ControlStyles.UserPaint, true);
             }
             protected override void OnPaint(PaintEventArgs e)
             {
                 LinearGradientBrush brush = null;

                 Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

                 if (ProgressBarRenderer.IsSupported)
                     ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

                 rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
                 rec.Height -= 4;
                 brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
                 e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
             }
         }

         public class ProgressBarEx2 : ProgressBar
         {
             public int Percentage { get; set; }
             public bool ShowText { get; set; }
             public new int Value
             {
                 get { return this.Percentage; }
                 set
                 {
                     this.Percentage = value;
                     this.Invalidate();
                 }
             }
             public ProgressBarEx2()
             {
                 this.SetStyle(ControlStyles.UserPaint, true);
                 this.DoubleBuffered = true;
             }
             protected override void OnPaint(PaintEventArgs e)
             {
                 try
                 {
                     Rectangle rec = e.ClipRectangle;
                     rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
                     if (ProgressBarRenderer.IsSupported)
                         ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
                     else
                         e.Graphics.DrawRectangle(Pens.Gray, 0, 0, this.Width, this.Height);
                     rec.Height = rec.Height - 4;
                     LinearGradientBrush brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
                     e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
                     if (this.ShowText)
                     {
                         using (SolidBrush sb = new SolidBrush(Color.Black))
                         {
                             SizeF sz = e.Graphics.MeasureString(Percentage.ToString() + " %", this.Font);
                             e.Graphics.DrawString(Percentage.ToString() + " %", this.Font, sb,
                              new PointF((this.Width - sz.Width) / 2F, (this.Height - sz.Height) / 2F));
                         }
                     }
                 }
                 catch 
                 { }
                
             }
         }

    }
}
