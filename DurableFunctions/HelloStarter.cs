using Microsoft.DurableTask;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DurableFunctions
{
    public static class HelloStarter
    {
        [Function(nameof(StartHelloCities))]
        public static async Task<HttpResponseData> StartHelloCities(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        [DurableClient] DurableClientContext durableContext,
        FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger(nameof(StartHelloCities));

            string instanceId = await durableContext.Client.ScheduleNewHelloOrchestrationInstanceAsync();
            logger.LogInformation("Created new orchestration with instance ID = {instanceId}", instanceId);

            return durableContext.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
