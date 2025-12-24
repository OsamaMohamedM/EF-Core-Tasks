using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class PatientConsultantConfiguration : IEntityTypeConfiguration<PatientConsultant>
    {
        public void Configure(EntityTypeBuilder<PatientConsultant> builder)
        {
            builder.HasKey(pc => new { pc.PatientId, pc.ConsultantId });

            builder.HasOne(pc => pc.Patient)
                   .WithMany(p => p.PatientConsultants)
                   .HasForeignKey(pc => pc.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Consultant)
                   .WithMany(p => p.ExmainePatients)
                   .HasForeignKey(pc => pc.ConsultantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}