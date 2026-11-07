
namespace CalculatorApp.Services;

public class CalculatorService
{
    public decimal Add(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public decimal Subtract(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber - secondNumber;
    }

    public decimal Multiply(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber * secondNumber;
    }

    public decimal Divide(decimal firstNumber, decimal secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return firstNumber / secondNumber;
    }
}
