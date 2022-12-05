using System;

namespace Calculator.Presenters.ExternalTools
{
    public class PlusOperation : MathOperation
    {
        private const char OPERATION_CHAR = '+';
        private const string REGEX_KEY =  "^(\\d+[{0}])+\\d+$";
        
        
        public PlusOperation() : base(string.Format(REGEX_KEY, OPERATION_CHAR))
        {
        }

        
        public override OperationResult Calculate(string line)
        {
            if (regex.IsMatch(line))
            {
                string[] split = line.Split(OPERATION_CHAR);

                int a = Convert.ToInt32(split[0]);
                int b = Convert.ToInt32(split[1]);

                return new OperationResult(true, a + b);
            }

            return new OperationResult(false, 0);
        }
    }
}