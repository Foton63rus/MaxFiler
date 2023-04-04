namespace MaxFiler.ColorManager
{
    public class PaletteHistogram
    {
        public Dictionary<MagickColor, int> Rate = new Dictionary<MagickColor, int>();
        
        public PaletteHistogram(List<MagickColor> paletteColors)
        {
            foreach (var color in paletteColors)
            {
                Rate.Add(toMagickColor(color), 0);
            }
        }

        public void ImageRate(string filename)
        {
            this.CLear();
            using (var image = new MagickImage(filename))
            {
                Console.WriteLine($"pix count real: {image.GetPixels().Count()}");
                int wSize = 64; int hSize = 64;
                image.Resize(wSize, hSize);
                var pixColors = image.Histogram();
                Console.WriteLine($"pix count: {pixColors.Count}/{wSize*hSize}");
                MagickColor currentColor;
                int currentRate;
                MagickColor closestPaletteColor;
                float difference;
                
                foreach (var picColor in pixColors)
                {
                    currentColor = toMagickColor(picColor.Key);
                    currentRate = picColor.Value;
                    closestPaletteColor = null;
                    difference = 0f;
                    foreach (var palleteColor in Rate)
                    {
                        if (closestPaletteColor == null)
                        {
                            closestPaletteColor = palleteColor.Key;
                            difference = ColorDifference(closestPaletteColor, currentColor);
                        }
                        else
                        {
                            float currentDiff = ColorDifference(palleteColor.Key, currentColor);
                            if (currentDiff < difference)
                            {
                                closestPaletteColor = palleteColor.Key;
                                difference = ColorDifference(closestPaletteColor, currentColor);
                            }
                        }
                    }
                    Rate[closestPaletteColor] += currentRate;
                }
                var sortedRate = Rate.OrderBy(x => x.Value);
                foreach (var item in sortedRate)
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine($"Rate: {item.Key} - {item.Value}");
                    }
                }
            }
        }
        private MagickColor toMagickColor(IMagickColor<byte> color)
        {
            return new MagickColor(color.R, color.G, color.B);
        }
        private float ColorDifference(MagickColor color1, MagickColor color2)
        {
            return MathF.Sqrt(  (color1.R - color2.R) * (color1.R - color2.R) +
                                (color1.G - color2.G) * (color1.G - color2.G) +
                                (color1.B - color2.B) * (color1.B - color2.B));
        }
        public void CLear()
        {
            foreach (var item in Rate)
            {
                Rate[item.Key] = 0;
            }
        }
        public static List<MagickColor> getTopColorPalette()
        {
            return new List<MagickColor>()
            {
                new MagickColor(51, 0, 0),  //reds
                new MagickColor(102, 0, 0),
                new MagickColor(153, 0, 0),
                new MagickColor(204, 0, 0),
                new MagickColor(255, 0, 0),
                new MagickColor(255, 51, 51),
                new MagickColor(255, 102, 102),
                new MagickColor(255, 153, 153),
                new MagickColor(255, 204, 204),

                new MagickColor(51, 25, 0), //oranges
                new MagickColor(102, 51, 0),
                new MagickColor(153, 76, 0),
                new MagickColor(204, 102, 0),
                new MagickColor(255, 128, 0),
                new MagickColor(255, 153, 51),
                new MagickColor(255, 178, 102),
                new MagickColor(255, 204, 153),
                new MagickColor(255, 229, 204),

                new MagickColor(51, 51, 0), //yellows
                new MagickColor(102, 102, 0),
                new MagickColor(153, 153, 0),
                new MagickColor(204, 204, 0),
                new MagickColor(255, 255, 0),
                new MagickColor(255, 255, 51),
                new MagickColor(255, 255, 102),
                new MagickColor(255, 255, 153),
                new MagickColor(255, 255, 204),

                new MagickColor(25, 51, 0), //limes
                new MagickColor(51, 102, 0),
                new MagickColor(76, 153, 0),
                new MagickColor(102, 204, 0),
                new MagickColor(128, 255, 0),
                new MagickColor(153, 255, 51),
                new MagickColor(178, 255, 102),
                new MagickColor(204, 255, 153),
                new MagickColor(229, 255, 204),

                new MagickColor(0, 51, 0),  //greens
                new MagickColor(0, 102, 0),
                new MagickColor(0, 153, 0),
                new MagickColor(0, 204, 0),
                new MagickColor(0, 255, 0),
                new MagickColor(51, 255, 51),
                new MagickColor(102, 255, 102),
                new MagickColor(153, 255, 153),
                new MagickColor(204, 255, 204),

                new MagickColor(0, 51, 25),  //greens-blues
                new MagickColor(0, 102, 51),
                new MagickColor(0, 153, 76),
                new MagickColor(0, 204, 102),
                new MagickColor(0, 255, 128),
                new MagickColor(51, 255, 153),
                new MagickColor(102, 255, 178),
                new MagickColor(153, 255, 204),
                new MagickColor(204, 255, 229),

                new MagickColor(0, 51, 51), //light light blues
                new MagickColor(0, 102, 102),
                new MagickColor(0, 153, 153),
                new MagickColor(0, 204, 204),
                new MagickColor(0, 255, 255),
                new MagickColor(51, 255, 255),
                new MagickColor(102, 255, 255),
                new MagickColor(153, 255, 255),
                new MagickColor(204, 255, 255),

                new MagickColor(0, 25, 51), //light blues
                new MagickColor(0, 51, 102),
                new MagickColor(0, 76, 153),
                new MagickColor(0, 102, 204),
                new MagickColor(0, 128, 255),
                new MagickColor(51, 153, 255),
                new MagickColor(102, 178, 255),
                new MagickColor(153, 204, 255),
                new MagickColor(204, 229, 255),

                new MagickColor(0, 0, 51),  //blues
                new MagickColor(0, 0, 102),
                new MagickColor(0, 0, 153),
                new MagickColor(0, 0, 204),
                new MagickColor(0, 0, 255),
                new MagickColor(51, 51, 255),
                new MagickColor(102, 102, 255),
                new MagickColor(153, 153, 255),
                new MagickColor(204, 204, 255),

                new MagickColor(25, 0, 51),  //purples
                new MagickColor(51, 0, 102),
                new MagickColor(76, 0, 153),
                new MagickColor(102, 0, 204),
                new MagickColor(128, 0, 255),
                new MagickColor(153, 51, 255),
                new MagickColor(178, 102, 255),
                new MagickColor(204, 153, 255),
                new MagickColor(229, 204, 255),

                new MagickColor(51, 0, 51), //violets
                new MagickColor(102, 0, 102),
                new MagickColor(153, 0, 153),
                new MagickColor(204, 0, 204),
                new MagickColor(255, 0, 255),
                new MagickColor(255, 51, 255),
                new MagickColor(255, 102, 255),
                new MagickColor(255, 153, 255),
                new MagickColor(255, 204, 255),

                new MagickColor(51, 0, 25),  //pinks
                new MagickColor(102, 0, 51),
                new MagickColor(153, 0, 76),
                new MagickColor(204, 0, 102),
                new MagickColor(255, 0, 128),
                new MagickColor(255, 51, 153),
                new MagickColor(255, 102, 178),
                new MagickColor(255, 153, 204),
                new MagickColor(255, 204, 229),

                new MagickColor(0, 0, 0),  //gray
                new MagickColor(32, 32, 32),
                new MagickColor(64, 64, 64),
                new MagickColor(96, 96, 96),
                new MagickColor(128, 128, 128),
                new MagickColor(160, 160, 160),
                new MagickColor(192, 192, 192),
                new MagickColor(224, 224, 224),
                new MagickColor(255, 255, 255),
            };
        }
    }
}
