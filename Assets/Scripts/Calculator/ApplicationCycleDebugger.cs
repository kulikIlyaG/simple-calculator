using Core.Presenters;
using UnityEngine;

namespace Calculator
{
    public class ApplicationCycleDebugger
    {
        private IPresenter presenter;
        
        
        public ApplicationCycleDebugger(IPresenter presenter)
        {
            this.presenter = presenter;
            SubscribeEvents();
        }


        public void Dispose()
        {
            UnsubscribeEvents();
        }
        
        
        private void SubscribeEvents()
        {
            presenter.OnInitialized += OnInitializedDebug;
            
            presenter.OnLoadedSessionData += OnLoadedDataDebug;
            presenter.OnSavedSessionData += OnSavedDataDebug;

            presenter.OnPausedSession += OnPausedDebug;
            presenter.OnCanceledSession += OnCanceledDebug;
        }

        
        private void OnCanceledDebug(object obj)
        {
            Debug.Log($"On canceled application!");
        }
        

        private void OnPausedDebug(object obj)
        {
            Debug.Log($"On paused/unfocus application!");
        }

        
        private void OnSavedDataDebug(object obj)
        {
            Debug.Log($"On saved application data!");
        }

        
        private void OnLoadedDataDebug(object obj)
        {
            Debug.Log($"On loaded application data!");
        }

        
        private void OnInitializedDebug(object obj)
        {
            Debug.Log($"On initialized application!");
        }
        

        private  void UnsubscribeEvents()
        {
            presenter.OnInitialized -= OnInitializedDebug;
            
            presenter.OnLoadedSessionData -= OnLoadedDataDebug;
            presenter.OnSavedSessionData -= OnSavedDataDebug;

            presenter.OnPausedSession -= OnPausedDebug;
            presenter.OnCanceledSession -= OnCanceledDebug;
        }
    }
}