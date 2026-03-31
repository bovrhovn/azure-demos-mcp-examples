using ModelContextProtocol.Client;

namespace MCP.TaxClient.Tests;

public class TransportConfigurationTests
{
    [Fact]
    public void HttpClientTransportOptions_Name_CanBeSet()
    {
        var options = new HttpClientTransportOptions
        {
            Name = "My Tax Server MCP",
            Endpoint = new Uri("http://localhost:5000/mcp")
        };

        Assert.Equal("My Tax Server MCP", options.Name);
    }

    [Fact]
    public void HttpClientTransportOptions_Endpoint_CanBeSet()
    {
        var uri = new Uri("http://localhost:5000/mcp");
        var options = new HttpClientTransportOptions
        {
            Name = "My Tax Server MCP",
            Endpoint = uri
        };

        Assert.Equal(uri, options.Endpoint);
    }

    [Fact]
    public void HttpClientTransportOptions_Endpoint_IsAbsoluteUri()
    {
        var options = new HttpClientTransportOptions
        {
            Name = "My Tax Server MCP",
            Endpoint = new Uri("http://localhost:5000/mcp")
        };

        Assert.True(options.Endpoint!.IsAbsoluteUri);
    }

    [Fact]
    public void HttpClientTransportOptions_Endpoint_ContainsMcpPath()
    {
        var options = new HttpClientTransportOptions
        {
            Name = "My Tax Server MCP",
            Endpoint = new Uri("http://localhost:5000/mcp")
        };

        Assert.Contains("/mcp", options.Endpoint!.AbsolutePath);
    }

    [Fact]
    public void HttpClientTransportOptions_WithProductionEndpoint_IsValid()
    {
        var options = new HttpClientTransportOptions
        {
            Name = "Tax Server",
            Endpoint = new Uri("https://my-taxserver.azurewebsites.net/mcp")
        };

        Assert.Equal("https", options.Endpoint!.Scheme);
        Assert.Equal("my-taxserver.azurewebsites.net", options.Endpoint.Host);
    }
}
