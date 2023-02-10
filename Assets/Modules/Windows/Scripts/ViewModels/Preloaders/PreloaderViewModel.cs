using Modules.Core.Initializing;
using Modules.StarterKIT.Services;

namespace Modules.Windows.ViewModels
{
    public class PreloaderViewModel : ViewModel
    {
        public int CurrentProgress => _currentProgress;
        protected int _currentProgress;

        public int MaxProgress => _maxProgress;
        protected int _maxProgress;

        protected ApplicationInitializer _initializer;

        public PreloaderViewModel() : base()
        {
            _currentProgress = 0;
            _maxProgress = 0;
            _initializer = ComponentLocator.Resolve<ApplicationInitializer>();

            if (_initializer)
                _initializer.OnProgressChange += OnProgressChangeHandler;
        }

        public override void Dispose()
        {
            if (_initializer)
                _initializer.OnProgressChange -= OnProgressChangeHandler;
        }

        protected void OnProgressChangeHandler(int current, int max)
        {
            _currentProgress = current;
            _maxProgress = max;

            SendOnChange();
        }
    }
}
