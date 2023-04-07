namespace MaxFiler.Palette;

internal static class ColorHistogram
{
    public static void getTopColors(string filename, int maxColors = 32)
    {
        using (var image = new MagickImage(filename))
        {
            QuantizeSettings _QuantizeSettings = new QuantizeSettings();
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
