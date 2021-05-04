using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Omegapoint.Domain.Dtos;
using Omegapoint.Domain.Extensions;
using Omegapoint.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

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

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                PersonDto dto = JsonConvert.DeserializeObject<PersonDto>(requestBody);
                Person person = dto.CreateInstance();

                responseMessage = $"Hello, {person.Name.Value}. So {person.ProgrammingLanguage.Value} is the language of your chosing huh?";

                // await personQueue.AddAsync(JsonConvert.SerializeObject(dto));
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

