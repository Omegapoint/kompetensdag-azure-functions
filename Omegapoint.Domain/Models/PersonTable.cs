using System;
using Microsoft.Azure.Cosmos.Table;
using System.Text;

namespace Omegapoint.Domain.Models
{
    public sealed class PersonTable : TableEntity, IEquatable<PersonTable>
    {
        /// <summary>
        /// Programming language of choice
        /// </summary>
        public string ProgrammingLanguage { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is PersonTable request))
            {
                return false;
            }

            return Equals(request);
        }

        /// <summary>
        /// Checks of equality for all fields in cases such as:
        /// 1) Parameter is null return false
        /// 2) Equal reference should return true, optimization for a common success case.
        /// 3) Fields match, return true.
        /// </summary>
        /// <param name="other"><see cref="PersonTable"/></param>
        /// <returns>True if passed equality check</returns>
        public bool Equals(PersonTable other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PartitionKey.Equals(other.PartitionKey) &&
                   RowKey.Equals(other.RowKey) &&
                   ProgrammingLanguage.Equals(other.ProgrammingLanguage);
        }

        /// <summary>
        /// Getting hash codes is wrapped with unchecked
        /// to avoid any arithmetic exception
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + PartitionKey.GetHashCode();
                hash = hash * 23 + RowKey.GetHashCode();
                hash = hash * 23 + ProgrammingLanguage.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder
            .Append($"{nameof(PartitionKey)}: {PartitionKey}, ")
            .Append($"{nameof(RowKey)}: {RowKey}, ")
            .Append($"{nameof(ProgrammingLanguage)}: {ProgrammingLanguage}")
            .ToString();
        }
    }
}