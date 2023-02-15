using Modules.Windows.Custom.ViewModels;
using Modules.Windows.ViewModels;
using Modules.Windows.Views;
using UnityEngine;

namespace Modules.Windows.Custom.Views
{
    public class CameraViewportRectView : View
    {
        [SerializeField] private RectTransform[] _panels;

        private CameraViewportRectViewModel _viewModel;
        

        public override void Init(IViewModel viewModel)
        {
            _viewModel = viewModel as CameraViewportRectViewModel;
        }

        public override IViewModel GetViewModel()
        {
            return _viewModel;
        }

        public override void OnChangeHadler()
        {

        }
    }
}
