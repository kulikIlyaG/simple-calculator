using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI
{
    public class SubmitInputPage : Page
    {
        [SerializeField] protected TMP_InputField inputField;
        [SerializeField] private Button submitButton;

        public event Action<string> OnSubmit, OnValueChanged; 

        
        private void Awake()
        {
            submitButton.onClick.AddListener(OnClickSubmitButton);
            inputField.onValueChanged.AddListener(OnChangedInputFieldValue);
        }

        
        protected virtual void OnChangedInputFieldValue(string value)
        {
            OnValueChanged?.Invoke(value);
        }
        

        public void SetInputFieldValue(string value)
        {
            inputField.text = value;
        }

        
        protected virtual void OnClickSubmitButton()
        {
            OnSubmit?.Invoke(inputField.text);
        }
    }
}