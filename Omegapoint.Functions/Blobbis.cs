using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Omegapoint.Functions
{
    public static class Blobbis
    {
        [FunctionName("Blobbis")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($" Hej, jag älskar Azure Functions.\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
