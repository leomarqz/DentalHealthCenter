

using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetAllDentalOffices
{
    public class UseCaseGetListDentalOffices 
        : IRequestHandler<GetListDentalOfficesQuery, List<DentalOfficeDTO> >
    {
        private readonly IDentalOfficeRepository repository;

        public UseCaseGetListDentalOffices(IDentalOfficeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<DentalOfficeDTO>> Handle(GetListDentalOfficesQuery request)
        {
            var offices = await this.repository.ToListAsync();
            var dtos = offices.Select(x => x.ToDto()).ToList();

            return dtos;
        }
    }
}
