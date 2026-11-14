
namespace CalculatorApp.Services;

public class ConversionService
{
    // One shared conversion factor.
    private const decimal KilometresToMilesFactor = 0.621371m;

    public decimal KilometresToMiles(decimal kilometres)
    {
        return kilometres * KilometresToMilesFactor;
    }

    public decimal MilesToKilometres(decimal miles)
    {
        return miles / KilometresToMilesFactor;
    }

    public decimal CelsiusToFahrenheit(decimal celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public decimal FahrenheitToCelsius(decimal fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public decimal GhsToUsd(decimal ghsAmount, decimal exchangeRate)
    {
        if (exchangeRate <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(exchangeRate),
                "Exchange rate must be greater than zero."
            );
        }

        return ghsAmount / exchangeRate;
    }
}
