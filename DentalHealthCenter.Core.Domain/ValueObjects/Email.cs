
using DentalHealthCenter.Core.Domain.Exceptions;

namespace DentalHealthCenter.Core.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"The {nameof(Email)} cannot be empty.");
            }

            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"The {nameof(Email)} is not valid.");
            }

            Value = email;
        }
    }
}
