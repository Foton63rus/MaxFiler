namespace MaxFiler
{
    internal class InfoWriter
    {
        private string _fileInfoName = $"_info.txt";

        internal void WriteCatalogInfo( CatalogInfo catalogInfo )
        {

            string file;
            try
            {
                file = catalogInfo.catalogPath + _fileInfoName;

                if (File.Exists(file))
                {
                    File.Delete(file);
                }

                using (StreamWriter sw = new StreamWriter(file, true, Encoding.UTF8))
                {
                    sw.WriteLine(JsonConvert.SerializeObject( catalogInfo ));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
