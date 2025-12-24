using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasOne(w => w.Manager)
                   .WithOne()
                   .HasForeignKey<Ward>(w => w.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}