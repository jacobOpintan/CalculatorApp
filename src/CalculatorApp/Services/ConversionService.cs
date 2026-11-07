
namespace CalculatorApp.Services;

public class ConversionService
{
    private const decimal KilometresToMilesFactor = 0.621371m;
    private const decimal MilesToKilometresFactor = 1.609344m;

    public decimal KilometresToMiles(decimal kilometres)
    {
        return kilometres * KilometresToMilesFactor;
    }

    public decimal MilesToKilometres(decimal miles)
    {
        return miles * MilesToKilometresFactor;
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
