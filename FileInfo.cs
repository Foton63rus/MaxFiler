namespace MaxFiler
{
    [Serializable]
    public class FileInfo
    {
        public string       FileName;
        public string       FileType;
        public string       Version;
        public string       Vertices;
        public string       Faces;
        public string       Shapes;
        public string       Lights;
        public string       Cameras;
        public string       Helpers;
        public string       Renderer;
        public List<string> Textures;

        public FileInfo( 
                        string Version = "",
                        string Vertices = "",
                        string Faces = "",
                        string Shapes = "",
                        string Lights = "",
                        string Cameras = "",
                        string Helpers = "",
                        string Renderer = "",
                        List<string> Textures = null,
                        string FileName = ""
                        )
        {
            this.FileName   = FileName;
            this.FileType   = "Max";
            this.Version    = Version;
            this.Vertices   = Vertices;
            this.Faces      = Faces;
            this.Shapes     = Shapes;
            this.Lights     = Lights;
            this.Cameras    = Cameras;
            this.Helpers    = Helpers;
            this.Renderer   = Renderer;

            if (Textures != null)
            {
                this.Textures = Textures;
            }
            
        }

        public override string ToString()
        {
            string strTextures = $"None";
            if (this.Textures.Count > 0)
            {
                string separator = $"; ";
                StringBuilder sb = new StringBuilder();
                strTextures = $"{Textures.Append("; ")}";
                foreach (string item in Textures)
                {
                    sb.Append($"{separator}{item}");
                }
                strTextures = sb.ToString().Substring(separator.Length-1);
            }
            return
                //$"Type: {FileName}\n" +
                $"Type: {FileType}\n" +
                $"Version: {Version}\n" +
                $"Vertices: {Vertices}\n" +
                $"Faces: {Faces}\n" +
                $"Shapes: {Shapes}\n" +
                $"Lights: {Lights}\n" +
                $"Cameras: {Cameras}\n" +
                $"Helpers: {Helpers}\n" +
                $"Renderer: {Renderer}\n" +
                $"Textures: {strTextures}";
        }
    }
}
