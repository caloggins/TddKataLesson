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

        [Fact]
        public void ThrowsExceptionWhenNegativeExists()
        {
            var sut = new Calculator();

            Action act = () => sut.Add("1,-2,3");

            act.Should().Throw<NegativesNotAllowedException>();
        }
    }

    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            var match = Regex.Match(input, @"-\d+");
            if (match.Success)
                throw new NegativesNotAllowedException();

            var numbers = Regex.Matches(input, @"\d+")
                .Select(o => int.Parse(o.Value));

            var sum = numbers.Sum();

            return sum;
        }
    }
}