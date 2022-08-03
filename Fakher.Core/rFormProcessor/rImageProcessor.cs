using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Accusoft.ScanFixXpressSdk;

namespace rFormProcessor
{
    public static class rImageProcessor
    {
        public static Bitmap Rotate(Bitmap bitmap, float angle)
        {
            Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics gr = Graphics.FromImage(bmp);
            Matrix matrix = new Matrix();
            matrix.Rotate(angle);
            gr.Transform = matrix;
            gr.Clear(Color.White);
            gr.DrawImage(bitmap, 0, 0, bmp.Width, bmp.Height);
            gr.Dispose();
            GC.Collect();
            return bmp;
        }
    }
}