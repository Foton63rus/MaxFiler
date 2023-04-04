global using System.Text;
global using System.Text.RegularExpressions;
global using Newtonsoft.Json;
global using System.IO;
global using ImageMagick;
using MaxFiler;
using MaxFiler.ColorManager;

class Program
{
    internal static void Main(string[] args)
    {
        string q = @"C:\Users\4ton1\OneDrive\Рабочий стол\testMax\3124e123-2565247673.jpg";
        List<MagickColor> colors = PaletteHistogram.getTopColorPalette();
        PaletteHistogram palette = new PaletteHistogram(colors);
        palette.ImageRate(q);
        //ColorHistogram.getTopColors(q);

        CatalogInspector inspector = new CatalogInspector();
        inspector.AddParser( new MaxInfoParser2() );
        inspector.InitParsers();
        Console.WriteLine("ВВедите путь к папке, в которой надо найти файлы .max и собрать с них инфу");
        inspector.InspectDirectory( Console.ReadLine() );
        Console.ReadLine();
    }
}
