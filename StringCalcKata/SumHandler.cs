using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class SumHandler
    {
        public int Handle(string input)
        {
            var numbers = Regex.Matches(input, @"\d+")
                .Select(o => int.Parse((string) o.Value));
            return numbers.Sum();
        }
    }
}