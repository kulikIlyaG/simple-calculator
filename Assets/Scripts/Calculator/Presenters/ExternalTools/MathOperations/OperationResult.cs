namespace Calculator.Presenters.ExternalTools
{
    public struct OperationResult
    {
        public bool IsSuccessfully;
        
        public float Value;

        
        public OperationResult(bool isSuccessfully, float value)
        {
            IsSuccessfully = isSuccessfully;
            Value = value;
        }
    }
}