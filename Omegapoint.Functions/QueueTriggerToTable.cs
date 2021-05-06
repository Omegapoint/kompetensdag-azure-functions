// using Microsoft.Azure.WebJobs;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
// using Omegapoint.Domain.Dtos;
// using Omegapoint.Domain.Extensions;
// using Omegapoint.Domain.Models;
// using System;
// using System.Threading.Tasks;

// namespace Omegapoint.Functions
// {
//     public class QueueTriggerToTable
//     {
//         private const string FunctionName = nameof(QueueTriggerToTable);
//         public QueueTriggerToTable()
//         {

//         }

//         [FunctionName(FunctionName)]
//         public async Task RunAsync([QueueTrigger("personqueue", Connection = "AzureWebJobsStorage")] string queueMessage, ILogger log
//         // [Table("PersonTable", Connection = "AzureWebJobsStorage")] IAsyncCollector<PersonTable> personTable
//         )
//         {
//             log.LogInformation($"C# Queue trigger function processed: {queueMessage}");
//             await Task.Delay(1);
//             PersonDto dto = JsonConvert.DeserializeObject<PersonDto>(queueMessage);
//             Person person = dto.CreateInstance();
//             PersonTable personTableItem = new PersonTable
//             {
//                 PartitionKey = person.Name.Value,
//                 RowKey = Guid.NewGuid().ToString(),
//                 ProgrammingLanguage = person.ProgrammingLanguage.Value
//             };
//             await personTable.AddAsync(personTableItem);
//         }
//     }
// }
