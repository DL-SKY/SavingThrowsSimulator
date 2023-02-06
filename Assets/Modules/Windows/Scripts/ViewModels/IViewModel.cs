using Modules.Windows.Views;
using System;

namespace Modules.Windows.ViewModels
{
    public interface IViewModel : IDisposable
    {
        event Action OnChange;
        void OnClose(IView view);
    }
}
