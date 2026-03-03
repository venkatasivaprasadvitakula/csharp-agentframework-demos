// See https://aka.ms/new-console-template for more information
using Demos;

// IDemo demo = new BasicAgentDemo();
// IDemo demo = new AgentWithSingleFunctionToolDemo();
IDemo demo = new AgentWithMultipleFunctionToolsDemo();
await demo.Run();


