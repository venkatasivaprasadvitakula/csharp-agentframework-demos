# C# Agent Framework Demos

## What is an Agent?

An **AI agent** uses an **LLM** to run **tools** in a loop to achieve a **goal**.

### Agent Loop

The core agent pattern follows this flow:

1. **Input** - A user provides a prompt or task
2. **LLM** - The language model reasons about the input and decides what to do
3. **Tools** - The LLM calls tools to take actions or gather information
4. **Loop** - The LLM and tools iterate in a cycle until the goal is met
5. **Goal** - The final result is delivered to the user

### Agents are often augmented by

- **Context** - Relevant information provided to the agent
- **Memory** - Ability to recall prior interactions
- **Planning** - Breaking down complex tasks into steps
- **Humans** - Human-in-the-loop for oversight and decisions

> Reference: [https://simonwillison.net/2025/Sep/18/agents/](https://simonwillison.net/2025/Sep/18/agents/)

## Getting Started

### Prerequisites

- .NET 10
- Azure Foundry Resource with a `gpt-5-nano` deployment
- A VM with Managed Identity enabled
- **Cognitive Services OpenAI User** role assigned to the VM's Managed Identity at the resource scope

### NuGet Packages

```bash
dotnet add package Azure.AI.OpenAI --prerelease
dotnet add package Azure.Identity
dotnet add package Microsoft.Agents.AI.OpenAI --prerelease
```