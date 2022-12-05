using System;
using Core.Views;
using Action = System.Action;

namespace Calculator.Views
{
    public class CalculatorView : ApplicationView
    {
        public event Action<CalculatorValue> OnInitializedView;
        public event Action<CalculatorValue> OnLoadedViewData;
        public event Action<CalculatorValue> OnSetViewData;
        public event Action OnEnteredWrongData;
        
        protected override void OnDataInitialized(object data)
        {
            if (data is CalculatorValue value)
            {
                OnInitializedView?.Invoke(value);
            }
        }
        

        protected override void OnDataLoaded(object data)
        {
            if (data is CalculatorValue value)
            {
                SetData(value);
                OnLoadedViewData?.Invoke(value);
            }
        }


        public void SetData(CalculatorValue value)
        {
            OnSetViewData?.Invoke(value);
        }
        

        public void OnEnteredDataIsWrong()
        {
            OnEnteredWrongData?.Invoke();
        }


        public void Submit(string inputValue)
        {   
            presenter.SubmitData(new CalculatorValue(inputValue));
        }


        public void UpdateData(string inputValue)
        {
            presenter.UpdateData(new CalculatorValue(inputValue));
        }
    }
}