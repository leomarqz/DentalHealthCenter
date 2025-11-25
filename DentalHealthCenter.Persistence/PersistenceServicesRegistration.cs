
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DentalHealthCenter.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<DentalHealthCenterDbContext>(options =>
                options.UseSqlServer("name=DentalHealthCenterConnectionString"));

            return services;
        }
    }
}
