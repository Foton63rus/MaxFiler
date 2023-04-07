global using System.Text;
global using System.Text.RegularExpressions;
global using Newtonsoft.Json;
global using System.IO;
global using ImageMagick;
using MaxFiler;
using MaxFiler.Palette;

class Program
{
    internal static void Main(string[] args)
    {
        PaletteFacade colorManager = new PaletteFacade();
        CatalogInspector inspector = new CatalogInspector(colorManager);
        inspector.AddParser( new MaxInfoParser() );
        inspector.InitParsers();
        Console.WriteLine("ВВедите путь к папке, в которой надо найти файлы .max и собрать с них инфу");
        string directory = Console.ReadLine();
        inspector.InspectDirectory(directory);

        Console.ReadLine();
    }
}
