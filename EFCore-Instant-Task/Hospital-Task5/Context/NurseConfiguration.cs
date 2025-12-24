using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class NurseConfiguration : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.Property(n => n.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasKey(b => b.Number);
            builder.Property(n => n.Address)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(n => n.Ward)
                   .WithMany(w => w.Nurses)
                   .HasForeignKey(n => n.WardId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}