using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PointsDivision.Draw
{
    public static class BitmapConfig
    {
        private static readonly string fileName = "x.png";

        public static void Set(Bitmap bitmap)
        {
            bitmap.Save(fileName, ImageFormat.Png);
        }

        public static Bitmap Get()
        {
            var bitmap = new Bitmap(fileName);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return bitmap;
        }
    }
}
