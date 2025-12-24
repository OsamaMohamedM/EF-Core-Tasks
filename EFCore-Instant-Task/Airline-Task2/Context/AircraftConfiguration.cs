using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Model)
                   .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(a => a.Capacity)
                   .IsRequired();
            
            builder.ToTable(t => t.HasCheckConstraint("CK_Aircraft_Capacity", "[Capacity] > 0"));
            
            builder.HasOne(a => a.Airline)
                   .WithMany(al => al.Aircrafts)
                   .HasForeignKey(a => a.AirlineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
