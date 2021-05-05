using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Azure.Storage.Blobs;

namespace Omegapoint.Functions
{
    public class QueueTriggerToBlob
    {
        private const string FunctionName = nameof(QueueTriggerToBlob);
        public QueueTriggerToBlob()
        {
        }

        [FunctionName(FunctionName)]
        public async Task RunAsync([QueueTrigger("personQueue", Connection = "AzureWebJobsStorage")] string personInfo, ILogger log,
        [Blob("personQueue/{queueTrigger}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream client)
        {
            log.LogInformation($"C# Queue trigger function processed: {personInfo}");
            var jsonToUpload = JsonConvert.SerializeObject(personInfo);
            await using var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonToUpload));
            // await blob.UploadAsync(ms);
        }
    }
}
