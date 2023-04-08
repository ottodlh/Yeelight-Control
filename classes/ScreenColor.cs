using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YControl
{
    internal static class ScreenColor
    {
        public static Color GetAverageColor(int screenIndex = 0)
        {
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[screenIndex];
            Rectangle bounds = screen.Bounds;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                Graphics graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                graphics.Dispose();

                int r = 0;
                int g = 0;
                int b = 0;
                int count = 0;

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        r += pixel.R;
                        g += pixel.G;
                        b += pixel.B;
                        count++;
                    }
                }

                if (count == 0) return Color.Black;

                return Color.FromArgb(r / count, g / count, b / count);
            }
        }
        public static Color GetDominantColor(int screenIndex = 0)
        {
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[screenIndex];
            Rectangle bounds = screen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                Graphics graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                graphics.Dispose();

                Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        if (colorCounts.ContainsKey(pixelColor))
                        {
                            colorCounts[pixelColor]++;
                        }
                        else
                        {
                            colorCounts.Add(pixelColor, 1);
                        }
                    }
                }

                Color dominantColor = Color.Black;
                int maxCount = 0;
                foreach (KeyValuePair<Color, int> colorCount in colorCounts)
                {
                    if (colorCount.Value > maxCount)
                    {
                        dominantColor = colorCount.Key;
                        maxCount = colorCount.Value;
                    }
                }

                return dominantColor;
            }
        }
    }
}
