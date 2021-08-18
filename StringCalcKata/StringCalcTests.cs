using System;
using FluentAssertions;
using Xunit;

namespace StringCalcKata
{
    public class StringCalcTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1,2,3", 6)]
        [InlineData("1,1001,2",3)]
        public void ItReturnsTheCorrectResult(string input, int expected)
        {
            var sut = new Calculator();
            
            var result = sut.Add(input);
            
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,4,-1", "Negative not allowed: -1")]
        [InlineData("1,-4,-1", "Negative not allowed: -4 -1")]
        public void ItThrowsExceptionWhenWithNegatives(string input, string message)
        {
            var sut = new Calculator();

            Action act = () => sut.Add(input);

            act.Should().Throw<NegativeNotAllowedException>()
                .WithMessage(message);
        }
    }
}