using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Entities.Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Address).IsRequired().HasMaxLength(200);
            builder.Property(i => i.Salary)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired().HasDefaultValue(0m);

            builder.Property(i => i.Bonus)
                   .HasDefaultValue(0m)
                   .HasColumnType("decimal(18,2)");

            builder.Property(i => i.HourlyRate)
                   .HasColumnType("decimal(18,2)");

            builder.ToTable(t => t.HasCheckConstraint("Instructor_Constrain_Salary", "[Salary]>=0"));
            builder.ToTable(t => t.HasCheckConstraint("Instructor_Constrain_HourlyRate", "[HourlyRate]>=0"));

            builder.HasOne(i => i.Department)
                   .WithMany()
                   .HasForeignKey(i => i.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}