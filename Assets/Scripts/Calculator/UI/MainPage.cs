using Calculator.Views;
using UnityEngine;

namespace Calculator.UI
{
    public class MainPage : SubmitInputPage
    {
        [SerializeField] private string errorMessageValue = "Error!";
        
        [SerializeField] private CalculatorView view;

        
        public override void Initialize()
        {
            base.Initialize();
            
            view.OnInitializedView += OnInitializedView;
            view.OnLoadedViewData += OnLoadedViewData;
            view.OnEnteredWrongData += ShowErrorMessage;
            view.OnSetViewData += SetViewData;
        }

        
        private void SetViewData(CalculatorValue obj)
        {
            SetInputFieldValue(obj.Line);
        }

        
        private void ShowErrorMessage()
        {
            SetInputFieldValue(errorMessageValue);
        }

        
        private void OnLoadedViewData(CalculatorValue obj)
        {
            SetInputFieldValue(obj.Line);
        }

        
        private void OnInitializedView(CalculatorValue obj)
        {
            Show();
        }

        
        protected override void OnClickSubmitButton()
        {
            base.OnClickSubmitButton();
            
            view.Submit(inputField.text);
        }

        
        protected override void OnChangedInputFieldValue(string value)
        {
            base.OnChangedInputFieldValue(value);
            
            view.UpdateData(value);
        }

        
        private void Dispose()
        {
            view.OnInitializedView -= OnInitializedView;
            view.OnLoadedViewData -= OnLoadedViewData;
            view.OnEnteredWrongData -= ShowErrorMessage;
            view.OnSetViewData -= SetViewData;
        }

        
        private void OnDestroy()
        {
            Dispose();
        }
    }
}