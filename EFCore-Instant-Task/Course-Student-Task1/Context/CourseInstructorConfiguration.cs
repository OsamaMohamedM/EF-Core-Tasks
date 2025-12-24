using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasKey(ci => new { ci.CourseId, ci.InstructorId });

            builder.Property(ci => ci.Evaluation)
                   .HasColumnType("decimal(5, 2)")
                   .IsRequired();

            builder.HasOne(ci => ci.Course)
                   .WithMany()
                   .HasForeignKey(ci => ci.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ci => ci.Instructor)
                   .WithMany()
                   .HasForeignKey(ci => ci.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}