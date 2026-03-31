# 🧪 Tests

This folder contains all automated tests for the MCP (Model Context Protocol) demo examples.

## Structure

| Subfolder | Description |
|-----------|-------------|
| `MCP.DotNetMethod.Tests/` | Unit and configuration tests for the [MCP.DotNetMethod](../src/ADMcpExamples/MCP.DotNetMethod/) example |
| `MCP.TaxServer.Tests/` | Unit and integration tests for the [MCP.TaxServer](../src/ADMcpExamples/MCP.TaxServer/) example |
| `MCP.TaxClient.Tests/` | Configuration and transport tests for the [MCP.TaxClient](../src/ADMcpExamples/MCP.TaxClient/) example |

## Running Tests

Run each project from the repository root:

```bash
dotnet test tests/MCP.DotNetMethod.Tests
dotnet test tests/MCP.TaxServer.Tests
dotnet test tests/MCP.TaxClient.Tests
```

No Azure credentials are needed — all tests run without network calls.

## Test Coverage

| Test Project | Test Files | What is covered |
|--------------|------------|-----------------|
| `MCP.DotNetMethod.Tests` | `DotnetMethodHelperTests.cs` | Tax calculation logic (all customer types, edge cases) |
| | `ChatConfigurationTests.cs` | `AIFunctionFactory`, `ChatOptions`, `ChatMessage` setup |
| | `EnvironmentConfigurationTests.cs` | `Endpoint`, `DeploymentName` env var guards |
| `MCP.TaxServer.Tests` | `McpToolsTests.cs` | `McpTools.CalculateTax` logic and MCP attribute decoration |
| | `WebApplicationTests.cs` | Health check endpoint, MCP endpoint registration |
| `MCP.TaxClient.Tests` | `EnvironmentConfigurationTests.cs` | `Endpoint`, `McpEndpoint`, `DeploymentName` env var guards |
| | `ChatConfigurationTests.cs` | Chat message construction for the AI Foundry conversation |
| | `TransportConfigurationTests.cs` | `HttpClientTransportOptions` name and endpoint settings |

## Test Strategy

- **Unit tests** validate individual MCP server/client logic in isolation (e.g. `DotnetMethodHelperTests`, `McpToolsTests` — tax calculation logic).
- **Configuration tests** verify that tools, chat options, and transport options are set up correctly (`ChatConfigurationTests`, `TransportConfigurationTests`).
- **Environment tests** confirm that missing or empty environment variables surface as `ArgumentException`/`ArgumentNullException` at startup (`EnvironmentConfigurationTests`).
- **Integration tests** start the full ASP.NET Core host in memory and verify endpoints respond (`WebApplicationTests`).

## Contributing

See the root [README](../README.md#contributing) for contribution guidelines.
