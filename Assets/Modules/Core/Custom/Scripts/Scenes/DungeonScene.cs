using Modules.Dungeons.Controllers;
using Modules.StarterKIT.Services;
using Modules.Windows.Custom.ViewModels;
using Modules.Windows.Custom.Views;
using Modules.Windows.Manager;
using Modules.Windows.Views.Preloaders;
using System.Collections;
using UnityEngine;

namespace Modules.Core.Custom.Scenes
{
    public class DungeonScene : MonoBehaviour
    {
        private WindowsManager _windowsManager;
        private CameraViewportRectView _rectView;
        private Dungeon _dungeon;

        private void Start()
        {
            _windowsManager = ComponentLocator.Resolve<WindowsManager>();
            _dungeon = ComponentLocator.Resolve<Dungeon>();

            ShowRectView();
            DungeonInit();
            HidePreloaderNextFrame();
        }

        private void OnDestroy()
        {
            HideRectView();            
        }

        private void ShowRectView()
        {            
            var viewModel = new CameraViewportRectViewModel(Camera.main.rect);
            var path = "CameraViewportRectView";
            _rectView = _windowsManager.OpenWindow<CameraViewportRectView>(path, WindowLayer.Main, viewModel);
            _rectView?.transform.SetAsFirstSibling();
        }

        private void HideRectView()
        {
            if (_rectView)
                _windowsManager.CloseWindow(_rectView);
        }

        private void DungeonInit()
        {
            //TODO: config
            var config1 = "";
            var config2 = "";

            _dungeon.Init(config1, config2);
        }

        private void HidePreloader()
        {
            _windowsManager.CloseWindow(typeof(PreloaderView));
        }

        private void HidePreloaderNextFrame()
        {
            StartCoroutine(HidePreloaderRoutine());
        }

        private IEnumerator HidePreloaderRoutine()
        {
            yield return null;
            HidePreloader();
        }
    }
}
