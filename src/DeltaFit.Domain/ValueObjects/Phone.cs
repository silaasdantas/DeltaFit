using DeltaFit.Domain.Errors;
using DeltaFit.Domain.Primitives;
using DeltaFit.Domain.Shared;

namespace DeltaFit.Domain.ValueObjects
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

            return new Phone(phone);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
