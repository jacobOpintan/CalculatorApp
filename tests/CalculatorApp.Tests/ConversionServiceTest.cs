
using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class ConversionServiceTests
{
    private readonly ConversionService _conversionService;

    public ConversionServiceTests()
    {
        _conversionService = new ConversionService();
    }

    [Fact]
    public void KilometresToMiles_ReturnsCorrectConversion()
    {
        // Arrange
        decimal kilometres = 10;

        // Act
        decimal result = _conversionService.KilometresToMiles(kilometres);

        // Assert
        Assert.Equal(6.21371m, Math.Round(result, 5));
    }

    [Fact]
    public void MilesToKilometres_ReturnsCorrectConversion()
    {
        // Arrange
        decimal miles = 10;

        // Act
        decimal result = _conversionService.MilesToKilometres(miles);

        // Assert
        Assert.Equal(16.09344m, Math.Round(result, 5));
    }

    [Fact]
    public void CelsiusToFahrenheit_ReturnsCorrectConversion()
    {
        // Arrange
        decimal celsius = 100;

        // Act
        decimal result = _conversionService.CelsiusToFahrenheit(celsius);

        // Assert
        Assert.Equal(212m, result);
    }

    [Fact]
    public void FahrenheitToCelsius_ReturnsCorrectConversion()
    {
        // Arrange
        decimal fahrenheit = 98.6m;

        // Act
        decimal result = _conversionService.FahrenheitToCelsius(fahrenheit);

        // Assert
        Assert.Equal(37m, result);
    }

    [Fact]
    public void GhsToUsd_ReturnsCorrectConversion()
    {
        // Arrange
        decimal ghsAmount = 125;
        decimal exchangeRate = 12.50m;

        // Act
        decimal result = _conversionService.GhsToUsd(
            ghsAmount,
            exchangeRate
        );

        // Assert
        Assert.Equal(10m, result);
    }

    [Fact]
    public void GhsToUsd_WithZeroExchangeRate_ThrowsException()
    {
        // Arrange
        decimal ghsAmount = 125;
        decimal exchangeRate = 0;

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _conversionService.GhsToUsd(ghsAmount, exchangeRate)
        );
    }

    [Fact]
    public void GhsToUsd_WithNegativeExchangeRate_ThrowsException()
    {
        // Arrange
        decimal ghsAmount = 125;
        decimal exchangeRate = -12.50m;

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _conversionService.GhsToUsd(ghsAmount, exchangeRate)
        );
    }
    [Fact]
    public void CelsiusToFahrenheit_ShouldHandleNegativeTemperatures()
    {
        var result = _conversionService.CelsiusToFahrenheit(-40m);

        Assert.Equal(-40m, result);
    }

    [Fact]
    public void GhsToUsd_ShouldReturnZeroWhenAmountIsZero()
    {
        var result = _conversionService.GhsToUsd(0m, 12.5m);

        Assert.Equal(0m, result);
    }

    [Fact]
public void KilometresToMilesAndBack_ShouldReturnOriginalValue()
{
    decimal originalKilometres = 100m;

    decimal miles = _conversionService.KilometresToMiles(originalKilometres);

    decimal convertedKilometres = _conversionService.MilesToKilometres(miles);

    Assert.Equal(originalKilometres, convertedKilometres);
}
}
