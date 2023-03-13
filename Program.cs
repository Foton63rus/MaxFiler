using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

class Program
{
    internal static void Main(string[] args)
    {
        List<MaxInfo> maxFiles = new List<MaxInfo>();

        Console.WriteLine("ВВедите путь к папке, в которой надо найти файлы .max и собрать с них инфу");

        string path = Console.ReadLine();

        if (Directory.Exists(path))
        {
            List<string> files = Directory.GetFiles(path).ToList().Where( x => x.EndsWith(".max") ).ToList();

            if (files.Count > 0)
            {
                Console.WriteLine($"Find {files.Count} max files\n");
                int fileCounter = 0;
                foreach (string file in files)
                {
                    try
                    {
                        fileCounter++;
                        Console.WriteLine($"{fileCounter}/{files.Count} {file}");

                        using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
                            {
                                string contents = reader.ReadToEnd();

                                int first = contents.IndexOf("Version:");
                                int last = contents.IndexOf("RenderElements");

                                string content = contents.Substring(first, last - first);

                                Console.WriteLine($"file {file}");
                                MaxInfo info = Parse(content);
                                maxFiles.Add(info);
                                Console.WriteLine(info);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\n");
                        Console.WriteLine($"file {file} cannot be read\n");
                        Console.WriteLine($"\n");
                    }
                }
                string json = JsonConvert.SerializeObject(maxFiles);
                Console.WriteLine(json);
                //string b = a.Serialize();
            }
        }
        else
        {
            Console.WriteLine("Directory cannot find");
        }
        Console.ReadKey();
    }

    public static MaxInfo Parse(string content)
    {
        string Version = "";
        string Build = "";
        string Vertices = "";
        string Faces = ""; ;
        string Shapes = "";
        string Lights = "";
        string Cameras = "";
        string Helpers = "";
        string RenderWidth = "";
        string RenderHeight = "";

        Version = getByPattern(content, "Version");
        Build = getByPattern(content, "Build");
        Vertices = getByPattern(content, "Vertices");
        Faces = getByPattern(content, "Faces");
        Shapes = getByPattern(content, "Shapes");
        Lights = getByPattern(content, "Lights");
        Cameras = getByPattern(content, "Cameras");
        Helpers = getByPattern(content, "Helpers");
        //RenderWidth = getByPattern(content, "RenderWidth");
        //RenderHeight = getByPattern(content, "RenderHeight");
        //return new MaxInfo(Version, Build, Vertices, Faces, Shapes, Lights, Cameras, Helpers, RenderWidth, RenderHeight);
        return new MaxInfo(Version, Build, Vertices, Faces, Shapes, Lights, Cameras, Helpers);
    }

    static string getByPattern(string text, string pattern)
    {
        string reg = pattern + @":\s+(?<target>[\d.,]+)[^\d,.]";
        Match match = Regex.Match(text, reg);
        return match.Success ? match.Groups["target"].Value.Trim() : "";
    }
}

[Serializable]
class MaxInfo
{
    public string Version;
    public string Build;
    public string Vertices;
    public string Faces;
    public string Shapes;
    public string Lights;
    public string Cameras;
    public string Helpers;
    //public string RenderWidth;
    //public string RenderHeight;

    public MaxInfo(
        string Version = "", 
        string Build = "", 
        string Vertices = "", 
        string Faces = "", 
        string Shapes = "", 
        string Lights = "", 
        string Cameras = "", 
        string Helpers = "")
        //string RenderWidth = "", 
        //string RenderHeight = "")
    {
        this.Version = Version;
        this.Build= Build; 
        this.Vertices = Vertices;
        this.Faces = Faces;
        this.Shapes = Shapes;
        this.Lights = Lights;
        this.Cameras = Cameras;
        this.Helpers = Helpers;
        //this.RenderWidth= RenderWidth;
        //this.RenderHeight= RenderHeight;
    }

    public override string ToString()
    {
        return
            $"MaxInfo\n" +
            $"Version: {Version}\n" +
            $"Build: {Build}\n" +
            $"Vertices: {Vertices}\n" +
            $"Faces: {Faces}\n" +
            $"Shapes: {Shapes}\n" +
            $"Lights: {Lights}\n" +
            $"Cameras: {Cameras}\n" +
            $"Helpers: {Helpers}\n";
            //$"RenderWidth: {RenderWidth}\n" +
            //$"RenderHeight: {RenderHeight}\n";
    }
}