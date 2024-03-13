﻿using DeltaFit.Api.Domain.Errors;
using DeltaFit.Api.Domain.Primitives;
using DeltaFit.Api.Domain.Shared;

namespace DeltaFit.Api.Domain.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public const int MaxLength = 14;
        private Password(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return Result.Failure<Password>(DomainErrors.Password.Empty);
            }

            //TODO: colocar regras para uma nova senha

            return new Password(password);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
