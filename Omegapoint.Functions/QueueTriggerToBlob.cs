using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Omegapoint.Functions
{
    public class QueueTriggerToBlob
    {
        private const string FunctionName = nameof(QueueTriggerToBlob);
        private readonly BlobServiceClient _blobServiceClient;
        public QueueTriggerToBlob()
        {
            _blobServiceClient = new BlobServiceClient(@"DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;");
        }

        [FunctionName(FunctionName)]
        public async Task RunAsync([QueueTrigger("personqueue", Connection = "AzureWebJobsStorage")] JObject personInfo, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {personInfo}");

            var jsonToUpload = JsonConvert.SerializeObject(personInfo);
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonToUpload));
            ms.Position = 0;
            await UploadFileAsync("my-container", "my-blob", ms);
        }

        public async Task UploadFileAsync(string containerName, string blobName, Stream blobStream)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();
            BlobClient blob = containerClient.GetBlobClient(blobName);
            await blob.UploadAsync(blobStream, overwrite: true);
        }
    }
}