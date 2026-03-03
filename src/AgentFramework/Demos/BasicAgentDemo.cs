namespace Demos;

using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using OpenAI.Chat;

/// <summary>
/// A basic demonstration of creating and using an AI agent.
/// Pre-Requisites: 
/// Azure Foundry Resource with gpt-5-nano deployment.
/// A VM with Managed Identity enabled.
/// "Congnitive Services OpenAI User" role assigned to the VM's Managed Identity at the resource scope.
/// </summary>
public class BasicAgentDemo : IDemo
{
    public async Task Run()
    {
        AIAgent agent = new AzureOpenAIClient(
                new Uri("https://ai-transition-lab-csharp.openai.azure.com/"),
                new DefaultAzureCredential())
                    .GetChatClient("gpt-5-nano")
                    .AsAIAgent(instructions: "You are a helpful assistant that provides concise and accurate answers to user questions.");

        Console.WriteLine(await agent.RunAsync("What is the weather like in San Franciso"));
    }
}