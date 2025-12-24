using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses");
            builder.HasKey(sc => new { sc.CourseId, sc.StudentId });

            builder.Property(sc => sc.Grade)
                   .HasColumnType("decimal(5, 2)")
                   .IsRequired(false);

            builder.Property(sc => sc.EnrollmentDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(sc => sc.course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId);

            builder.HasOne(sc => sc.Student)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Section)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.SectionId);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}