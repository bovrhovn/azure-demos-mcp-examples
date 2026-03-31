using MCP.DotNetMethod;
using Microsoft.Extensions.AI;
using Spectre.Console;

namespace MCP.DotNetMethod.Tests;

public class ChatConfigurationTests
{
    public ChatConfigurationTests()
    {
        AnsiConsole.Profile.Out = new AnsiConsoleOutput(TextWriter.Null);
    }

    [Fact]
    public void AIFunction_IsCreatedWithCorrectName()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        Assert.Equal("get_tax_for_customer", function.Name);
    }

    [Fact]
    public void AIFunction_HasCorrectDescription()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        Assert.Equal("Gets tax for customer for specific period of month", function.Description);
    }

    [Fact]
    public void AIFunction_IsNotNull()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        Assert.NotNull(function);
    }

    [Fact]
    public async Task AIFunction_Invoke_MethodCustomer_ReturnsCorrectTax()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        var args = new AIFunctionArguments(new Dictionary<string, object?> { ["customer"] = "Method", ["forMonths"] = 3 });
        var result = await function.InvokeAsync(args);

        Assert.NotNull(result);
        Assert.Contains("6", result.ToString());
        Assert.Contains("Method", result.ToString());
    }

    [Fact]
    public async Task AIFunction_Invoke_TaxCustomer_ReturnsHalvedValue()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        var args = new AIFunctionArguments(new Dictionary<string, object?> { ["customer"] = "Tax", ["forMonths"] = 6 });
        var result = await function.InvokeAsync(args);

        Assert.NotNull(result);
        Assert.Contains("3", result.ToString());
    }

    [Fact]
    public async Task AIFunction_Invoke_UnknownCustomer_ReturnsMonthsPassthrough()
    {
        var function = AIFunctionFactory.Create(
            DotnetMethodHelper.CalculateTax,
            "get_tax_for_customer",
            "Gets tax for customer for specific period of month");

        var args = new AIFunctionArguments(new Dictionary<string, object?> { ["customer"] = "Alice", ["forMonths"] = 5 });
        var result = await function.InvokeAsync(args);

        Assert.NotNull(result);
        Assert.Contains("5", result.ToString());
        Assert.Contains("Alice", result.ToString());
    }

    [Fact]
    public void ChatOptions_ContainsOneTool()
    {
        var chatOptions = new ChatOptions
        {
            Tools =
            [
                AIFunctionFactory.Create(
                    DotnetMethodHelper.CalculateTax,
                    "get_tax_for_customer",
                    "Gets tax for customer for specific period of month")
            ]
        };

        Assert.NotNull(chatOptions.Tools);
        Assert.Single(chatOptions.Tools);
    }

    [Fact]
    public void ChatOptions_ToolIsAIFunction()
    {
        var chatOptions = new ChatOptions
        {
            Tools =
            [
                AIFunctionFactory.Create(
                    DotnetMethodHelper.CalculateTax,
                    "get_tax_for_customer",
                    "Gets tax for customer for specific period of month")
            ]
        };

        Assert.IsAssignableFrom<AIFunction>(chatOptions.Tools![0]);
    }

    [Fact]
    public void InitialChatHistory_HasSystemMessage()
    {
        List<ChatMessage> chatHistory =
        [
            new(ChatRole.System, """
                                 You are friendly business tax consultant. 
                                 You calculate tax for specific period of months.
                                 """),
            new(ChatRole.User,
                "I am your customer Method. What's is my tax information for past 3 months?")
        ];

        Assert.Equal(ChatRole.System, chatHistory[0].Role);
    }

    [Fact]
    public void InitialChatHistory_HasUserMessage()
    {
        List<ChatMessage> chatHistory =
        [
            new(ChatRole.System, """
                                 You are friendly business tax consultant. 
                                 You calculate tax for specific period of months.
                                 """),
            new(ChatRole.User,
                "I am your customer Method. What's is my tax information for past 3 months?")
        ];

        Assert.Equal(ChatRole.User, chatHistory[1].Role);
        Assert.Contains("Method", chatHistory[1].Text);
    }

    [Fact]
    public void InitialChatHistory_HasTwoMessages()
    {
        List<ChatMessage> chatHistory =
        [
            new(ChatRole.System, """
                                 You are friendly business tax consultant. 
                                 You calculate tax for specific period of months.
                                 """),
            new(ChatRole.User,
                "I am your customer Method. What's is my tax information for past 3 months?")
        ];

        Assert.Equal(2, chatHistory.Count);
    }
}
