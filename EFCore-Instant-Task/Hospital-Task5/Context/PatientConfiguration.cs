using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.DOB)
                   .IsRequired();

            builder.HasOne(p => p.Ward)
                     .WithMany(w => w.Patients)
                     .HasForeignKey(p => p.WardId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Consultant)
                   .WithMany()
                   .HasForeignKey(p => p.ConsultantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}