using System.Collections.Generic;

namespace StringCalcKata
{
    public class Calculator
    {
        private readonly SumHandler sumHandler;
        private readonly NegativeNumberHandler negativeNumberHandler;

        public Calculator(SumHandler sumHandler, NegativeNumberHandler negativeNumberHandler)
        {
            this.sumHandler = sumHandler;
            this.negativeNumberHandler = negativeNumberHandler;
        }
        
        public int Add(string input)
        {
            if (InputIsEmpty(input))
                return 0;

            negativeNumberHandler.Handle(input);

            return sumHandler.Handle(input);
        }
        
        private static bool InputIsEmpty(string input)
        {
            return input == "";
        }
    }
}