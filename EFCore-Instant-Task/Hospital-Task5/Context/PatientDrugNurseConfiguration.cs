using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class PatientDrugNurseConfiguration : IEntityTypeConfiguration<PatientDrugNurse>
    {
        public void Configure(EntityTypeBuilder<PatientDrugNurse> builder)
        {
            builder.HasKey(pd => new { pd.PatientId, pd.DrugCode, pd.Date, pd.Time });

            builder.Property(pd => pd.Dosage)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(pd => pd.Date)
                   .IsRequired();

            builder.Property(pd => pd.Time)
                   .IsRequired();

            builder.HasOne(pd => pd.Patient)
                   .WithMany(p => p.PatientDrugs)
                   .HasForeignKey(pd => pd.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pd => pd.Drug)
                   .WithMany(d => d.PatientDrugs)
                   .HasForeignKey(pd => pd.DrugCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pd => pd.Nurse)
                   .WithMany(n => n.PatientDrugsNurse)
                   .HasForeignKey(pd => pd.NurseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}