using MCP.DotNetMethod;
using Spectre.Console;

namespace MCP.DotNetMethod.Tests;

public class DotnetMethodHelperTests
{
    public DotnetMethodHelperTests()
    {
        AnsiConsole.Profile.Out = new AnsiConsoleOutput(TextWriter.Null);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 6)]
    [InlineData(6, 12)]
    [InlineData(12, 24)]
    public void CalculateTax_MethodCustomer_MultipliesByTwo(int months, int expected)
    {
        var result = DotnetMethodHelper.CalculateTax("Method", months);

        Assert.Contains(expected.ToString(), result);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(6, 3)]
    [InlineData(4, 2)]
    [InlineData(10, 5)]
    public void CalculateTax_TaxCustomer_DividesByTwo(int months, double expected)
    {
        var result = DotnetMethodHelper.CalculateTax("Tax", months);

        Assert.Contains(expected.ToString(), result);
    }

    [Theory]
    [InlineData("Alice", 5)]
    [InlineData("Bob", 3)]
    [InlineData("Unknown", 7)]
    public void CalculateTax_UnknownCustomer_ReturnsMonthsAsIs(string customer, int months)
    {
        var result = DotnetMethodHelper.CalculateTax(customer, months);

        Assert.Contains(months.ToString(), result);
        Assert.Contains(customer, result);
    }

    [Fact]
    public void CalculateTax_ReturnsStringContainingCustomerName()
    {
        var result = DotnetMethodHelper.CalculateTax("Method", 3);

        Assert.Contains("Method", result);
    }

    [Fact]
    public void CalculateTax_ReturnsStringContainingMonthCount()
    {
        var result = DotnetMethodHelper.CalculateTax("Method", 3);

        Assert.Contains("3", result);
    }

    [Fact]
    public void CalculateTax_ReturnsExpectedFormat()
    {
        var result = DotnetMethodHelper.CalculateTax("Method", 3);

        Assert.StartsWith("Tax for customer Method", result);
        Assert.Contains("past 3 months", result);
        Assert.Contains("6", result);
    }

    [Fact]
    public void CalculateTax_MethodCustomer_ZeroMonths_ReturnsZero()
    {
        var result = DotnetMethodHelper.CalculateTax("Method", 0);

        Assert.Contains("0", result);
    }

    [Fact]
    public void CalculateTax_TaxCustomer_ZeroMonths_ReturnsZero()
    {
        var result = DotnetMethodHelper.CalculateTax("Tax", 0);

        Assert.Contains("0", result);
    }

    [Fact]
    public void CalculateTax_UnknownCustomer_ZeroMonths_ReturnsZero()
    {
        var result = DotnetMethodHelper.CalculateTax("Other", 0);

        Assert.Contains("0", result);
    }

    [Fact]
    public void CalculateTax_ReturnsNonNullNonEmptyString()
    {
        var result = DotnetMethodHelper.CalculateTax("Method", 3);

        Assert.False(string.IsNullOrEmpty(result));
    }

    [Theory]
    [InlineData("Method", 1, 2)]
    [InlineData("Method", 5, 10)]
    [InlineData("Tax", 4, 2)]
    [InlineData("Tax", 8, 4)]
    [InlineData("Other", 3, 3)]
    public void CalculateTax_AllCases_ReturnsTaxString(string customer, int months, double expectedValue)
    {
        var result = DotnetMethodHelper.CalculateTax(customer, months);

        Assert.NotNull(result);
        Assert.Contains(customer, result);
        Assert.Contains(expectedValue.ToString(), result);
    }
}
