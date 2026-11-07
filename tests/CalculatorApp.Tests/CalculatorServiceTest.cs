
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
}
