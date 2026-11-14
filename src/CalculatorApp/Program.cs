
using CalculatorApp.Services;
using CalculatorApp.Utilities;
using CalculatorApp.Application;

namespace CalculatorApp;

public static class Program
{
    public static void Main(string[] args)
    {
        Run(Console.In, Console.Out);
    }

    public static void Run(TextReader reader, TextWriter writer)
    {
        var application = new CalculatorApplication(reader, writer);

        application.Run();
    }
}