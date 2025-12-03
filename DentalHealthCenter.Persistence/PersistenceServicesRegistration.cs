
using DentalHealthCenter.Core.Application.Contracts.Persistence;
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Persistence.Repositories;
using DentalHealthCenter.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DentalHealthCenter.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            // CONNECTION STRING
            //----------------------
            services.AddDbContext<DentalHealthCenterDbContext>(options =>
                options.UseSqlServer("name=DentalHealthCenterConnectionString"));

            //REPOSITORIES
            //----------------------
            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();

            // UNIT OF WORK
            //----------------------
            services.AddScoped<IUnitOfWork, UnitOfWorkByEFCore>();

            return services;
        }
    }
}
