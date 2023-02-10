using Modules.Windows.Manager;
using Modules.Windows.ViewModels;
using Modules.Windows.Views.Preloaders;

namespace Modules.Core.Initializing.Subtasks
{
    public class ShowPreloaderViewTask : Subtask
    {
        public override int Weight => 1;

        private WindowsManager _windowsManager;
        private string _path;

        public ShowPreloaderViewTask(WindowsManager windowsManager, string path)
        {
            _windowsManager = windowsManager;
            _path = path;
        }

        public override void Run()
        {
            if (_windowsManager == null)
            {
                Fail(1);
                return;
            }

            var viewModel = new PreloaderViewModel();
            _windowsManager.OpenWindow<PreloaderView>(_path, WindowLayer.Loader, viewModel);

            Complete();
        }
    }
}
