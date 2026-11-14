
using System.Globalization;

namespace CalculatorApp.Utilities;

public static class InputHelper
{
    public static decimal? ReadDecimal (string prompt,TextReader reader, TextWriter writer)
    {
        while (true)
        {
            writer.Write(prompt);

            string? input =reader.ReadLine();

            //Null means the input stream has ended
            if (input is null)
            {
                return null;
            }
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number))
            {
                return number;
            }

            writer.WriteLine("Invalid input .Please enter a valid number");

        }
    }

    public static int? ReadMenuChoice(string prompt, int minimum, int maximum, TextReader reader, TextWriter writer)
    {
        while (true)
        {
            writer.Write(prompt);
            string? input =reader.ReadLine();
            if (input is null)
            {
                return null;
            }

            if (int.TryParse(input, out int choice) && choice>=minimum && choice <= maximum)
            {
                return choice;
            }
            writer.WriteLine($"Invalid choice. Please enter a number between {minimum} and {maximum}");
        }
    }

    public static decimal? ReadPositiveDecimal (string prompt, TextReader reader, TextWriter writer)
    {
        while (true)
        {
            decimal? number= ReadDecimal(prompt,reader,writer);
            if (number is null)
            {
                return null;

            }
            if (number > 0)
            {
                return number;
            }

            writer.WriteLine("The value must be greater than zero . Please try again");

        }
    }
}