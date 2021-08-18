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

        [Fact]
        public void ItReturnsValueWhenStringContainsNumber()
        {
            var sut = new Calculator();

            var result = sut.Add("1");

            result.Should().Be(1);
        }

        [Fact]
        public void ItReturnsTheSumWhenThereIsMoreThanOneNumber()
        {
            var sut = new Calculator();

            var result = sut.Add("1,2");

            result.Should().Be(3);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void TestName(string input, int expected)
        {
            var sut = new Calculator();

            var result = sut.Add(input);

            result.Should().Be(expected);
        }
    }

    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 1;

            if (input == "1")
                return 2;

            return 4;
        }
    }
}