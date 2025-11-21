
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetDentalOffice
{
    // Obtener detalles de consultorio dental (caso de uso)
    public class UseCaseGetDentalOffice : IRequestHandler<GetDentalOfficeQuery, DentalOfficeDTO>
    {
        private readonly IDentalOfficeRepository reposotiry;

        public UseCaseGetDentalOffice(IDentalOfficeRepository reposotiry)
        {
            this.reposotiry = reposotiry;
        }

        public async Task<DentalOfficeDTO> Handle(GetDentalOfficeQuery request)
        {
            var office = await this.reposotiry.GetById(request.Id);

            if(office is null)
            {
                throw new NotFoundException();
            }

            var dto = new DentalOfficeDTO
            {
                Id = office.Id,
                Name = office.Name
            };

            return dto;
        }
    }
}
