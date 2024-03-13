using DeltaFit.Api.Domain.Errors;
using DeltaFit.Api.Domain.Primitives;
using DeltaFit.Api.Domain.Shared;

namespace DeltaFit.Api.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public const int MaxLength = 50;
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result.Failure<Email>(DomainErrors.Email.Empty);
            }

            if (email.Split('@').Length != 2)
            {
                return Result.Failure<Email>(DomainErrors.Email.InvalidFormat);
            }

            return new Email(email);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
