
using DentalHealthCenter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalHealthCenter.Persistence
{
    public class DentalHealthCenterDbContext : DbContext
    {
        public DentalHealthCenterDbContext(DbContextOptions<DentalHealthCenterDbContext> options) 
        : base(options)
        {
        }

        public DbSet<DentalOffice> DentalOffices { get; set; }
    }
}
