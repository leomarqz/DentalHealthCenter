
using DentalHealthCenter.Core.Domain.Entities;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetDentalOffice
{
    public static class MapperExtension
    {
        public static DentalOfficeDTO ToDTO(this DentalOffice office)
        {
            return new DentalOfficeDTO
            {
                Id = office.Id,
                Name = office.Name
            };
        }
    }
}
