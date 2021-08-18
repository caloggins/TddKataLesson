using FluentAssertions;
using Xunit;

namespace StringCalcKata
{
    public class CalculatorTests
    {
        [Fact]
        public void ItReturnsTheCorrectValue()
        {
            var sut = new Calculator();
            
            var result = sut.Add("");
            
            result.Should().Be(0);
        }
    }

    public class Calculator
    {
        public int Add(string input)
        {
            return -1;
        }
    }
}