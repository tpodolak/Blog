using Xunit;

namespace NETCoreCodeCoverage.Tests.Integration
{
    public class CalculatorTests
    {
        [Fact]
        public void Multiply_ReturnsCorrectResult()
        {
            var calculator = new Calculator();

            var result = calculator.Multiply(2, 2);
            
            Assert.Equal(4, result);
        }
    }
}