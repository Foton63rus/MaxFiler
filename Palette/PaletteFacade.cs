using ImageMagick;

namespace MaxFiler.Palette
{
    public class PaletteFacade
    {
        PaletteHistogram paletteHistogram;
        public PaletteFacade()
        {
            paletteHistogram = new PaletteHistogram(GetPaletteColorsRGBList());
        }

        public List<MagickColor> GetPaletteColorsRGBList() => PaletteColor.GetColors();
        public List<string> GetColorNamesByPaletteColorList(List<MagickColor> colorsRGB) => PaletteColor.GetNames(colorsRGB);

        public Dictionary<MagickColor, int> ImageColorRate(string filename) => paletteHistogram.ImageColorRate(filename);
    }
}
