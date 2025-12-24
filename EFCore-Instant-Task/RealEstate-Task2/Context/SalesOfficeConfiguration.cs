using EFCore_Instant_Task.RealEstate_Task7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class SalesOfficeConfiguration : IEntityTypeConfiguration<SalesOffice>
    {
        public void Configure(EntityTypeBuilder<SalesOffice> builder)
        {
            builder.HasKey(s => s.Number);

            builder.Property(s => s.Location)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(s => s.Manager)
                   .WithOne(e => e.ManagedOffice)
                   .HasForeignKey<SalesOffice>(s => s.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}