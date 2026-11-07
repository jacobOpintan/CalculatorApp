
using System.Globalization;

namespace CalculatorApp.Utilities;

public static class InputHelper
{
    public static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string? input = Console.ReadLine();

            if (decimal.TryParse(
                input,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal number))
            {
                return number;
            }

            Console.WriteLine(
                "Invalid input. Please enter a valid number."
            );
        }
    }

    public static int ReadMenuChoice(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= minimum &&
                choice <= maximum)
            {
                return choice;
            }

            Console.WriteLine(
                $"Invalid choice. Please enter a number between {minimum} and {maximum}."
            );
        }
    }

    public static decimal ReadPositiveDecimal(string prompt)
    {
        while (true)
        {
            decimal number = ReadDecimal(prompt);

            if (number > 0)
            {
                return number;
            }

            Console.WriteLine(
                "The value must be greater than zero. Please try again."
            );
        }
    }
}
