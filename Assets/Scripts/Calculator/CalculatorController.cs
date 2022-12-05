using Calculator.Presenters;
using Calculator.UI;
using Calculator.Views;
using UnityEngine;

namespace Calculator
{
    public class CalculatorController : MonoBehaviour
    {
        [SerializeField] private string dataStorageKey = "calculator_session_data";

        [SerializeField] private UIController baseUIController;
        
        [SerializeField] private CalculatorView view;
        [SerializeField] private CalculatorPresenter presenter;

        private ApplicationCycleDebugger debugger;
        

        private void Awake()
        {
            presenter = new CalculatorPresenter(dataStorageKey);
            
            debugger = new ApplicationCycleDebugger(presenter);
            
            baseUIController.Initialize();

            presenter.Initialize(view);
        }



        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                presenter.PauseSession(false);
        }

        
        private void OnApplicationQuit()
        {
            debugger.Dispose();
            presenter.CancelSession();
        }
    }
}