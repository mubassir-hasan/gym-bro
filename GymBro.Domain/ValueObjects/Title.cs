using GymBro.Abstractions;
using GymBro.Domain.Errors;
using GymBro.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.ValueObjects
{
    public sealed class Title : ValueObject
    {
        public Title(string value)
        {
            Value = value;
        }

        public const int MaxLength = 80;
        public string Value { get; }

        public static Result<Title> Create(string title)
        {
            var result = Result.Create(title)
                .Ensure(x => !string.IsNullOrWhiteSpace(x), DomainErrors.Title.Empty)
                .Ensure(x=>x.Length<=MaxLength, DomainErrors.Title.TooLong)
                .Map(e=>new Title(e));

            return result;
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
