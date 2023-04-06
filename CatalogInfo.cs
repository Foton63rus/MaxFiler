namespace MaxFiler
{
    [Serializable]
    internal class CatalogInfo
    {
        public string catalogPath;
        public FileInfo fileInfo;
        public List<string> previews = new List<string>();

        public CatalogInfo( FileInfo fileInfo, List<string> previews )
        {
            this.catalogPath = fileInfo.FileName.Substring(0, fileInfo.FileName.LastIndexOf("\\") + 1);
            this.fileInfo = fileInfo;
            this.previews = previews;
        }
    }
}
