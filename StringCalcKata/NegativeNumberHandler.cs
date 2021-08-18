using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class NegativeNumberHandler : IHandler
    {
        private readonly IHandler successor;

        public NegativeNumberHandler(IHandler successor)
        {
            this.successor = successor;
        }
        
        public int Handle(string input)
        {
            ThrowExceptionWhenNegativesAreFound(input);

            return successor.Handle(input);
        }

        private static void ThrowExceptionWhenNegativesAreFound(string input)
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