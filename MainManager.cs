using MaxFiler;
using MaxFiler.Palette;

namespace Cataloger
{
    internal class MainManager
    {
        private CatalogInspector inspector;

        public void InitCataloger()
        {
            AppEvents.InspectDirectory += inspect;
            PaletteFacade colorManager = new PaletteFacade();
            inspector = new CatalogInspector(colorManager);
            inspector.AddParser(new MaxInfoParser());
            inspector.InitParsers();
        }

        private void inspect(string directory)
        {
            clearLog();
            addLog($"Начало сканирования {directory}");
            try
            {
                CatalogInfo catalogInfo = inspector.InspectDirectory(directory);
            }
            catch (Exception ex)
            {

            }
        }

        private void clearLog()
        {
            AppEvents.ClearLogInvoke();
        }

        private void addLog(string msg)
        {
            AppEvents.LogActionInvoke(this, msg);
        }
    }
}