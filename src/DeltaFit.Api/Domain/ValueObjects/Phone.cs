using DeltaFit.Api.Domain.Errors;
using DeltaFit.Api.Domain.Primitives;
using DeltaFit.Api.Domain.Shared;

namespace DeltaFit.Api.Domain.ValueObjects
{
    public sealed class Phone : ValueObject
    {
        public const int MaxLength = 14;
        private Phone(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Phone> Create(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result.Failure<Phone>(DomainErrors.Phone.Empty);
            }

            if (phone.Split('@').Length != 2)
            {
                return Result.Failure<Phone>(DomainErrors.Phone.InvalidFormat);
            }

            return new Phone(phone);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
