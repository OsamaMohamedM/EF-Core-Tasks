using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Entities.Course>
    {
        public void Configure(EntityTypeBuilder<Entities.Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
            builder.Property(c => c.Hours).IsRequired().HasDefaultValue(2);

            builder.HasMany(c => c.sections)
                   .WithOne(s => s.course)
                   .HasForeignKey(s => s.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.CourseStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .HasDefaultValue(Enums.CourseStatus.Draft);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}