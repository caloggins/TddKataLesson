using System.Collections.Generic;

namespace StringCalcKata
{
    public class Calculator
    {
        private readonly SumHandler sumHandler = new SumHandler();
        private readonly NegativeNumberHandler negativeNumberHandler = new NegativeNumberHandler();
        
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