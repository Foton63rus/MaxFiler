namespace MaxFiler
{
    internal static class AppEvents
    {
        //Событие регистрации парсера, передается расширение файла, за которое он отвечает
        internal static event Action<string, IFileInfoParser> FileFormatToParserRegistryAction;
        internal static event Action<object, string> LogAction;
        internal static event Action ClearLog;
        internal static event Action<string> InspectDirectory;
        public static void FileFormatToParserRegistryActionInvoke(string key, IFileInfoParser parser)
        {
            FileFormatToParserRegistryAction?.Invoke(key, parser);
        }
        public static void InspectDirectoryInvoke(string directory)
        {
            InspectDirectory?.Invoke(directory);
        }
        public static void LogActionInvoke(object sender, string msg)
        {
            LogAction?.Invoke(sender, msg);
        }
        public static void ClearLogInvoke()
        {
            ClearLog?.Invoke();
        }
    }
}
