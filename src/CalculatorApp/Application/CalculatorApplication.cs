using CalculatorApp.Services;
using CalculatorApp.Utilities;
namespace CalculatorApp.Application;

public class CalculatorApplication
{
    
    private readonly CalculatorService _calculator;
    private readonly ConversionService _converter;

    private readonly TextReader _reader;
    private readonly TextWriter _writer;

    public CalculatorApplication(TextReader reader, TextWriter writer)
    {
        _reader =reader;
        _writer= writer;
        _calculator = new CalculatorService();
        _converter = new ConversionService();
    }

     public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            _writer.WriteLine("\n===== SMART CALCULATOR =====");
            _writer.WriteLine("1. Calculator");
            _writer.WriteLine("2. Unit Converter");
            _writer.WriteLine("0. Exit");

            int? choice = InputHelper.ReadMenuChoice(
                "Select an option: ",
                0,
                2,
                _reader,
                _writer);

            if (choice is null)
            {
                break;
            }

            switch (choice.Value)
            {
                case 1:
                    RunCalculator();
                    break;

                case 2:
                    RunConverter();
                    break;

                case 0:
                    isRunning = false;
                    _writer.WriteLine(
                        "Thank you for using Smart Calculator!");
                    break;
            }
        }
    }

    private void RunCalculator()
    {
        bool returnToMainMenu = false;

        while (!returnToMainMenu)
        {
            _writer.WriteLine("\n===== CALCULATOR =====");
            _writer.WriteLine("1. Addition");
            _writer.WriteLine("2. Subtraction");
            _writer.WriteLine("3. Multiplication");
            _writer.WriteLine("4. Division");
            _writer.WriteLine("0. Back to Main Menu");

            int? choice = InputHelper.ReadMenuChoice(
                "Select an operation: ",
                0,
                4,
                _reader,
                _writer);

            if (choice is null)
            {
                return;
            }

            if (choice.Value == 0)
            {
                returnToMainMenu = true;
                continue;
            }

            decimal? firstNumber = InputHelper.ReadDecimal(
                "Enter first number: ",
                _reader,
                _writer);

            if (firstNumber is null)
            {
                return;
            }

            decimal? secondNumber = InputHelper.ReadDecimal(
                "Enter second number: ",
                _reader,
                _writer);

            if (secondNumber is null)
            {
                return;
            }

            try
            {
                decimal result = choice.Value switch
                {
                    1 => _calculator.Add(
                        firstNumber.Value, secondNumber.Value),

                    2 => _calculator.Subtract(
                        firstNumber.Value, secondNumber.Value),

                    3 => _calculator.Multiply(
                        firstNumber.Value, secondNumber.Value),

                    4 => _calculator.Divide(
                        firstNumber.Value, secondNumber.Value),

                    _ => throw new InvalidOperationException(
                        "Invalid calculator operation.")
                };

                _writer.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                _writer.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                _writer.WriteLine(
                    "Error: The calculation result is too large or too small to be represented."
                );
            }
                    }
                }

    private void RunConverter()
    {
        bool returnToMainMenu = false;

        while (!returnToMainMenu)
        {
            _writer.WriteLine("\n===== UNIT CONVERTER =====");
            _writer.WriteLine("1. Kilometres to Miles");
            _writer.WriteLine("2. Miles to Kilometres");
            _writer.WriteLine("3. Celsius to Fahrenheit");
            _writer.WriteLine("4. Fahrenheit to Celsius");
            _writer.WriteLine("5. GHS to USD");
            _writer.WriteLine("0. Back to Main Menu");

            int? choice = InputHelper.ReadMenuChoice(
                "Select a conversion: ",
                0,
                5,
                _reader,
                _writer);

            if (choice is null)
            {
                return;
            }

            if (choice.Value == 0)
            {
                returnToMainMenu = true;
                continue;
            }

            decimal? value = InputHelper.ReadDecimal(
                "Enter the value to convert: ",
                _reader,
                _writer);

            if (value is null)
            {
                return;
            }

            try
            {
                switch (choice.Value)
                {
                    case 1:
                        _writer.WriteLine(
                            $"{value.Value} km = {_converter.KilometresToMiles(value.Value)} miles");
                        break;

                    case 2:
                        _writer.WriteLine(
                            $"{value.Value} miles = {_converter.MilesToKilometres(value.Value)} km");
                        break;

                    case 3:
                        _writer.WriteLine(
                            $"{value.Value} °C = {_converter.CelsiusToFahrenheit(value.Value)} °F");
                        break;

                    case 4:
                        _writer.WriteLine(
                            $"{value.Value} °F = {_converter.FahrenheitToCelsius(value.Value)} °C");
                        break;

                    case 5:
                        decimal? exchangeRate =
                            InputHelper.ReadPositiveDecimal(
                                "Enter exchange rate (1 USD in GHS): ",
                                _reader,
                                _writer);

                        if (exchangeRate is null)
                        {
                            return;
                        }

                        decimal usd = _converter.GhsToUsd(
                            value.Value,
                            exchangeRate.Value);

                        _writer.WriteLine(
                            $"{value.Value} GHS = {usd:F2} USD");
                        break;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _writer.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                _writer.WriteLine("Error: The conversion result is too large or too small to be represented");
            }
        }   
    }

}
