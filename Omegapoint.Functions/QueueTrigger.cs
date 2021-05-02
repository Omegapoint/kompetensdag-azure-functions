using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Omegapoint.Domain.Dtos;
using Omegapoint.Domain.Extensions;
using Omegapoint.Domain.Models;
using System;
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
        public async Task RunAsync([QueueTrigger("personqueue", Connection = StorageConnection.AzuriteQueue)] string queueMessage, ILogger log,
        [Table("PersonTable", Connection = StorageConnection.AzuriteTable)] IAsyncCollector<PersonTable> personTable)
        {
            log.LogInformation($"C# Queue trigger function processed: {queueMessage}");

            PersonDto dto = JsonConvert.DeserializeObject<PersonDto>(queueMessage);
            Person person = dto.CreateInstance();
            PersonTable personTableItem = new PersonTable
            {
                PartitionKey = person.Name.Value,
                RowKey = Guid.NewGuid().ToString(),
                ProgrammingLanguage = person.ProgrammingLanguage.Value
            };
            await personTable.AddAsync(personTableItem);
        }
    }
}
