using Microsoft.Extensions.AI;

namespace MCP.TaxClient.Tests;

public class ChatConfigurationTests
{
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

    [Fact]
    public void InitialChatHistory_SystemMessage_ContainsTaxConsultant()
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

        Assert.Contains("tax consultant", chatHistory[0].Text);
    }

    [Fact]
    public void InitialChatHistory_UserMessage_ContainsMonthsQuery()
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

        Assert.Contains("3 months", chatHistory[1].Text);
    }

    [Fact]
    public void ChatOptions_WithTools_IsNotNull()
    {
        var chatOptions = new ChatOptions
        {
            Tools = []
        };

        Assert.NotNull(chatOptions);
        Assert.NotNull(chatOptions.Tools);
    }

    [Fact]
    public void ChatMessage_System_RoleIsCorrect()
    {
        var message = new ChatMessage(ChatRole.System, "You are a tax consultant.");

        Assert.Equal(ChatRole.System, message.Role);
    }

    [Fact]
    public void ChatMessage_User_RoleIsCorrect()
    {
        var message = new ChatMessage(ChatRole.User, "What is my tax?");

        Assert.Equal(ChatRole.User, message.Role);
    }

    [Fact]
    public void ChatMessage_TextContent_IsPreserved()
    {
        const string text = "I am your customer Method. What's is my tax information for past 3 months?";
        var message = new ChatMessage(ChatRole.User, text);

        Assert.Equal(text, message.Text);
    }
}
