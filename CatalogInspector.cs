namespace MaxFiler.Palette
{
    public class CatalogInspector
    {
        private Dictionary<string, IFileInfoParser> _fileFormatToParserDictionary = new Dictionary<string, IFileInfoParser>();
        private List<IFileInfoParser> _fileInfoParsers = new List<IFileInfoParser>();

        private InfoWriter _infoWriter;
        private PaletteFacade _paletteFacade;

        public CatalogInspector(Palette.PaletteFacade paletteFacade, IFileInfoParser[] fileInfoParsers = null)
        {
            _infoWriter = new InfoWriter();
            _paletteFacade = paletteFacade;

            AppEvents.FileFormatToParserRegistryAction += AddFileFormatToParser;

            if (fileInfoParsers != null)
            {
                _fileInfoParsers = fileInfoParsers.ToList();
            }
        }

        public void InitParsers()
        {
            foreach (IFileInfoParser fileInfoParser in _fileInfoParsers)
            {
                fileInfoParser.Init();
            }
        }

        public CatalogInfo InspectDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                AppEvents.LogActionInvoke(this, "Не верно указана директория");
                Console.WriteLine("Directory not exist");
                return null;
            }

            FileInfo filesInCurrentDirectoryCanParse = FilesParse(directory);

            if (filesInCurrentDirectoryCanParse != null)
            {
                List<string> renderList = GetRenderList(directory, filesInCurrentDirectoryCanParse);
                List<PreviewSlot> previews = new List<PreviewSlot>();
                foreach (string renderName in renderList)
                {
                    var colorRate = _paletteFacade.ImageColorRate(Path.Combine(directory, renderName));
                    string[] colorNames = _paletteFacade.GetColorNamesByPaletteColorList(colorRate.Keys.ToList()).ToArray();
                    previews.Add(new PreviewSlot(renderName, colorNames, 5));
                }

                CatalogInfo catInfo = new CatalogInfo(filesInCurrentDirectoryCanParse, previews);
                _infoWriter.WriteCatalogInfo(catInfo);

                return catInfo;
            }
            else
            {
                RecursiveSearchInNestedFolders(getNestedFolders(directory));
                return null;
            }
        }

        public void AddParser(IFileInfoParser fileInfoParser)
        {
            if (!_fileInfoParsers.Contains(fileInfoParser))
            {
                _fileInfoParsers.Add(fileInfoParser);
            }
        }

        public void AddFileFormatToParser(string key, IFileInfoParser parser)
        {
            if (_fileFormatToParserDictionary.ContainsKey(key)) return;

            _fileFormatToParserDictionary.Add(key, parser);
        }
        private List<string> getFiles(string directory) => Directory.GetFiles(directory).ToList();

        private List<string> getNestedFolders(string directory) => Directory.GetDirectories(directory).ToList();

        private FileInfo FilesParse(string directory)
        {
            FileInfo fileInfo = null;
            foreach (string file in getFiles(directory))
            {
                if (_fileFormatToParserDictionary.ContainsKey(Path.GetExtension(file)))
                {
                    fileInfo = _fileFormatToParserDictionary[Path.GetExtension(file)].Parse(file);
                }
            }
            return fileInfo;
        }

        private void RecursiveSearchInNestedFolders(List<string> directories)
        {
            foreach (string directory in directories)
            {
                AppEvents.LogActionInvoke(this, directory);
                InspectDirectory(directory);
            }
        }

        public List<string> GetRenderList(string directory, FileInfo fileInfo)
        {   //находим все картинки в каталоге и все те, которые не содержаться в списке макс файла
            return Directory.GetFiles(directory).   //берем файлы из каталога
                Where(x => x.EndsWith(".png") || x.EndsWith(".jpg") || x.EndsWith(".jpeg") || x.EndsWith(".tif") || x.EndsWith(".tga")).    //отсеиваем картинки
                Select(x => x.Substring(x.LastIndexOf('\\') + 1).ToLower()).  //отсекаем пути до каталога и переводим в нижний регистр
                Where(x => !fileInfo.Textures.Contains(x)).ToList();    //фильтруем файлы, находящиейся в списке текстур
        }
    }
}
