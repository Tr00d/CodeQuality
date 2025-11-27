using FluentAssertions;

namespace CodeQuality.Samples.TestDrivenDevelopment.Calculator;


public class CalculatorTest
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
   
    public void Add_ReturnSum(int a, int b, int c)
    {
        // Arrange
        var calculator= new CalculatorEngine();
        // Act
        var result = calculator.Add(a, b);
        // Assert
        result.Should().Be(c);
    }
}

public class CalculatorEngine
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}