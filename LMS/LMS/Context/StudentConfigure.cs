using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.AdmissionDate)
                .HasColumnName("EnrollmentDate")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.FullName)
                .HasComputedColumnSql("[FirstName] + ' , ' + [LastName]");

            builder.OwnsOne(
                s => s.Address,
                a =>
                {
                    a.Property(p => p.Street).HasMaxLength(150).HasColumnName("Address_Street");
                    a.Property(p => p.City).HasMaxLength(50).HasColumnName("Address_City");
                    a.Property(p => p.Country).HasMaxLength(50).HasColumnName("Address_Country");
                }
                );
            builder.Property(s => s.StudentStatus)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .HasDefaultValue(Enums.StudentStatus.Inactive);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}