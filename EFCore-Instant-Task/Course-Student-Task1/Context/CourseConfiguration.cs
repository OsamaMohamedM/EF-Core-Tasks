using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(c => c.Duration).IsRequired().HasColumnType("decimal(7,3)");

            builder.ToTable(t => t.HasCheckConstraint("Courses_Constrain_Duration", "[Duration]>0 and [Duration]<5"));

            builder.Property(c => c.Description)
                   .HasMaxLength(500)
                    .IsRequired();

            builder.HasOne(c => c.Topic)
                   .WithMany()
                   .HasForeignKey(c => c.TopicId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}