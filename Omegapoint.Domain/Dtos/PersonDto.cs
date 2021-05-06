using Newtonsoft.Json;
namespace Omegapoint.Domain.Dtos
{
    public class PersonDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "programmingLanguage")]
        public string ProgrammingLanguage { get; set; }
    }
}