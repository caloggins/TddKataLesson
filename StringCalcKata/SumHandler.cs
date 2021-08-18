using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class SumHandler
    {
        public int Handle(string input)
        {
            var numbers = Regex.Matches(input, @"\d+")
                .Select(o => int.Parse(o.Value))
                .Where(o => o <= 1000);
            return numbers.Sum();
        }
    }
}