using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class NegativeNumberHandler
    {
        public void Handle(string input)
        {
            var matches = Regex.Matches(input, @"-\d+")
                .Select(o => o.Value)
                .ToList();
            var found = string.Join(", ", matches);
            if (matches.Count > 0)
                throw new NegativesNotAllowedException($"Negative numbers not allowed. Found these numbers: {found}.");
        }
    }
}