using System;
using FluentAssertions;
using Xunit;

namespace StringCalcKata
{
    public class CalculatorTests
    {
        private readonly Calculator sut;

        public CalculatorTests()
        {
            sut = new Calculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,1001,3", 4)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2;3", 6)]
        public void ItReturnsTheCorrectResult(string input, int expected)
        {
            var result = sut.Add(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,-2,3", "Negative numbers not allowed. Found these numbers: -2.")]
        [InlineData("1,-2,-33", "Negative numbers not allowed. Found these numbers: -2, -33.")]
        public void ThrowsExceptionWhenNegativeExists(string input, string message)
        {
            Action act = () => sut.Add(input);

            act.Should().Throw<NegativesNotAllowedException>()
                .WithMessage(message);
        }
    }
}