using Modules.Windows.ViewModels;
using System;

namespace Modules.Windows.Views
{
    public interface IView : IDisposable
    {
        IViewModel ViewModel { get; }
        bool IsAddToWindowsList { get; }
        bool IsUseEsc { get; }

        void Init(IViewModel viewModel);
        void OnClose();
    }
}
