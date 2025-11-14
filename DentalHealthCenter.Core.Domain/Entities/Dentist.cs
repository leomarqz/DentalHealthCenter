

using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;
using System;

namespace DentalHealthCenter.Core.Domain.Entities
{
    public class Dentist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Dentist(string name, Email email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} cannot be empty.");
            }

            if(email is null)
            {
                throw new BusinessRuleException($"The {nameof(Email)} cannot be null.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
