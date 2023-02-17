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
            OnApdatePanelsAnchors();
        }

        public override IViewModel GetViewModel()
        {
            return _viewModel;
        }

        public override void OnChangeHadler()
        {
            OnApdatePanelsAnchors();
        }

        private void OnApdatePanelsAnchors()
        {
            var anchors = _viewModel.GetAnchors();
            for (int i = 0; i < anchors.Length; i++)
                if (i < _panels.Length)
                {
                    _panels[i].anchorMin = anchors[i].Min;
                    _panels[i].anchorMax = anchors[i].Max;
                    _panels[i].anchoredPosition = Vector2.zero;
                    _panels[i].sizeDelta = Vector2.zero;
                }
        }
    }
}
