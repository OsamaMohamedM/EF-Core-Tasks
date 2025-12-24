using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Number)
                   .IsRequired()
                   .HasMaxLength(20);
            
            builder.HasOne(p => p.Airline)
                   .WithMany(a => a.Phones)
                   .HasForeignKey(p => p.AirlineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
