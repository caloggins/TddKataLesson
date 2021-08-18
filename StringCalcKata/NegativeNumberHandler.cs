using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class NegativeNumberHandler : Handler
    {
        private readonly Handler successor = new GetSumHandler();

        public override int Handle(string input)
        {
            ThrowExceptionWhenThereAreNegatives(input);

            return successor.Handle(input);
        }

        private static void ThrowExceptionWhenThereAreNegatives(string input)
        {
            var matches = Regex.Matches(input, @"-\d+");
            var negatives = matches.Select(o => o.Value)
                .ToList();

            if (negatives.Count <= 0)
                return;

            var joined = string.Join(" ", negatives);
            throw new NegativeNotAllowedException($"Negative not allowed: {joined}");
        }
    }
}