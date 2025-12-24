using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Age).IsRequired();
            builder.ToTable(t => t.HasCheckConstraint("CK_Student_Age_Range", "[Age] >= 18 AND [Age] <= 60"));
            builder.Property(s => s.Address).HasMaxLength(200).IsRequired();

            builder.HasOne(s => s.Department)
                   .WithMany()
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}