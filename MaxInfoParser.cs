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
            string preExtract = PreExtract(file);
            FileInfo info = ExtractInfo(preExtract);
            Console.WriteLine("\n" + info + "\n");
            return info;
        }

        public string PreExtract(string file)
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

                        return content;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static FileInfo ExtractInfo(string content)
        {
            List<string> Pictures = new List<string>();

            string Version = getByPatternToDigit(content, "Version");
            string Vertices = getByPatternToDigit(content, "Vertices");
            string Faces = getByPatternToDigit(content, "Faces");
            string Shapes = getByPatternToDigit(content, "Shapes");
            string Lights = getByPatternToDigit(content, "Lights");
            string Cameras = getByPatternToDigit(content, "Cameras");
            string Helpers = getByPatternToDigit(content, "Helpers");
            string Renderer = getRenderer(content);
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