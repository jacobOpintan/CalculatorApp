using CalculatorApp.Application;

namespace CalculatorApp;

public class CalculatorApplicationTests
{
    [Fact]
    public void Run_ShouldDisplayMainMenu()
    {
        using var reader = new StringReader("0");
        using var writer = new StringWriter();

        var application = new CalculatorApplication(
            reader, writer);

        application.Run();

        string output = writer.ToString();

        Assert.Contains("SMART CALCULATOR", output);
        Assert.Contains("1. Calculator", output);
        Assert.Contains("2. Unit Converter", output);
        Assert.Contains("Thank you for using Smart Calculator!", output);
    }

    [Fact]
    public void Run_ShouldPerformAddition()
    {
        using var reader = new StringReader("1\n1\n10\n5\n0\n0");
        using var writer = new StringWriter();

        var application = new CalculatorApplication(
            reader, writer);

        application.Run();

        Assert.Contains("Result: 15", writer.ToString());
    }

    [Fact]
    public void Run_ShouldExitWhenInputStreamEnds()
    {
        using var reader = new StringReader("");
        using var writer = new StringWriter();

        var application = new CalculatorApplication(
            reader, writer);

        application.Run();

        Assert.Contains("SMART CALCULATOR", writer.ToString());
    }

    [Fact]
    public void Run_ShouldReturnToMainMenuFromCalculator()
    {
        using var reader = new StringReader("1\n0\n0");
        using var writer = new StringWriter();

        var application = new CalculatorApplication(
            reader, writer);

        application.Run();

        string output = writer.ToString();

        Assert.Contains("===== CALCULATOR =====", output);
        Assert.Contains("===== SMART CALCULATOR =====", output);
    }

    [Fact]
public void Run_ShouldDisplayFriendlyMessage_WhenCalculationOverflows()
{
    using var reader = new StringReader(
        "1\n3\n79228162514264337593543950335\n2\n0\n0");

    using var writer = new StringWriter();

    var application = new CalculatorApplication(reader, writer);

    application.Run();

    Assert.Contains(
        "calculation result is too large or too small",
        writer.ToString());
}[Fact]
public void Run_ShouldFormatCalculationResultToFourDecimalPlaces()
{
    using var reader = new StringReader("1\n4\n10\n3\n0\n0");
    using var writer = new StringWriter();

    var application = new CalculatorApplication(reader, writer);

    application.Run();

    Assert.Contains("Result: 3.3333", writer.ToString());
}

[Fact]
public void ProgramRun_ShouldUseProvidedInputAndOutputStreams()
{
    using var reader = new StringReader("0");
    using var writer = new StringWriter();

    Program.Run(reader, writer);

    Assert.Contains(
        "Thank you for using Smart Calculator!",
        writer.ToString()); 
}


}
