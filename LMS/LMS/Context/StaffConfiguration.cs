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
        }
    }
}