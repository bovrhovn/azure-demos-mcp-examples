# 🧪 Tests

This folder contains all automated tests for the MCP (Model Context Protocol) demo examples.

## Structure

| Subfolder | Description |
|-----------|-------------|
| `MCP.DotNetMethod.Tests/` | Unit and configuration tests for the [MCP.DotNetMethod](../src/ADMcpExamples/MCP.DotNetMethod/) example |

## Running Tests

Each test project includes its own `README.md` with instructions. In general:

```bash
# Example: run all tests in a .NET project
dotnet test

# Example: run all tests in a Python project
pytest
```

## Test Strategy

- **Unit tests** validate individual MCP server/client logic in isolation (e.g. `DotnetMethodHelperTests` — tax calculation logic).
- **Configuration tests** verify that `AIFunctionFactory.Create` registers tools with the correct name, description, and invocation behaviour (`ChatConfigurationTests`).
- **Environment tests** confirm that missing or empty environment variables surface as `ArgumentException`/`ArgumentNullException` at startup (`EnvironmentConfigurationTests`).

> **Note:** Integration tests that call Azure OpenAI require a valid `Endpoint` and `DeploymentName` environment variable plus an authenticated `DefaultAzureCredential`. See [docs/dotnet-method.md](../docs/dotnet-method.md) for setup instructions.

## Contributing

See the root [README](../README.md#contributing) for contribution guidelines.
