using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(a => a.ContactPerson)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.OwnsOne(a => a.Address, address =>
            {
                address.Property(p => p.Street).HasMaxLength(200);
                address.Property(p => p.City).IsRequired().HasMaxLength(100);
                address.Property(p => p.Country).IsRequired().HasMaxLength(100);
            });
        }
    }
}
