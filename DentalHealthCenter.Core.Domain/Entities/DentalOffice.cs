
using System;

namespace DentalHealthCenter.Core.Domain.Entities
{
    // Consultorio Dental
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
    }
}
