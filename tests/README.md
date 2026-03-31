# 🧪 Tests

This folder contains all automated tests for the MCP (Model Context Protocol) demo examples.

## Structure

| Subfolder | Description |
|-----------|-------------|
| `unit/` | Unit tests for individual MCP components |
| `integration/` | Integration tests for end-to-end MCP flows |

## Running Tests

Each test project includes its own `README.md` with instructions. In general:

```bash
# Example: run all tests in a .NET project
dotnet test

# Example: run all tests in a Python project
pytest
```

## Test Strategy

- **Unit tests** validate individual MCP server/client logic in isolation.
- **Integration tests** exercise complete request/response flows between an MCP host, client, and server.

> **Note:** Integration tests may require Azure credentials or local service emulators. See [docs/getting-started.md](../docs/getting-started.md) for environment setup.

## Contributing

See the root [README](../README.md#contributing) for contribution guidelines.
