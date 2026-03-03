namespace Demos;

using System.ComponentModel;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI.Chat;

/// <summary>
/// A basic demonstration of creating and using an AI agent.
/// Pre-Requisites: 
/// Azure Foundry Resource with gpt-5-nano deployment.
/// A VM with Managed Identity enabled.
/// "Congnitive Services OpenAI User" role assigned to the VM's Managed Identity at the resource scope.
/// </summary>
public class AgentWithMultipleFunctionToolsDemo : IDemo
{   
    [Description("Represents the current weather conditions for a given location.")]
    public class WeatherData
    {
        [Description("The current temperature in degrees Fahrenheit.")]
        public int Temperature { get; set; }

        [Description("The weather forecast for the location.")]
        public string Forecast { get; set; } = default!;
    }


    [Description("Gets the current weather for a specified location.")]
    public static WeatherData GetWeather([Description("The location for which to get weather information.")] string location)
    {
        return new WeatherData
        {
            Temperature = 75,
            Forecast = "sunny"
        };
    } 

    [Description("Gets a list of recommended activities for a given location and date.")]
    public static List<string> GetsActivities(
        [Description("The location for which to get activity recommendations.")] string location,
        [Description("The date for which to get activity recommendations.")] DateOnly date)
    {
        return new List<string>
        {
            "Hiking",
            "Beach",
            "Museum"
        };
    }

    [Description("Gets the current date.")]
    public static DateOnly GetCurrentDate()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
    
    public async Task Run()
    {
        AIAgent agent = new AzureOpenAIClient(
                new Uri("https://ai-transition-lab-csharp.openai.azure.com/"),
                new DefaultAzureCredential())
                    .GetChatClient("gpt-5-nano")
                    .AsAIAgent(
                        instructions: "You help user plan their weekends and choose the best activities for the given weather. If an activity would be unpleasant in weather do not suggest it. Include data of the weekend in response.",
                        tools: [AIFunctionFactory.Create(GetWeather), AIFunctionFactory.Create(GetsActivities), AIFunctionFactory.Create(GetCurrentDate)]);

        Console.WriteLine(await agent.RunAsync("What can i do this weekend in San Francisco ?"));
    }
}