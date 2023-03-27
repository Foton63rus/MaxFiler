namespace MaxFiler
{
    interface IFileInfoParser
    {
        public void Init();
        public FileInfo Parse(string filepath);
    }
}
