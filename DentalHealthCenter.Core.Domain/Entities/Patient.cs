

using DentalHealthCenter.Core.Domain.ValueObjects;
using System;

namespace DentalHealthCenter.Core.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Patient(string name, Email email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
