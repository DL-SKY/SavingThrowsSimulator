using Modules.Windows.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Windows.Views.Preloaders
{
    public class PreloaderView : View
    {
        [SerializeField] private Slider _progressBar;

        private PreloaderViewModel _viewModel;

        public override void Init(IViewModel viewModel)
        {
            _viewModel = viewModel as PreloaderViewModel;

            Subscribe();

            OnChangeHadler();
        }

        public override IViewModel GetViewModel()
        {
            return _viewModel;
        }

        public override void OnChangeHadler()
        {
            var progress = Mathf.InverseLerp(0, _viewModel.MaxProgress, _viewModel.CurrentProgress);
            _progressBar.value = progress;
        }
    }
}
