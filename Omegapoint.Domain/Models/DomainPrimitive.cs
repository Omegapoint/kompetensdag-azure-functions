using System;

namespace Omegapoint.Domain.Models
{
    public abstract class  DomainPrimitive: IEquatable<DomainPrimitive> {
        
        protected DomainPrimitive() {}
        public bool Equals(DomainPrimitive other)
        {
            return other != null && Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is DomainPrimitive domainPrimitive))
                return false;
            return Equals(domainPrimitive);
        }

        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;

        public override string ToString() => Value.ToString();

        public string Value {get; protected set; }
    }
}
