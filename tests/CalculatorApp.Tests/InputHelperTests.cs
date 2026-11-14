using CalculatorApp.Utilities;

namespace CalculatorApp;

public class InputHelperTests
{
    [Fact]
    public void ReadDecimal_ShouldReturnValidNumber()
    {
        using var reader = new StringReader("25.50");
        using var writer = new StringWriter();

        decimal? result = InputHelper.ReadDecimal(
            "Enter number: ", reader, writer);

        Assert.Equal(25.50m, result);
    }

    [Fact]
    public void ReadDecimal_ShouldRetryWhenInputIsInvalid()
    {
        using var reader = new StringReader("hello\n25.50");
        using var writer = new StringWriter();

        decimal? result = InputHelper.ReadDecimal(
            "Enter number: ", reader, writer);

        Assert.Equal(25.50m, result);
        Assert.Contains("Invalid input", writer.ToString());
    }

    [Fact]
    public void ReadDecimal_ShouldReturnNullWhenInputEnds()
    {
        using var reader = new StringReader("");
        using var writer = new StringWriter();

        decimal? result = InputHelper.ReadDecimal(
            "Enter number: ", reader, writer);

        Assert.Null(result);
    }

    [Fact]
    public void ReadMenuChoice_ShouldRejectOutOfRangeChoice()
    {
        using var reader = new StringReader("9\n1");
        using var writer = new StringWriter();

        int? result = InputHelper.ReadMenuChoice(
            "Select: ", 0, 2, reader, writer);

        Assert.Equal(1, result);
        Assert.Contains("Invalid choice", writer.ToString());
    }

    [Fact]
    public void ReadMenuChoice_ShouldReturnNullWhenInputEnds()
    {
        using var reader = new StringReader("");
        using var writer = new StringWriter();

        int? result = InputHelper.ReadMenuChoice(
            "Select: ", 0, 2, reader, writer);

        Assert.Null(result);
    }

    [Fact]
    public void ReadPositiveDecimal_ShouldRejectZeroAndNegativeValues()
    {
        using var reader = new StringReader("-5\n0\n12.50");
        using var writer = new StringWriter();

        decimal? result = InputHelper.ReadPositiveDecimal(
            "Enter rate: ", reader, writer);

        Assert.Equal(12.50m, result);
        Assert.Contains("greater than zero", writer.ToString());
    }
}
