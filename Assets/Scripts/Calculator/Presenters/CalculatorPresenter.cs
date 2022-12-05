using System;
using Calculator.Models;
using Calculator.Presenters.ExternalTools;
using Calculator.Views;
using Core.Presenters;

namespace Calculator.Presenters
{
    [Serializable]
    public class CalculatorPresenter : ApplicationPresenter<BaseCalculatorData, CalculatorView>
    {
        private MathOperation operation;

        
        public CalculatorPresenter(string dataStorageKey)
        {
            saver = new JsonSaver(dataStorageKey);

            operation = new PlusOperation();
        }
        

        public override void SubmitData(object updatedData)
        {
            OperationResult result = operation.Calculate(data.GetValue());

            if (result.IsSuccessfully)
            {
                data.SetValue(result.Value.ToString());

                view.SetData((CalculatorValue)GetViewData());
            }
            else
            {
                view.OnEnteredDataIsWrong();
            }
        }
        

        public override void UpdateData(object updatedData)
        {
            if (updatedData is CalculatorValue value)
            {
                data.SetValue(value.Line);

                SaveSessionData();
            }
        }


        protected override object GetViewData()
        {
            return new CalculatorValue(data.GetValue());
        }
    }
}