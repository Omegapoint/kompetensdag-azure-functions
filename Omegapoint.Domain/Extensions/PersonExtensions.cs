using Omegapoint.Domain.Models;
using Omegapoint.Domain.Dtos;

namespace Omegapoint.Domain.Extensions
{
    public static class PersonExtensions
    {
        public static PersonDto CreateDto(this Person person)
        {
            return new PersonDto
            {
                Name = person.Name.Value,
                ProgrammingLanguage = person.ProgrammingLanguage.Value
            };
        }

        public static Person CreateInstance(this PersonDto dto)
        {
            var name = new Name(dto.Name);
            var programmingLanguage = new ProgrammingLanguage(dto.ProgrammingLanguage);
            
            return PersonBuilder.Create()
            .WithName(name)
            .WithProgrammingLanguage(programmingLanguage)
            .Build();
        }
    }
}