using System;
namespace Omegapoint.Domain.Models
{
    public class Person
    {
        private Person() { }
        public Person(Name name, ProgrammingLanguage programmingLanguage)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ProgrammingLanguage = programmingLanguage ?? throw new ArgumentNullException(nameof(programmingLanguage));
        }

        public Name Name { get; }
        public ProgrammingLanguage ProgrammingLanguage { get; }
    }

    public class PersonBuilder
    {
        private Name _name;
        private ProgrammingLanguage _programmingLanguage;
        private Person _personInstance;
        private PersonBuilder() { }
        public static PersonBuilder Create()
        {
            return new PersonBuilder();
        }
        public PersonBuilder WithName(Name name)
        {
            _name = name;
            return this;
        }
        public PersonBuilder WithProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _programmingLanguage = programmingLanguage;
            return this;
        }

        public PersonBuilder Example()
        {
            var name = new Name("Jörgen");
            var programmingLanguage = new ProgrammingLanguage("C#");
            return Create()
            .WithName(name)
            .WithProgrammingLanguage(programmingLanguage);
        }

        public Person Build()
        {
            return _personInstance ??= new Person(_name, _programmingLanguage);
        }
    }
}