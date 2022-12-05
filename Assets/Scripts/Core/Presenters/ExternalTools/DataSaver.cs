using Core.Models;

namespace Core.Presenters.ExternalTools
{
    public abstract class DataSaver<T> where T : IApplicationData
    {
        public abstract void Save(T data);
        public abstract T Load();
    }
}