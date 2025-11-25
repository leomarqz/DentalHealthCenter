
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalHealthCenterDbContext).Assembly);
        }

        public DbSet<DentalOffice> DentalOffices { get; set; }
    }
}
