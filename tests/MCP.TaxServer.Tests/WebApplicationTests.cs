using Microsoft.AspNetCore.Mvc.Testing;

namespace MCP.TaxServer.Tests;

public class WebApplicationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WebApplicationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HealthCheck_ReturnsOk()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/health");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task HealthCheck_ReturnsHealthyContent()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/health");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal("Healthy", content);
    }

    [Fact]
    public async Task McpEndpoint_IsRegistered()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/mcp");

        Assert.NotNull(response);
    }

    [Fact]
    public async Task HealthCheck_ContentType_IsJson()
    {
        var client = _factory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "/health");
        request.Headers.Accept.ParseAdd("application/json");

        var response = await client.SendAsync(request);

        Assert.NotNull(response.Content.Headers.ContentType);
    }
}
