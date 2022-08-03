using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace rTwain
{
    public class TwainImageConverter
    {
        public static BITMAPINFOHEADER bmi;
        public static Rectangle bmprect;

        public static IntPtr GetPixelInfo(IntPtr bmpptr)
        {
            bmi = new BITMAPINFOHEADER();
            bmprect = Rectangle.Empty;
            Marshal.PtrToStructure(bmpptr, bmi);

            bmprect.X = bmprect.Y = 0;
            bmprect.Width = bmi.biWidth;
            bmprect.Height = bmi.biHeight;

            if (bmi.biSizeImage == 0)
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

            int p = bmi.biClrUsed;
            if ((p == 0) && (bmi.biBitCount <= 8))
                p = 1 << bmi.biBitCount;
            p = (p * 4) + bmi.biSize + (int)bmpptr;
            return (IntPtr)p;
        }

        public static Bitmap ConvertToBitmap(IntPtr dibhandp)
        {
            IntPtr dibhand;
            IntPtr bmpptr;
            IntPtr pixptr;

            dibhand = dibhandp;
            bmpptr = GlobalLock(dibhand);
            pixptr = GetPixelInfo(bmpptr);

            Bitmap _scannedImage = new Bitmap(bmprect.Width, bmprect.Height);
            Graphics scannedImageGraphics = Graphics.FromImage(_scannedImage);

            IntPtr hdc = scannedImageGraphics.GetHdc();
            SetDIBitsToDevice(hdc, 0, 0, bmprect.Width, bmprect.Height, 0, 0, 0, bmprect.Height, pixptr, bmpptr, 0);
            scannedImageGraphics.ReleaseHdc(hdc);

            scannedImageGraphics.Dispose();
            return _scannedImage;
        }

        public static Bitmap ConvertType(Bitmap bitmap, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, format);
                return new Bitmap(stream);
            }
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }

        public static Image ConvertToThumbnail(Bitmap bitmap, int width, int height)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image thumbnailImage = bitmap.GetThumbnailImage(width, height, myCallback, IntPtr.Zero);
            return thumbnailImage;
        }

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,
            int width, int height, int xsrc, int ysrc, int start, int lines,
            IntPtr bitsptr, IntPtr bmiptr, int color);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string outstr);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public class BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    }
}