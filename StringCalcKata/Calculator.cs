using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class Calculator
    {
        private readonly SumHandler sumHandler = new SumHandler();
        
        public int Add(string input)
        {
            if (InputIsEmpty(input))
                return 0;

            CheckForNegatives(input);

            return sumHandler.Handle(input);
        }
        
        private static void CheckForNegatives(string input)
        {
            var matches = Regex.Matches(input, @"-\d+")
                .Select(o => o.Value)
                .ToList();
            var found = string.Join(", ", matches);
            if (matches.Count > 0)
                throw new NegativesNotAllowedException($"Negative numbers not allowed. Found: {found}.");
        }

        private static bool InputIsEmpty(string input)
        {
            return input == "";
        }
    }
}