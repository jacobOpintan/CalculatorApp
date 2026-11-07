
using CalculatorApp.Services;
using CalculatorApp.Utilities;

namespace CalculatorApp;

internal class Program
{
    private static readonly CalculatorService Calculator = new();
    private static readonly ConversionService Converter = new();

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n===== SMART CALCULATOR =====");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Unit Converter");
            Console.WriteLine("0. Exit");

            int choice = InputHelper.ReadMenuChoice(
                "Select an option: ", 0, 2
            );

            switch (choice)
            {
                case 1:
                    RunCalculator();
                    break;

                case 2:
                    RunConverter();
                    break;

                case 0:
                    isRunning = false;
                    Console.WriteLine("Thank you for using SmartCalculator!");
                    break;
            }
        }
    }

    private static void RunCalculator()
    {
        bool returnToMainMenu = false;

        while (!returnToMainMenu)
        {
            Console.WriteLine("\n===== CALCULATOR =====");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("0. Back to Main Menu");

            int choice = InputHelper.ReadMenuChoice(
                "Select an operation: ", 0, 4
            );

            if (choice == 0)
            {
                returnToMainMenu = true;
                continue;
            }

            decimal firstNumber = InputHelper.ReadDecimal(
                "Enter first number: "
            );

            decimal secondNumber = InputHelper.ReadDecimal(
                "Enter second number: "
            );

            try
            {
                decimal result = choice switch
                {
                    1 => Calculator.Add(firstNumber, secondNumber),
                    2 => Calculator.Subtract(firstNumber, secondNumber),
                    3 => Calculator.Multiply(firstNumber, secondNumber),
                    4 => Calculator.Divide(firstNumber, secondNumber),
                    _ => throw new InvalidOperationException(
                        "Invalid calculator operation."
                    )
                };

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void RunConverter()
    {
        bool returnToMainMenu = false;

        while (!returnToMainMenu)
        {
            Console.WriteLine("\n===== UNIT CONVERTER =====");
            Console.WriteLine("1. Kilometres to Miles");
            Console.WriteLine("2. Miles to Kilometres");
            Console.WriteLine("3. Celsius to Fahrenheit");
            Console.WriteLine("4. Fahrenheit to Celsius");
            Console.WriteLine("5. GHS to USD");
            Console.WriteLine("0. Back to Main Menu");

            int choice = InputHelper.ReadMenuChoice(
                "Select a conversion: ", 0, 5
            );

            if (choice == 0)
            {
                returnToMainMenu = true;
                continue;
            }

            decimal value = InputHelper.ReadDecimal(
                "Enter the value to convert: "
            );

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(
                            $"{value} km = {Converter.KilometresToMiles(value)} miles"
                        );
                        break;

                    case 2:
                        Console.WriteLine(
                            $"{value} miles = {Converter.MilesToKilometres(value)} km"
                        );
                        break;

                    case 3:
                        Console.WriteLine(
                            $"{value} °C = {Converter.CelsiusToFahrenheit(value)} °F"
                        );
                        break;

                    case 4:
                        Console.WriteLine(
                            $"{value} °F = {Converter.FahrenheitToCelsius(value)} °C"
                        );
                        break;

                    case 5:
                        decimal exchangeRate = InputHelper.ReadPositiveDecimal(
                            "Enter exchange rate (1 USD in GHS): "
                        );

                        decimal usd = Converter.GhsToUsd(
                            value, exchangeRate
                        );

                        Console.WriteLine(
                            $"{value} GHS = {usd:F2} USD"
                        );
                        break;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
