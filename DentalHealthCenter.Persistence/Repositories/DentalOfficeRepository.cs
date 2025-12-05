


using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Domain.Entities;

namespace DentalHealthCenter.Persistence.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(DentalHealthCenterDbContext context)
            :base(context)
        {
            
        }
    }
}
