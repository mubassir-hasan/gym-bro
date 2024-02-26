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
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<Title>(DomainErrors.Title.Empty);
            if (title.Length > MaxLength)
                return Result.Failure<Title>(DomainErrors.Title.TooLong);

            return new Title(title);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
