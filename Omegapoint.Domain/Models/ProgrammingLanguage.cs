using System;
namespace Omegapoint.Domain.Models
{
    public class ProgrammingLanguage : DomainPrimitive
    {
        public ProgrammingLanguage(string value)
        {
            // add rules
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}