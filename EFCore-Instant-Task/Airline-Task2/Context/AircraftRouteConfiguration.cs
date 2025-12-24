using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class AircraftRouteConfiguration : IEntityTypeConfiguration<AircraftRoute>
    {
        public void Configure(EntityTypeBuilder<AircraftRoute> builder)
        {
            builder.HasKey(ar => new { ar.AircraftId, ar.RouteId });
            
            builder.Property(ar => ar.NumOfPassengers)
                   .IsRequired();
            
            builder.Property(ar => ar.Price)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");
            
            builder.Property(ar => ar.Arrival)
                   .IsRequired();
            
            builder.Property(ar => ar.Departure)
                   .IsRequired();
            
            builder.Property(ar => ar.Duration)
                   .IsRequired();
            
            builder.ToTable(t => t.HasCheckConstraint("CK_AircraftRoute_NumOfPassengers", "[NumOfPassengers] >= 0"));
            builder.ToTable(t => t.HasCheckConstraint("CK_AircraftRoute_Price", "[Price] > 0"));
            builder.ToTable(t => t.HasCheckConstraint("CK_AircraftRoute_Duration", "[Duration] > 0"));
            
            builder.HasOne(ar => ar.Aircraft)
                   .WithMany(a => a.AircraftRoutes)
                   .HasForeignKey(ar => ar.AircraftId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(ar => ar.Route)
                   .WithMany(r => r.AircraftRoutes)
                   .HasForeignKey(ar => ar.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
