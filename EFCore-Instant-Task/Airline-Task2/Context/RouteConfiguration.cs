using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(r => r.Id);
            
            builder.Property(r => r.Classification)
                   .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(r => r.Distance)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");
            
            builder.Property(r => r.Destination)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(r => r.Origin)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.ToTable(t => t.HasCheckConstraint("CK_Route_Distance", "[Distance] > 0"));
        }
    }
}
