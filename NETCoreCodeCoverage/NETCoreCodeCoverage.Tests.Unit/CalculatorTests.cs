using Xunit;

namespace NETCoreCodeCoverage.Tests.Unit
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectResult()
        {
            var calculator = new Calculator();

            var result = calculator.Add(3, 2);

            Assert.Equal(5, result);
        }
    }
}