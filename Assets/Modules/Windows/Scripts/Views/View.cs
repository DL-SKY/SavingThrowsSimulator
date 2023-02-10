using Modules.Windows.ViewModels;
using UnityEngine;

namespace Modules.Windows.Views
{
    public abstract class View : MonoBehaviour, IView
    {
        public IViewModel ViewModel { get { return GetViewModel(); } }
        
        public bool IsAddToWindowsList => _isAddToWindowsList;
        [SerializeField] protected bool _isAddToWindowsList = true;

        public bool IsUseEsc => _isUseEsc;
        [SerializeField] protected bool _isUseEsc = true;


        protected virtual void OnDestroy()
        {
            Dispose();
        }


        public abstract void Init(IViewModel viewModel);
        public abstract IViewModel GetViewModel();
        public abstract void OnChangeHadler();

        public void OnClose()
        {
            ViewModel.OnClose(this);
        }

        public virtual void Dispose()
        {
            Unsubscribe();
            ViewModel?.Dispose();
            Destroy(gameObject);
        }


        protected virtual void Subscribe()
        {
            if (ViewModel != null)
                ViewModel.OnChange += OnChangeHadler;
        }

        protected virtual void Unsubscribe()
        {
            if (ViewModel != null)
                ViewModel.OnChange -= OnChangeHadler;
        }
    }
}
