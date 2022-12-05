using System.Text.RegularExpressions;

namespace Calculator.Presenters.ExternalTools
{
    public abstract class MathOperation
    {
        protected Regex regex;

        
        protected MathOperation(string regexKey)
        {
            regex = new Regex(regexKey);
        }
        

        public abstract OperationResult Calculate(string line);
    }
}