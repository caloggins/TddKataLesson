using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (InputIsEmpty(input))
                return 0;

            CheckForNegatives(input);

            var numbers = GetNumbersFromTheString(input);

            return numbers.Sum();
        }

        private static IEnumerable<int> GetNumbersFromTheString(string input)
        {
            var numbers = Regex.Matches(input, @"\d+")
                .Select(o => int.Parse(o.Value));
            return numbers;
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