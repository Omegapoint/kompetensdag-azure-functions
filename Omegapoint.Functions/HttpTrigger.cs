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
using System.Text;
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
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "names")] HttpRequest req,
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
                var message = JsonConvert.SerializeObject(dto);
                await personQueue.AddAsync(message);
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                return new ObjectResult(responseMessage) { StatusCode = 500 };
            }
            return new OkObjectResult(responseMessage);
        }

#nullable enable
        private static bool ParseBase64(string? text, Encoding encoding, out string? decodedText)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                decodedText = null;
                return false;
            }
            try
            {
                byte[] textAsBytes = Convert.FromBase64String(text);
                decodedText = encoding.GetString(textAsBytes);
                return true;
            }
            catch (Exception)
            {
                decodedText = null;
                return false;
            }
        }
    }
}

