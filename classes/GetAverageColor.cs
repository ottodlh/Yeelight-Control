using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YControl
{
    internal class GetAverageColor
    {
        public static Color GetColor()
        {
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                Graphics graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
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

                int avgR = r / count;
                int avgG = g / count;
                int avgB = b / count;

                return Color.FromArgb(avgR, avgG, avgB);
            }
        }
        public static Color GetDominantColor()
        {
            // Obtener la resolución de pantalla actual
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Crear un objeto Bitmap con la misma resolución que la pantalla
            Bitmap screenBitmap = new Bitmap(screenWidth, screenHeight);

            // Copiar el contenido de la pantalla al objeto Bitmap
            using (Graphics graphics = Graphics.FromImage(screenBitmap))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, screenBitmap.Size);
            }

            // Crear un diccionario para contar la frecuencia de cada color en el objeto Bitmap
            Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();
            for (int x = 0; x < screenBitmap.Width; x++)
            {
                for (int y = 0; y < screenBitmap.Height; y++)
                {
                    Color pixelColor = screenBitmap.GetPixel(x, y);
                    if (colorCounts.ContainsKey(pixelColor))
                    {
                        colorCounts[pixelColor]++;
                    }
                    else
                    {
                        colorCounts[pixelColor] = 1;
                    }
                }
            }

            // Encontrar el color con la frecuencia más alta
            Color dominantColor = Color.Black;
            int maxCount = 0;
            foreach (KeyValuePair<Color, int> colorCount in colorCounts)
            {
                if (colorCount.Value > maxCount)
                {
                    maxCount = colorCount.Value;
                    dominantColor = colorCount.Key;
                }
            }

            // Devolver el color dominante de la pantalla
            return dominantColor;
        }
    }
}
