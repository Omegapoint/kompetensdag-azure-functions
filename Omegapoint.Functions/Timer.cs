using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Omegapoint.Functions
{
    public class Timer
    {
        [FunctionName("Timer")]
        public async Task Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            HttpClient httpClient = new HttpClient();
            var baseAddress = @"http://localhost:7071/";
            httpClient.BaseAddress = new Uri(baseAddress);
            var payload = @"{""name"": ""Adam"", ""programmingLanguage"":""C#""}";
            HttpContent content = new StringContent(payload);
            
            await httpClient.PostAsync("api/names", content);
        }
    }
}
