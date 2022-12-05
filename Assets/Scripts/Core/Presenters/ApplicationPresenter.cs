using System;
using Core.Models;
using Core.Presenters.ExternalTools;
using Core.Views;
using UnityEngine;

namespace Core.Presenters
{
    [Serializable]
    public abstract class ApplicationPresenter<TData, TView> : IPresenter where TData : IApplicationData where TView : ApplicationView
    {
        [SerializeField] protected TData data;

        [SerializeField] protected TView view;
        
        protected DataSaver<TData> saver;
        
        
        public event Action<object> OnInitialized;
        public event Action<object> OnPausedSession;
        public event Action<object> OnCanceledSession; 

        public event Action<object> OnLoadedSessionData;
        public event Action<object> OnSavedSessionData;
        
        
        public abstract void UpdateData(object data);
        public abstract void SubmitData(object data);


        public void Initialize(TView view)
        {
            this.view = view;
            this.view.Initialize(this);
            
            InitializeProcess();
            
            OnInitialized?.Invoke(GetViewData());
        }


        protected virtual void InitializeProcess()
        {
            LoadSessionData();
        }


        public void PauseSession(bool saveSession)
        {
            PauseSessionProcess(saveSession);
            
            OnPausedSession?.Invoke(GetViewData());
        }


        protected virtual void PauseSessionProcess(bool save = true)
        {
            if(save)
                SaveSessionData();
        }


        public void CancelSession()
        {
            CancelSessionProcess();
            
            OnCanceledSession?.Invoke(GetViewData());
        }

        
        protected virtual void CancelSessionProcess()
        {
            SaveSessionData();
        }


        private void LoadSessionData()
        {
            data = saver.Load();
            
            OnLoadedSessionData?.Invoke(GetViewData());
        }
        

        protected void SaveSessionData()
        {
            saver.Save(data);
            
            OnSavedSessionData?.Invoke(GetViewData());
        }

        protected abstract object GetViewData();
    }
}