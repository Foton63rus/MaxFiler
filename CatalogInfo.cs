using MaxFiler.Palette;

namespace MaxFiler
{
    [Serializable]
    internal class CatalogInfo
    {
        public string catalogPath;
        public FileInfo fileInfo;
        public List<PreviewSlot> previews = new List<PreviewSlot>();

        public CatalogInfo( FileInfo fileInfo, List<PreviewSlot> previews )
        {
            this.catalogPath = fileInfo.FileName.Substring(0, fileInfo.FileName.LastIndexOf("\\") + 1);
            this.fileInfo = fileInfo;
            this.previews = previews;
        }
    }
}
