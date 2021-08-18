using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace StringCalcKata
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2;3", 6)]
        public void ItReturnsTheCorrectResult(string input, int expected)
        {
            var sut = new Calculator();

            var result = sut.Add(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,-2,3", "Negative numbers not allowed. Found: -2.")]
        [InlineData("1,-2,-33", "Negative numbers not allowed. Found: -2, -33.")]
        public void ThrowsExceptionWhenNegativeExists(string input, string message)
        {
            var sut = new Calculator();

            Action act = () => sut.Add(input);

            act.Should().Throw<NegativesNotAllowedException>()
                .WithMessage(message);
        }
    }

    public class Calculator
    {
        public int Add(string input)
        {
            if (InputIsEmpty(input))
                return 0;

            CheckForNegatives(input);

            var numbers = Regex.Matches(input, @"\d+")
                .Select(o => int.Parse(o.Value));

            var sum = numbers.Sum();

            return sum;
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