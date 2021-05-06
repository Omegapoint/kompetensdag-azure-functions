using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Text;
using Newtonsoft.Json;

namespace Omegapoint.Functions
{
    public class QueueTriggerToBlob
    {
        private const string FunctionName = nameof(QueueTriggerToBlob);
        private readonly BlobServiceClient _blobServiceClient;
        public QueueTriggerToBlob(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        [FunctionName(FunctionName)]
        public async Task RunAsync([QueueTrigger("personQueue", Connection = "AzureWebJobsStorage")] string personInfo, ILogger log,
        [Blob("personQueue/{queueTrigger}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream blob)
        {
            log.LogInformation($"C# Queue trigger function processed: {personInfo}");
            var jsonToUpload = JsonConvert.SerializeObject(personInfo);
            await using var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonToUpload));
            await UploadFileAsync("__blobstorage__", "my-blob", ms);
        }

        public async Task UploadFileAsync(string containerName, string blobName, Stream blobStream)
        {
            var containerClient =_blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blob = containerClient.GetBlobClient(blobName);
            Response<BlobContentInfo> response = await blob.UploadAsync(blobStream, overwrite: true);
        }
    }
}
