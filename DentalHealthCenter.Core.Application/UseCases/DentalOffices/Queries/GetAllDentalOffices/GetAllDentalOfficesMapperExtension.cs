

using DentalHealthCenter.Core.Domain.Entities;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetAllDentalOffices
{
    public static class GetAllDentalOfficesMapperExtension
    {
        public static DentalOfficeDTO ToDto(this DentalOffice office)
        {
            return new DentalOfficeDTO { 
                Id = office.Id, 
                Name = office.Name 
            };
        }
    }
}
