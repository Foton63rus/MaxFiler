namespace MaxFiler
{
    internal class FileInfoWriter
    {
        private string _fileInfoName = $"_info.txt";
        public FileInfoWriter()
        {
            AppEvents.FileInfoReturnAction += writeByFileName;
        }

        internal void writeByFileName(string filepath, string jsonFileInfo)
        {
            string file;
            try
            {
                file = filepath.Substring(0, filepath.LastIndexOf("\\") + 1) + _fileInfoName;

                if (File.Exists(file) ) 
                {
                    File.Delete(file);
                }

                using (StreamWriter sw = new StreamWriter(file, true ,Encoding.UTF8 ) )
                {
                    sw.WriteLine(jsonFileInfo);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
