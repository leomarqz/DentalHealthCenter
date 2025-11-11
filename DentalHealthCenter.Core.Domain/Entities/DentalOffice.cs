
using DentalHealthCenter.Core.Domain.Exceptions;
using System;

namespace DentalHealthCenter.Core.Domain.Entities
{
    // Consultorio Dental
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public DentalOffice(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} cannot be empty.");
            }

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
