
using static System.Net.Mime.MediaTypeNames;

namespace MaxFiler.ColorManager
{
    internal static class ColorHistogram
    {
        public static void get(string filename, int i)
        {
            using (var image = new MagickImage(filename))
            {
                image.Resize(5, 5);
                // Получить палитру изображения
                var colors = image.Histogram().OrderByDescending(c => c.Value).Take(i);

                // Вывести наиболее часто используемые цвета
                foreach (var color in colors)
                {
                    Console.WriteLine(color.Key.ToHexString());
                    Console.WriteLine($"{color.Key.R}.{color.Key.G}.{color.Key.B}");
                }
            }
        }
        public static void getTopColors(string filename, int maxColors = 32)
        {
            using (var image = new MagickImage(filename))
            {
                var _QuantizeSettings = new QuantizeSettings();
                _QuantizeSettings.Colors = maxColors;
                _QuantizeSettings.DitherMethod = DitherMethod.Riemersma;
                image.Quantize(_QuantizeSettings);
                int pixCount = image.Height * image.Width;
                var histogram = image.Histogram();
                var colors = histogram.Where(c => c.Value > pixCount * 0.001).OrderByDescending(c => c.Value);
                foreach (var color in colors)
                {
                    Console.WriteLine($"{color.Key} : {color.Value}");
                }
            }
        }
    }
}
