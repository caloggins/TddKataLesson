using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class GetSumHandler : Handler
    {
        public override int Handle(string input)
        {
            var numbers = GetRawNumbers(input);
            
            const int threshold = 1000;
            return numbers
                .Where(o => o <= threshold)
                .Sum();
        }

        private static IEnumerable<int> GetRawNumbers(string input)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(input);

            foreach (var match in matches)
                yield return int.Parse(match.ToString() ?? string.Empty);
        }
    }
}