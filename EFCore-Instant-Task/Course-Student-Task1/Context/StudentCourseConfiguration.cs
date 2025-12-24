using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Property(t => t.Grade).HasDefaultValue(0)
                   .HasColumnType("decimal(7,3)");

            builder.ToTable(t => t.HasCheckConstraint("StudentCourse_Constrain_Grade", "[Grade]>=0 and [Grade]<=100"));

            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId);
        }
    }
}