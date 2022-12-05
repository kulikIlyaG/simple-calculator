using System;

namespace Core.Presenters
{
    public interface IPresenter
    {
        public event Action<object> OnInitialized;
        public event Action<object> OnPausedSession;
        public event Action<object> OnCanceledSession;

        
        public event Action<object> OnLoadedSessionData;
        public event Action<object> OnSavedSessionData;

        public void UpdateData(object data);
        public void SubmitData(object data);

    }
}