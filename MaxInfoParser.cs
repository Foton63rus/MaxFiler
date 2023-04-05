namespace MaxFiler
{
    public class MaxInfoParser : IFileInfoParser
    {
        void IFileInfoParser.Init()
        {
            AppEvents.FileFormatToParserRegistryActionInvoke(".max", this);
        }
        public FileInfo Parse(string file)
        {
            string context = GetContextFromFileFile(file);
            List<string> contextSubstrings = new List<string>();
            foreach (string item in ContextSplitter(context))
            {
                if (item != "")
                {
                    contextSubstrings.Add(item.Trim());
                }
            }
            FileInfo info = ExtractInfo(contextSubstrings);
            info.FileName = file;
            return info;
        }

        static string getParametrFromContextSubstrings(List<string> contextSubstrings, string paramName)
        {
            foreach (string item in contextSubstrings)
            {
                if (item.StartsWith(paramName))
                {
                    return item.Split(" ")[1];
                }
            }
            return null;
        }

        static string getRenderer(List<string> contextSubstrings) => contextSubstrings.Find(x => x.StartsWith("Renderer Name")).Split("=")[1];

        public static FileInfo ExtractInfo(List<string> contextSubstrings)
        {
            List<string> Textures = new List<string>();

            string Version = getParametrFromContextSubstrings(contextSubstrings, "Version");
            string Vertices = getParametrFromContextSubstrings(contextSubstrings, "Vertices");
            string Faces = getParametrFromContextSubstrings(contextSubstrings, "Faces");
            string Shapes = getParametrFromContextSubstrings(contextSubstrings, "Shapes");
            string Lights = getParametrFromContextSubstrings(contextSubstrings, "Lights");
            string Cameras = getParametrFromContextSubstrings(contextSubstrings, "Cameras");
            string Helpers = getParametrFromContextSubstrings(contextSubstrings, "Helpers");
            string Renderer = getRenderer(contextSubstrings);
            Textures = getTextures(contextSubstrings);
            return new FileInfo(Version, Vertices, Faces, Shapes, Lights, Cameras, Helpers, Renderer, Textures);
        }
        static List<string> getTextures(List<string> contextSubstrings) => 
            contextSubstrings.Where(x => x.EndsWith(".png") || x.EndsWith(".jpg") || x.EndsWith(".jpeg") || x.EndsWith(".tif") || x.EndsWith(".tga")).ToList();

        public static string GetContextFromFileFile(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
                    {
                        string contents = reader.ReadToEnd();

                        int first = contents.IndexOf("Version:");
                        int last = contents.IndexOf("RenderElements");

                        string content = contents.Substring(first, last - first);

                        return content;
                    }
                }
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string[] ContextSplitter(string context)
        {
            return Regex.Split(context, @"[\p{Cc}]");
        }
    }
}


