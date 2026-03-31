namespace MCP.DotNetMethod.Tests;

public class EnvironmentConfigurationTests
{
    [Fact]
    public void Endpoint_WhenNull_ThrowsArgumentException()
    {
        var original = Environment.GetEnvironmentVariable("Endpoint");
        try
        {
            Environment.SetEnvironmentVariable("Endpoint", null);
            var endpoint = Environment.GetEnvironmentVariable("Endpoint");

            Assert.Throws<ArgumentNullException>(() =>
                ArgumentException.ThrowIfNullOrEmpty(endpoint, "Endpoint environment variable is not set."));
        }
        finally
        {
            Environment.SetEnvironmentVariable("Endpoint", original);
        }
    }

    [Fact]
    public void Endpoint_WhenEmpty_ThrowsArgumentException()
    {
        var original = Environment.GetEnvironmentVariable("Endpoint");
        try
        {
            Environment.SetEnvironmentVariable("Endpoint", string.Empty);
            var endpoint = Environment.GetEnvironmentVariable("Endpoint");

            Assert.Throws<ArgumentException>(() =>
                ArgumentException.ThrowIfNullOrEmpty(endpoint, "Endpoint environment variable is not set."));
        }
        finally
        {
            Environment.SetEnvironmentVariable("Endpoint", original);
        }
    }

    [Fact]
    public void Endpoint_WhenSet_DoesNotThrow()
    {
        var original = Environment.GetEnvironmentVariable("Endpoint");
        try
        {
            Environment.SetEnvironmentVariable("Endpoint", "https://my-resource.openai.azure.com/");
            var endpoint = Environment.GetEnvironmentVariable("Endpoint");

            var exception = Record.Exception(() =>
                ArgumentException.ThrowIfNullOrEmpty(endpoint, "Endpoint environment variable is not set."));

            Assert.Null(exception);
        }
        finally
        {
            Environment.SetEnvironmentVariable("Endpoint", original);
        }
    }

    [Fact]
    public void DeploymentName_WhenNull_ThrowsArgumentException()
    {
        var original = Environment.GetEnvironmentVariable("DeploymentName");
        try
        {
            Environment.SetEnvironmentVariable("DeploymentName", null);
            var deploymentName = Environment.GetEnvironmentVariable("DeploymentName");

            Assert.Throws<ArgumentNullException>(() =>
                ArgumentException.ThrowIfNullOrEmpty(deploymentName, "DeploymentName environment variable is not set."));
        }
        finally
        {
            Environment.SetEnvironmentVariable("DeploymentName", original);
        }
    }

    [Fact]
    public void DeploymentName_WhenEmpty_ThrowsArgumentException()
    {
        var original = Environment.GetEnvironmentVariable("DeploymentName");
        try
        {
            Environment.SetEnvironmentVariable("DeploymentName", string.Empty);
            var deploymentName = Environment.GetEnvironmentVariable("DeploymentName");

            Assert.Throws<ArgumentException>(() =>
                ArgumentException.ThrowIfNullOrEmpty(deploymentName, "DeploymentName environment variable is not set."));
        }
        finally
        {
            Environment.SetEnvironmentVariable("DeploymentName", original);
        }
    }

    [Fact]
    public void DeploymentName_WhenSet_DoesNotThrow()
    {
        var original = Environment.GetEnvironmentVariable("DeploymentName");
        try
        {
            Environment.SetEnvironmentVariable("DeploymentName", "gpt-4o");
            var deploymentName = Environment.GetEnvironmentVariable("DeploymentName");

            var exception = Record.Exception(() =>
                ArgumentException.ThrowIfNullOrEmpty(deploymentName, "DeploymentName environment variable is not set."));

            Assert.Null(exception);
        }
        finally
        {
            Environment.SetEnvironmentVariable("DeploymentName", original);
        }
    }
}
