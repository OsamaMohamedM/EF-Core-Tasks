using EFCore_Instant_Task.RealEstate_Task7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.OwnsOne(p => p.Location, location =>
            {
                location.Property(l => l.Address)
                        .IsRequired()
                        .HasMaxLength(200);
                
                location.Property(l => l.City)
                        .IsRequired()
                        .HasMaxLength(100);
                
                location.Property(l => l.State)
                        .IsRequired()
                        .HasMaxLength(50);
                
                location.Property(l => l.Code)
                        .IsRequired()
                        .HasMaxLength(20);
            });
            
            builder.HasOne(p => p.SalesOffice)
                   .WithMany(s => s.Properties)
                   .HasForeignKey(p => p.SalesOfficeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
