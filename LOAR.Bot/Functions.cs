using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AutoIt;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace LOAR.Bot
{
    class Func
    {
        public static string Main_Window = "Browser_Random_3425";
        public static string Main_Window_Class = "Browser_Random_3425";
        public static string Main_Control = "[CLASS:GeckoFPSandboxChildWindow; INSTANCE:1]";

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static Rectangle Search_Bitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            BitmapData smallData =
              smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData =
              bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;
        }

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        public static System.Drawing.Bitmap Capture_Window(IntPtr hWnd)
        {
            System.Drawing.Rectangle rctForm = System.Drawing.Rectangle.Empty;
            using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromHdc(GetWindowDC(hWnd)))
            {
                rctForm = System.Drawing.Rectangle.Round(grfx.VisibleClipBounds);
            }
            System.Drawing.Bitmap pImage = new System.Drawing.Bitmap(rctForm.Width, rctForm.Height);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pImage);
            IntPtr hDC = graphics.GetHdc();
            //paint control onto graphics using provided options        
            try
            {
                PrintWindow(hWnd, hDC, (uint)0);
            }
            finally
            {
                graphics.ReleaseHdc(hDC);
            }
            return pImage;
        }

        public static Point _Image_Search_EX(string Image, string Window, string Control, double Tolerance = 0)
        {
            //  ليه الخاصية دي مش بتشتغل الا على زر ال 1 .. لأن أنا مش بغير ال ماين كنترول لما أجي أجربها
            _WinSetStyle_To_POPUP(Window);
            Rectangle Location = Rectangle.Empty;
            Bitmap Image_BMP = new Bitmap(Image);
            IntPtr Window_Hwnd = Func.FindWindow(null, Window);
            Bitmap Window_BMP = Func.Capture_Window(Window_Hwnd);
            //Window_BMP.Save("test.bmp");
            Tolerance = Tolerance / 100;
            Location = Func.Search_Bitmap(Image_BMP, Window_BMP, Tolerance);
            //MessageBox.Show(Location.ToString());
            Image_BMP.Dispose();
            Window_BMP.Dispose();
            Point Coords = new Point(Location.X + (Location.Width / 2), Location.Y + (Location.Height / 2));
            Rectangle Control_Pos = AutoItX.ControlGetPos(Main_Window, "", Main_Control);
            Point Pos = new Point(Coords.X - Control_Pos.X - (Control_Pos.Width / 2), Coords.Y - Control_Pos.Y - (Control_Pos.Height / 2));
            return Pos;
        }


        
        //Import window changing function
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /*
        //Import find window function
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        */

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);


        public const int GWL_STYLE = -16;              //hex constant for style changing
        public const int GWL_EXSTYLE = -20;              //hex constant for Exstyle changing
        public const int WS_BORDER = 0x00800000;       //window with border
        public const int WS_CAPTION = 0x00C00000;      //window with a title bar
        public const int WS_SYSMENU = 0x00080000;      //window with no borders etc.
        public const int WS_MINIMIZEBOX = 0x00020000;  //window with minimizebox
        public static void _WinSetStyle_To_POPUP(string WINDOW_Title_Or_Class)
        {
            IntPtr Hwnd = AutoItX.WinGetHandle(WINDOW_Title_Or_Class);
            SetWindowLong(Hwnd, GWL_STYLE, WS_SYSMENU);
            SetWindowPos(Hwnd, 0, 0, 0, 0, 0, 71);
        }









        public static Point _Click(string Image, double Tolerance = 0)
        {
            Point point = Func._Image_Search_EX(Image, Main_Window, Main_Control, Tolerance);
            AutoItX.ControlClick(Main_Window, "", Main_Control, "Primary", 1, point.X, point.Y);
            return point;

        }


        public static IntPtr FindWindow(object p, string window)
        {
            throw new NotImplementedException();
        }


        public static Image Crop_Image(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }






    }

}
