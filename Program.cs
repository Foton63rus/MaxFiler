using Cataloger;
using MaxFiler;
using MaxFiler.Palette;

namespace WinFormsApp1
{
    internal static class Program
    {
        private static Form1 _mainForm;
        private static MainManager _mainManager;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            _mainForm = new Form1();
            _mainManager = new MainManager();
            _mainManager.InitCataloger();
            Application.Run(_mainForm);
        }
    }
}