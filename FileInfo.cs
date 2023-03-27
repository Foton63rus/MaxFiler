namespace MaxFiler
{
    [Serializable]
    public class FileInfo
    {
        public string FileType;
        public string Version;
        public string Vertices;
        public string Faces;
        public string Shapes;
        public string Lights;
        public string Cameras;
        public string Helpers;
        public string Renderer;

        public FileInfo( string Version  = "",
                        string Vertices = "",
                        string Faces    = "",
                        string Shapes   = "",
                        string Lights   = "",
                        string Cameras  = "",
                        string Helpers  = "",
                        string Renderer = "")
        {
            this.FileType   = "Max";
            this.Version    = Version;
            this.Vertices   = Vertices;
            this.Faces      = Faces;
            this.Shapes     = Shapes;
            this.Lights     = Lights;
            this.Cameras    = Cameras;
            this.Helpers    = Helpers;
            this.Renderer   = Renderer;
        }

        public override string ToString()
        {
            return
                $"Type: {FileType}\n" +
                $"Version: {Version}\n" +
                $"Vertices: {Vertices}\n" +
                $"Faces: {Faces}\n" +
                $"Shapes: {Shapes}\n" +
                $"Lights: {Lights}\n" +
                $"Cameras: {Cameras}\n" +
                $"Helpers: {Helpers}\n" +
                $"Renderer: {Renderer}";
        }
    }
}
