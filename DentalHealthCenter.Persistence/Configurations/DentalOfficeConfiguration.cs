
using DentalHealthCenter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalHealthCenter.Persistence.Configurations
{
    public class DentalOfficeConfiguration : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(EntityTypeBuilder<DentalOffice> builder)
        {
            builder.Property((prop)=> prop.Name)
                .HasMaxLength(150)
                .IsRequired();

        }
    }
}
