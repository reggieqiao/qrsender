using System.Drawing;
using ZXing;

namespace QRSender
{
    public class BitmapLuminanceSource : BaseLuminanceSource
    {
        public BitmapLuminanceSource(Bitmap bitmap) : base(bitmap.Width, bitmap.Height)
        {
            var height = bitmap.Height;
            var width = bitmap.Width;

            var rgb = new byte[height * width * 4];
            var index = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    var luminance = (byte)((color.R + color.R + color.B + color.G + color.G + color.G) / 6);
                    rgb[index++] = luminance;
                }
            }
            luminances = rgb;
        }

        public BitmapLuminanceSource(int width, int height) : base(width, height)
        {
        }

        protected override LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height)
        {
            return new BitmapLuminanceSource(width, height);
        }
    }
}
