using System;
namespace Omegapoint.Domain.Models
{
    public class Name : DomainPrimitive
    {
        public Name(string value)
        {
            // add rules
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}