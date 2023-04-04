using System.IO;

namespace MaxFiler
{
    internal class CatalogInspector
    {
        private Dictionary<string, IFileInfoParser> _fileFormatToParserDictionary = new Dictionary<string, IFileInfoParser>();
        private List<IFileInfoParser> _fileInfoParsers = new List<IFileInfoParser>();

        private FileInfoWriter _fileInfoWriter;

        public CatalogInspector(IFileInfoParser[] fileInfoParsers = null)
        {
            _fileInfoWriter = new FileInfoWriter();

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

        public void InspectDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory not exist");
                return;
            }

            bool filesInCurrentDirectoryCanParse = FilesParse(directory);

            if (!filesInCurrentDirectoryCanParse)
            {
                RecursiveSearchInNestedFolders( getNestedFolders(directory) );
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

        private bool HasSubFolders(string directory) => Directory.GetDirectories(directory).Length > 0;

        private void addFileInfo(FileInfo fileInfo)
        {
            if (fileInfo != null)
            {

            }
        }

        private List<string> getFiles(string directory) => Directory.GetFiles(directory).ToList();

        private List<string> getNestedFolders(string directory) => Directory.GetDirectories(directory).ToList();

        private bool FilesParse(string directory)
        {
            bool extensionSupported = false;
            foreach (string file in getFiles(directory)) 
            {   
                if (_fileFormatToParserDictionary.ContainsKey(Path.GetExtension(file)))
                {
                    Console.WriteLine(file);
                    _fileFormatToParserDictionary[Path.GetExtension(file)].Parse(file);
                    extensionSupported = true;
                }
            }
            return extensionSupported;
        }

        private void RecursiveSearchInNestedFolders(List<string> directories) 
        { 
            foreach (string directory in directories)
            {
                InspectDirectory(directory);
            }
        }
    }
}
