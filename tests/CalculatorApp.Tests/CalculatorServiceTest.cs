
using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class CalculatorServiceTests
{
    private readonly CalculatorService _calculator;

    public CalculatorServiceTests()
    {
        _calculator = new CalculatorService();
    }

    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectSum()
    {
        // Arrange
        decimal firstNumber = 10;
        decimal secondNumber = 5;

        // Act
        decimal result = _calculator.Add(firstNumber, secondNumber);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        decimal firstNumber = 10;
        decimal secondNumber = 5;

        // Act
        decimal result = _calculator.Subtract(firstNumber, secondNumber);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        decimal firstNumber = 10;
        decimal secondNumber = 5;

        // Act
        decimal result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        Assert.Equal(50, result);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        decimal firstNumber = 10;
        decimal secondNumber = 5;

        // Act
        decimal result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        decimal firstNumber = 10;
        decimal secondNumber = 0;

        // Act and Assert
        Assert.Throws<DivideByZeroException>(
            () => _calculator.Divide(firstNumber, secondNumber)
        );
    }
    [Fact]
    public void Add_ShouldHandleNegativeNumbers()
    {
        var result = _calculator.Add(-10m, 5m);

        Assert.Equal(-5m, result);
    }

    [Fact]
    public void Multiply_ShouldHandleDecimalNumbers()
    {
        var result = _calculator.Multiply(2.5m, 4m);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void Divide_ShouldReturnDecimalResult()
    {
        var result = _calculator.Divide(5m, 2m);

        Assert.Equal(2.5m, result);
    }

    [Fact]
public void Multiply_ShouldThrowOverflowException_WhenResultExceedsDecimalRange()
{
    Assert.Throws<OverflowException>(() =>
        _calculator.Multiply(decimal.MaxValue, 2m));
}
}
