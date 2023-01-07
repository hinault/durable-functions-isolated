using Microsoft.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctions
{
    [DurableTask(nameof(SayHello))]
    public class SayHello : TaskActivity<string, string>
    {
        readonly ILogger logger;

        public SayHello(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SayHello>();
        }

        public override Task<string> RunAsync(TaskActivityContext context, string cityName)
        {
            logger.LogInformation("Saying hello to {name}", cityName);
            return Task.FromResult($"Hello, {cityName}!");
        }
    }
}
