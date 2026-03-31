<div align="center">

# 🤖 Azure MCP Examples

**Real-world Model Context Protocol (MCP) demos for agentic AI development on Azure**

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![MCP Spec](https://img.shields.io/badge/MCP-2025--03--26-green)](https://modelcontextprotocol.io/specification/2025-03-26)
[![Azure](https://img.shields.io/badge/Azure-AI%20Foundry-0078D4?logo=microsoftazure)](https://azure.microsoft.com/en-us/products/ai-foundry)

</div>

---

## 📋 Overview

This repository contains hands-on demos and examples that show how to build **agentic AI applications** using the [Model Context Protocol (MCP)](https://modelcontextprotocol.io/) on Azure. MCP is an open standard that lets AI models securely connect to external data sources, tools, and services through a unified interface.

Whether you're building your first MCP server or wiring up a complex multi-agent pipeline, you'll find working examples here to get you started.

---

## 🗂️ Repository Structure

| Folder | Purpose |
|--------|---------|
| [`src/`](./src/README.md) | 📦 Source code — MCP server/client implementations and sample apps |
| [`docs/`](./docs/README.md) | 📚 Documentation — architecture guides, concepts, and how-tos |
| [`tests/`](./tests/README.md) | 🧪 Tests — unit and integration tests for all examples |

---

## 🧩 Examples

### MCP.DotNetMethod — .NET Method as an AI Tool

Demonstrates how to wrap a plain static .NET method as an AI tool using `AIFunctionFactory.Create` and invoke it through an Azure AI Foundry chat-completion model with `DefaultAzureCredential`.

| Resource | Link |
|----------|------|
| Source code | [`src/ADMcpExamples/MCP.DotNetMethod/`](./src/ADMcpExamples/MCP.DotNetMethod/) |
| Documentation | [`docs/dotnet-method.md`](./docs/dotnet-method.md) |
| Tests | [`tests/MCP.DotNetMethod.Tests/`](./tests/MCP.DotNetMethod.Tests/) |

**Required environment variables:**

| Variable | Description |
|----------|-------------|
| `Endpoint` | Azure OpenAI resource URI (e.g. `https://my-resource.openai.azure.com/`) |
| `DeploymentName` | Name of your chat-completion deployment (e.g. `gpt-4o`) |

Authentication uses [`DefaultAzureCredential`](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential) — run `az login` or sign into Visual Studio before running locally.

---

## 🚀 Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/bovrhovn/azure-demos-mcp-examples.git
   cd azure-demos-mcp-examples
   ```

2. **Read the docs** — start with the [documentation folder](./docs/README.md) for architecture overviews and prerequisites.

3. **Browse examples** — explore the [source folder](./src/README.md) to find a demo that matches your scenario.

4. **Run the tests** — use the [tests folder](./tests/README.md) to verify your environment is configured correctly.

---

## 🤝 Contributing

Contributions are welcome! Please:

1. Fork the repository and create a feature branch.
2. Add your example or fix under the appropriate folder (`src/`, `docs/`, or `tests/`).
3. Open a pull request with a clear description of your change.

---

## 📖 Additional Information

### 🏛️ Official MCP Resources

| Resource | Link |
|----------|------|
| MCP on Windows — Microsoft Learn | [learn.microsoft.com](https://learn.microsoft.com/en-us/windows/ai/mcp/overview) |
| Microsoft Learn MCP Server overview | [learn.microsoft.com](https://learn.microsoft.com/en-us/training/support/mcp) |
| Microsoft Learn MCP Server release notes | [learn.microsoft.com](https://learn.microsoft.com/en-us/training/support/mcp-release-notes) |
| Get started with .NET AI and MCP | [learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/ai/get-started-mcp) |
| Official MCP Specification (2025-03-26) | [modelcontextprotocol.io](https://modelcontextprotocol.io/specification/2025-03-26) |

### 🧰 Tools & SDKs

| Resource | Link |
|----------|------|
| Microsoft MCP catalog (GitHub) | [github.com/microsoft/mcp](https://github.com/microsoft/mcp) |
| MCP Python SDK | [github.com/modelcontextprotocol/python-sdk](https://github.com/modelcontextprotocol/python-sdk) |
| MCP TypeScript SDK | [github.com/modelcontextprotocol/typescript-sdk](https://github.com/modelcontextprotocol/typescript-sdk) |
| MCP C# SDK | [github.com/modelcontextprotocol/csharp-sdk](https://github.com/modelcontextprotocol/csharp-sdk) |

### 📰 Articles & Blogs

| Resource | Link |
|----------|------|
| How we built the Microsoft Learn MCP Server | [devblogs.microsoft.com](https://devblogs.microsoft.com/engineering-at-microsoft/how-we-built-the-microsoft-learn-mcp-server/) |
| Kickstart Your AI Development with MCP (Microsoft Tech Community) | [techcommunity.microsoft.com](https://techcommunity.microsoft.com/blog/educatordeveloperblog/kickstart-your-ai-development-with-the-model-context-protocol-mcp-course/4414963) |
| Azure AI Foundry documentation | [learn.microsoft.com](https://learn.microsoft.com/en-us/azure/ai-foundry/) |
| DefaultAzureCredential overview | [learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential) |
| AIFunctionFactory in Microsoft.Extensions.AI | [learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.aifunctionfactory) |

---

<div align="center">
  <sub>Built with ❤️ using <a href="https://modelcontextprotocol.io">Model Context Protocol</a> and <a href="https://azure.microsoft.com">Microsoft Azure</a></sub>
</div>
