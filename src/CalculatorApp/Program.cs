
using CalculatorApp.Services;
using CalculatorApp.Utilities;
using CalculatorApp.Application;

namespace CalculatorApp;

internal class Program
{
    static void Main(string[] args)
    {
        var application = new CalculatorApplication(
            Console.In,
            Console.Out);

        application.Run();
    }
}