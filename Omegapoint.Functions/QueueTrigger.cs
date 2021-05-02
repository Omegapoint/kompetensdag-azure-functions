using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Omegapoint.Functions
{
    public class QueueTrigger
    {
        private const string FunctionName = nameof(QueueTrigger);
        public QueueTrigger()
        {

        }

        [FunctionName(FunctionName)]
        public async Task RunAsync([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            await Task.Delay(1);
        }
    }
}
