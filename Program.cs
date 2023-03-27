global using System.Text;
global using System.Text.RegularExpressions;
global using Newtonsoft.Json;

namespace MaxFiler
{
    class Program
    {
        internal static void Main(string[] args)
        {
            CatalogInspector inspector = new CatalogInspector();
            inspector.AddParser( new MaxInfoParser() );
            inspector.InitParsers();
            Console.WriteLine("ВВедите путь к папке, в которой надо найти файлы .max и собрать с них инфу");
            inspector.InspectDirectory( Console.ReadLine() );
            Console.ReadLine();
        }
    }
}