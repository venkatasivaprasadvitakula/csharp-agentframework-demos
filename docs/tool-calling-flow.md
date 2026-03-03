# Tool Calling Flow

## Overview

The tool calling flow describes how developer code and an LLM model interact to execute function calls and return results to the user.

1. **The code tells LLM what tools they can call**
2. **The LLM responds with suggested tool name and arguments**
3. **The code calls function for that tool**
4. **The code sends prior messages and return value from tool function to LLM**
5. **The LLM responds based off full history**

## Sequence Diagram

```mermaid
sequenceDiagram
    participant Dev as Developer
    participant LLM as Model
    Dev->>LLM: Tool definitions and user message
    Note right of Dev: get_weather location
    LLM-->>Dev: Tool call get_weather paris
    Dev->>Dev: Execute get_weather paris
    Note right of Dev: Returns temperature 14
    Dev->>LLM: Prior messages and tool result
    LLM-->>Dev: It is currently 14C in Paris
```

## Reference

- [OpenAI Function Calling Guide](https://platform.openai.com/docs/guides/function-calling)
