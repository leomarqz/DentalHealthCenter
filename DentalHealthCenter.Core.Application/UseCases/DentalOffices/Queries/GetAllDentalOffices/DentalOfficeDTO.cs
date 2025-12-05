
using System;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetAllDentalOffices
{
    public class DentalOfficeDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
