using System;
using Core.Models;
using UnityEngine;

namespace Calculator.Models
{
    [Serializable]
    public class BaseCalculatorData : IApplicationData
    {
        public static BaseCalculatorData Empty => new ();


        [SerializeField]
        private string value = string.Empty;

        
        public event Action<string> OnChangedValue;

        public void SetValue(string value)
        {
            this.value = value;
            
            OnChangedValue?.Invoke(this.value);
        }
        
        
        public string GetValue()
        {
            return value;
        }
    }
}