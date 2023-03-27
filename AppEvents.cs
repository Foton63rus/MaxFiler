namespace MaxFiler
{
    internal static class AppEvents
    {
        internal static event Action<string, IFileInfoParser> fileFormatToParserRegistryAction;

        public static void fileFormatToParserRegistryActionInvoker(string key, IFileInfoParser parser)
        {
            fileFormatToParserRegistryAction.Invoke(key, parser);
        }
    }
}
