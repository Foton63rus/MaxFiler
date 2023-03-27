namespace MaxFiler
{
    public class MaxInfoParser : IFileInfoParser
    {
        void IFileInfoParser.Init()
        {
            AppEvents.fileFormatToParserRegistryActionInvoker(".max", this);
        }
        public FileInfo Parse(string file)
        {
            try
            {
                using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
                    {
                        string contents = reader.ReadToEnd();

                        int first = contents.IndexOf("Version:");
                        int last = contents.IndexOf("RenderElements");

                        string content = contents.Substring(first, last - first);

                        //Console.WriteLine($"file {file}");
                        //Console.WriteLine($"content: {content}");
                        FileInfo info = ExtractInfo(content);
                        Console.WriteLine(info);
                        return info;
                    }
                }
            }
            catch(Exception e) 
            {
                return null;
            }
        }

        public static FileInfo ExtractInfo(string content)
        {
            string Version = "";
            string Vertices = "";
            string Faces = "";
            string Shapes = "";
            string Lights = "";
            string Cameras = "";
            string Helpers = "";
            string Renderer = "";
            string RenderWidth = "";
            string RenderHeight = "";

            List<string> Pictures = new List<string>();

            Version = getByPatternToDigit(content, "Version");
            Vertices = getByPatternToDigit(content, "Vertices");
            Faces = getByPatternToDigit(content, "Faces");
            Shapes = getByPatternToDigit(content, "Shapes");
            Lights = getByPatternToDigit(content, "Lights");
            Cameras = getByPatternToDigit(content, "Cameras");
            Helpers = getByPatternToDigit(content, "Helpers");
            Renderer = getRenderer(content);
            Pictures = getPictures(content);

            return new FileInfo(Version, Vertices, Faces, Shapes, Lights, Cameras, Helpers, Renderer);
        }

        static string getByPatternToDigit(string text, string pattern)
        {
            string reg = pattern + @":\s+(?<target>[\d.,]+)[^\d,.]";
            Match match = Regex.Match(text, reg);
            return match.Success ? match.Groups["target"].Value.Trim() : "";
        }

        static string getRenderer(string text)
        {
            string regexPattern = string.Format(@"(?<=Renderer\sName=).*?(?=\x14)");
            Match match = Regex.Match(text, regexPattern);
            return match.Success ? match.Groups[0].Value.Trim() : "";
        }

        static List<string> getPictures(string text)
        {
            string regexPattern = string.Format(@"\w+.png|\w+.jpg|\w+.tif");
            List<string> matchList = new List<string>();
            foreach (Match match in Regex.Matches(text, regexPattern))
            {
                matchList.Add(match.Value.Trim());
                Console.WriteLine(match.Value.Trim());
            }
            return matchList;
        }
    }
}


//public static void ReadFileBackwards(string filePath)
//{
//    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//    using (var reader = new StreamReader(stream))
//    {
//        reader.BaseStream.Seek(-2, SeekOrigin.End);
//        string line;
//        while ((line = reader.ReadLine()) != null)
//        {
//            Console.WriteLine(line);
//            reader.BaseStream.Seek(-2, SeekOrigin.Current);
//        }
//    }
//}