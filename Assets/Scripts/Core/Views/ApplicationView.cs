using System;
using Core.Presenters;
using UnityEngine;

namespace Core.Views
{
    public abstract class ApplicationView : MonoBehaviour
    {
        protected IPresenter presenter;

        public virtual void Initialize(IPresenter presenter)
        {
            this.presenter = presenter;
            
            presenter.OnInitialized += OnDataInitialized;
            presenter.OnLoadedSessionData += OnDataLoaded;
            presenter.OnCanceledSession += OnQuitApplication;
        }


        protected abstract void OnDataInitialized(object data);
        protected abstract void OnDataLoaded(object data);

        
        protected virtual void OnQuitApplication(object obj)
        {
            Dispose();
        }

        protected virtual void Dispose()
        {
            presenter.OnInitialized -= OnDataInitialized;
            presenter.OnSavedSessionData -= OnDataInitialized;
            presenter.OnCanceledSession -= OnQuitApplication;
        }
    }
}
