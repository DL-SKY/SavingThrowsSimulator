using Modules.Windows.ViewModels;
using Modules.Windows.Views;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Windows.Manager
{
    public enum WindowLayer
    { 
        Main = 0,
        Dialog = 5,
        Priority = 10,
        Loader = 15,
        Error = 20,
    }

    [Serializable]
    public class WindowLayerItem
    {
        public WindowLayer layer;
        public Canvas canvas;
    }

    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private WindowLayerItem[] _layersArray;

        private Dictionary<WindowLayer, Transform> _layers = new Dictionary<WindowLayer, Transform>();
        private List<IView> _windows = new List<IView>();


        private void Awake()
        {
            InitializeLayersDictionary();
        }


        public T OpenWindow<T>(string path, WindowLayer layer, IViewModel viewModel) where T : View
        {
            var prefab = Resources.Load<T>(path);
            return OpenWindow(prefab, layer, viewModel);
        }

        public T OpenWindow<T>(T prefab, WindowLayer layer, IViewModel viewModel) where T : View
        {
            var window = Instantiate<T>(prefab, GetLayerHolder(layer));
            if (window.IsAddToWindowsList)
                _windows.Add(window);
            window.Init(viewModel);
            return window;
        }

        public void CloseWindow(IView window)
        {
            window.Dispose();
            _windows.Remove(window);
        }


        private void InitializeLayersDictionary()
        {
            _layers.Clear();
            foreach (var item in _layersArray)
                if (!_layers.ContainsKey(item.layer))
                {
                    item.canvas.sortingOrder = (int)item.layer;
                    _layers.Add(item.layer, item.canvas.transform);
                }
        }

        private Transform GetLayerHolder(WindowLayer layer)
        {
            if (_layers.ContainsKey(layer))
                return _layers[layer];
            else
                return transform;
        }
    }
}
