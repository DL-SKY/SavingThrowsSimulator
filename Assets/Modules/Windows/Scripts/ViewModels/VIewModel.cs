using Modules.StarterKIT.Services;
using Modules.Windows.Manager;
using Modules.Windows.Views;
using System;

namespace Modules.Windows.ViewModels
{
    public abstract class ViewModel : IViewModel
    {
        public event Action OnChange;

        protected WindowsManager _manager;


        protected ViewModel()
        {
            _manager = ComponentLocator.Resolve<WindowsManager>();
        }


        public void OnClose(IView view)
        {
            _manager.CloseWindow(view);
        }


        public abstract void Dispose();

        protected void SendOnChange()
        {
            OnChange?.Invoke();
        }
    }
}
