﻿namespace MaxFiler.Palette;

internal static class PaletteColor
{
    private static Dictionary<MagickColor, string> _palette = new Dictionary<MagickColor, string>() 
    {
        { new MagickColor(51, 0, 0), "red 1" },
        { new MagickColor(102, 0, 0), "red 2" },
        { new MagickColor(153, 0, 0), "red 3" },
        { new MagickColor(204, 0, 0), "red 4" },
        { new MagickColor(255, 0, 0), "red 5" },
        { new MagickColor(255, 51, 51), "red 6" },
        { new MagickColor(255, 102, 102), "red 7" },
        { new MagickColor(255, 153, 153), "red 8" },
        { new MagickColor(255, 204, 204), "red 9" },

        { new MagickColor(51, 25, 0), "orange 1" },
        { new MagickColor(102, 51, 0), "orange 2" },
        { new MagickColor(153, 76, 0), "orange 3" },
        { new MagickColor(204, 102, 0), "orange 4" },
        { new MagickColor(255, 128, 0), "orange 5" },
        { new MagickColor(255, 153, 51), "orange 6" },
        { new MagickColor(255, 178, 102), "orange 7" },
        { new MagickColor(255, 204, 153), "orange 8" },
        { new MagickColor(255, 229, 204), "orange 9" },

        { new MagickColor(51, 51, 0), "yellow 1" },
        { new MagickColor(102, 102, 0), "yellow 2" },
        { new MagickColor(153, 153, 0), "yellow 3" },
        { new MagickColor(204, 204, 0), "yellow 4" },
        { new MagickColor(255, 255, 0), "yellow 5" },
        { new MagickColor(255, 255, 51), "yellow 6" },
        { new MagickColor(255, 255, 102), "yellow 7" },
        { new MagickColor(255, 255, 153), "yellow 8" },
        { new MagickColor(255, 255, 204), "yellow 9" },

        { new MagickColor(25, 51, 0), "chartreuse green 1" },
        { new MagickColor(51, 102, 0), "chartreuse green 2" },
        { new MagickColor(76, 153, 0), "chartreuse green 3" },
        { new MagickColor(102, 204, 0), "chartreuse green 4" },
        { new MagickColor(128, 255, 0), "chartreuse green 5" },
        { new MagickColor(153, 255, 51), "chartreuse green 6" },
        { new MagickColor(178, 255, 102), "chartreuse green 7" },
        { new MagickColor(204, 255, 153), "chartreuse green 8" },
        { new MagickColor(229, 255, 204), "chartreuse green 9" },

        { new MagickColor(0, 51, 0), "green 1" },
        { new MagickColor(0, 102, 0), "green 2" },
        { new MagickColor(0, 153, 0), "green 3" },
        { new MagickColor(0, 204, 0), "green 4" },
        { new MagickColor(0, 255, 0), "green 5" },
        { new MagickColor(51, 255, 51), "green 6" },
        { new MagickColor(102, 255, 102), "green 7" },
        { new MagickColor(153, 255, 153), "green 8" },
        { new MagickColor(204, 255, 204), "green 9" },

        { new MagickColor(0, 51, 25), "spring green 1" },
        { new MagickColor(0, 102, 51), "spring green 2" },
        { new MagickColor(0, 153, 76), "spring green 3" },
        { new MagickColor(0, 204, 102), "spring green 4" },
        { new MagickColor(0, 255, 128), "spring green 5" },
        { new MagickColor(51, 255, 153), "spring green 6" },
        { new MagickColor(102, 255, 178), "spring green 7" },
        { new MagickColor(153, 255, 204), "spring green 8" },
        { new MagickColor(204, 255, 229), "spring green 9" },

        { new MagickColor(0, 51, 51), "aqua 1" },
        { new MagickColor(0, 102, 102), "aqua 2" },
        { new MagickColor(0, 153, 153), "aqua 3" },
        { new MagickColor(0, 204, 204), "aqua 4" },
        { new MagickColor(0, 255, 255), "aqua 5" },
        { new MagickColor(51, 255, 255), "aqua 6" },
        { new MagickColor(102, 255, 255), "aqua 7" },
        { new MagickColor(153, 255, 255), "aqua 8" },
        { new MagickColor(204, 255, 255), "aqua 9" },

        { new MagickColor(0, 25, 51), "azure 1" },
        { new MagickColor(0, 51, 102), "azure 2" },
        { new MagickColor(0, 76, 153), "azure 3" },
        { new MagickColor(0, 102, 204), "azure 4" },
        { new MagickColor(0, 128, 255), "azure 5" },
        { new MagickColor(51, 153, 255), "azure 6" },
        { new MagickColor(102, 178, 255), "azure 7" },
        { new MagickColor(153, 204, 255), "azure 8" },
        { new MagickColor(204, 229, 255), "azure 9" },

        { new MagickColor(0, 0, 51), "blue 1" },
        { new MagickColor(0, 0, 102), "blue 2" },
        { new MagickColor(0, 0, 153), "blue 3" },
        { new MagickColor(0, 0, 204), "blue 4" },
        { new MagickColor(0, 0, 255), "blue 5" },
        { new MagickColor(51, 51, 255), "blue 6" },
        { new MagickColor(102, 102, 255), "blue 7" },
        { new MagickColor(153, 153, 255), "blue 8" },
        { new MagickColor(204, 204, 255), "blue 9" },

        { new MagickColor(25, 0, 51), "violet 1" },
        { new MagickColor(51, 0, 102), "violet 2" },
        { new MagickColor(76, 0, 153), "violet 3" },
        { new MagickColor(102, 0, 204), "violet 4" },
        { new MagickColor(128, 0, 255), "violet 5" },
        { new MagickColor(153, 51, 255), "violet 6" },
        { new MagickColor(178, 102, 255), "violet 7" },
        { new MagickColor(204, 153, 255), "violet 8" },
        { new MagickColor(229, 204, 255), "violet 9" },

        { new MagickColor(51, 0, 51), "magenta 1" },
        { new MagickColor(102, 0, 102), "magenta 2" },
        { new MagickColor(153, 0, 153), "magenta 3" },
        { new MagickColor(204, 0, 204), "magenta 4" },
        { new MagickColor(255, 0, 255), "magenta 5" },
        { new MagickColor(255, 51, 255), "magenta 6" },
        { new MagickColor(255, 102, 255), "magenta 7" },
        { new MagickColor(255, 153, 255), "magenta 8" },
        { new MagickColor(255, 204, 255), "magenta 9" },

        { new MagickColor(51, 0, 25), "rose 1" },
        { new MagickColor(102, 0, 51), "rose 2" },
        { new MagickColor(153, 0, 76), "rose 3" },
        { new MagickColor(204, 0, 102), "rose 4" },
        { new MagickColor(255, 0, 128), "rose 5" },
        { new MagickColor(255, 51, 153), "rose 6" },
        { new MagickColor(255, 102, 178), "rose 7" },
        { new MagickColor(255, 153, 204), "rose 8" },
        { new MagickColor(255, 204, 229), "rose 9" },

        { new MagickColor(0, 0, 0), "black" },
        { new MagickColor(32, 32, 32), "grey 1" },
        { new MagickColor(64, 64, 64), "grey 2" },
        { new MagickColor(96, 96, 96), "grey 3" },
        { new MagickColor(128, 128, 128), "grey 4" },
        { new MagickColor(160, 160, 160), "grey 5" },
        { new MagickColor(192, 192, 192), "grey 6" },
        { new MagickColor(224, 224, 224), "grey 7" },
        { new MagickColor(255, 255, 255), "white" },
    };

    internal static List<MagickColor> GetColors() => _palette.Keys.ToList();
    internal static List<string> GetNames(List<MagickColor> colorsRGB) => _palette.Keys.Where(x => colorsRGB.Contains(x)).Select(x => _palette[x]).ToList();
}