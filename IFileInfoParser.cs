namespace MaxFiler
{
    public interface IFileInfoParser
    {
        public void Init();
        public FileInfo Parse(string filepath);
    }
}
