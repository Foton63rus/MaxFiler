using MaxFiler.Palette;

namespace MaxFiler
{
    [Serializable]
    public class CatalogInfo
    {
        public string catalogPath;
        public FileInfo fileInfo;
        public List<PreviewSlot> previews = new List<PreviewSlot>();

        public CatalogInfo(FileInfo fileInfo, List<PreviewSlot> previews)
        {
            this.catalogPath = fileInfo.FileName.Substring(0, fileInfo.FileName.LastIndexOf("\\") + 1);
            this.fileInfo = fileInfo;
            this.previews = previews;
        }

        public override string ToString()
        {
            string output = $"path: {catalogPath}\n{fileInfo}\npreviews: ";
            foreach (PreviewSlot slot in previews)
            {
                output += slot.image + "\t" ;
            }
            return output;
        }
    }
}
