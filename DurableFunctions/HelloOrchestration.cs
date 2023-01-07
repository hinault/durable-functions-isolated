using Microsoft.DurableTask;

namespace DurableFunctions
{
    [DurableTask(nameof(HelloOrchestration))]
    public class HelloOrchestration : TaskOrchestrator<string?, string>
   {
    public async override Task<string> RunAsync(TaskOrchestrationContext context, string? input)
    {
        string result = "";
            result += await context.CallSayHelloAsync("Tokyo") + " ";
            result += await context.CallSayHelloAsync("London") + " ";
            result += await context.CallSayHelloAsync("Seattle");
            return result;
    }
  }
}
