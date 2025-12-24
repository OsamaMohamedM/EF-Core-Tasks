using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class StaffConfiguration : IEntityTypeConfiguration<StaffMember>
    {
        public void Configure(EntityTypeBuilder<StaffMember> builder)
        {
            builder.HasAlternateKey(s => s.Id);

            builder.Property(s => s.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.Property(s => s.FirstName)
                   .IsRequired(true)
                   .HasMaxLength(20);
            builder.Property(s => s.LastName)
                   .IsRequired(true)
                   .HasMaxLength(20);

            builder.Property(s => s.Salary)
                   .IsRequired(true)
                   .HasDefaultValue(0m)
                   .HasColumnType("decimal(18, 2)")
                   .HasComment("Annual salary of the instructor in USD");

            builder.Property(s => s.HireDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.OwnsOne(
                s => s.Address,
                a =>
                {
                    a.Property(p => p.Street).HasMaxLength(150).HasColumnName("Address_Street");
                    a.Property(p => p.City).HasMaxLength(50).HasColumnName("Address_City");
                    a.Property(p => p.Country).HasMaxLength(50).HasColumnName("Address_Country");
                }
                );
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}