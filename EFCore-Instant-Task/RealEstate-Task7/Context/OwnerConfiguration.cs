using EFCore_Instant_Task.RealEstate_Task7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.Id);
            
            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
