namespace MaxFiler
{
    internal static class AppEvents
    {
        //Событие регистрации парсера, передается расширение файла, за которое он отвечает
        internal static event Action<string, IFileInfoParser> FileFormatToParserRegistryAction; 
        public static void FileFormatToParserRegistryActionInvoke(string key, IFileInfoParser parser)
        {
            FileFormatToParserRegistryAction?.Invoke(key, parser);
        }
    }
}
