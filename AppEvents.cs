namespace MaxFiler
{
    internal static class AppEvents
    {
        internal static event Action<string, IFileInfoParser> FileFormatToParserRegistryAction; // Уведомление парсера, что надо произвести чтение инфы

        internal static event Action<string, string> FileInfoReturnAction; // Action< filepath, json(fileinfo) > Уведомление о готовой инфе по файлу

        public static void FileFormatToParserRegistryActionInvoke(string key, IFileInfoParser parser)
        {
            FileFormatToParserRegistryAction?.Invoke(key, parser);
        }

        public static void FileInfoReturnActionInvoke(string filepath, string jsonFileInfo)
        {
            FileInfoReturnAction?.Invoke(filepath, jsonFileInfo);
        }

    }
}
