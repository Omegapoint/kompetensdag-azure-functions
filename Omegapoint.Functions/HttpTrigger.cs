using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System;
using Omegapoint.Domain.Dtos;

namespace Omegapoint.Functions
{
    public class HttpTrigger
    {
        private const string FunctionName = nameof(HttpTrigger);

        public HttpTrigger()
        {

        }

        [FunctionName(FunctionName)]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "persons")] HttpRequest req,
            ILogger log,
            [Queue("personqueue", Connection = "AzureWebJobsStorage")]
            IAsyncCollector<string> personQueue)
        {
            string responseMessage = "This HTTP triggered function failed execution";
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string name = req.Query["name"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject<PersonDto>(requestBody);
                name = name ?? data?.name;

                responseMessage = string.IsNullOrEmpty(name)
                    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                    : $"Hello, {name}. This HTTP triggered function executed successfully.";

                await personQueue.AddAsync(JsonConvert.SerializeObject(name));
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                return new ObjectResult(responseMessage) { StatusCode = 500 };
            }
            return new OkObjectResult(responseMessage);
        }
    }
}

