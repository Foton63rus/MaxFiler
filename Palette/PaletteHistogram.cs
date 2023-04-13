using ImageMagick;

namespace MaxFiler.Palette;

/// <summary>
///  Класс, который находит совпадения с палитрой цветов, 
///  а точнее сортирует все цвета на самые ближайшие к тем, 
///  которые сосавляют палитру,заданную в конструкторе
///  
//  Пример использования
/// 
/// Выьираем цвета для палитры или берем имеющиеся
/// List<MagickColor> colors = PaletteHistogram.getTopColorPalette();
/// Создаем экземпляр палитры и передаем собранные цвета
/// PaletteHistogram palette = new PaletteHistogram(colors);
/// Вызываем метод распределения цветов к ближайшим
/// palette.ImageRate( "..." );
/// </summary>
internal class PaletteHistogram
{
    public Dictionary<MagickColor, int> Rate = new Dictionary<MagickColor, int>();

    public PaletteHistogram(List<MagickColor> paletteColors)
    {
        foreach (MagickColor color in paletteColors)
        {
            Rate.Add(toMagickColor(color), 0);
        }
    }

    public MagickColor toMagickColor(IMagickColor<byte> color)
    {
        return new MagickColor(color.R, color.G, color.B);
    }

    internal Dictionary<MagickColor, int> ImageColorRate(string filename)
    {
        this.CLear();
        using (var image = new MagickImage(filename))
        {
            Console.WriteLine($"pix count real: {image.GetPixels().Count()}");
            int wSize = 64; int hSize = 64;
            image.Resize(wSize, hSize); //уменьшаем размер картинки для увеличения скорости просчета
            var pixColors = image.Histogram();
            Console.WriteLine($"pix count: {pixColors.Count}/{wSize * hSize}");
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
            var sortedRate = Rate.OrderByDescending(x => x.Value).Where(x => x.Value > 0).Take(5);
            foreach (var item in sortedRate)
            {
                Console.WriteLine($"Rate: {item.Key} - {item.Value}");
            }
            return sortedRate.ToDictionary(x => x.Key, x => x.Value);
        }
    }

    private float ColorDifference(MagickColor color1, MagickColor color2)
    {
        return MathF.Sqrt((color1.R - color2.R) * (color1.R - color2.R) +
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
    public static List<MagickColor> GetTopColorPalette() => PaletteColor.GetColors();
}
