using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.MajorPilot)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(c => c.AssistantPilot)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(c => c.Host1)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(c => c.Host2)
                   .HasMaxLength(100);
            
            builder.HasOne(c => c.Aircraft)
                   .WithOne(a => a.Crew)
                   .HasForeignKey<Crew>(c => c.AircraftId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasIndex(c => c.AircraftId)
                   .IsUnique();
        }
    }
}
