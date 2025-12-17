using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class CoursePrerequisiteConfiguration : IEntityTypeConfiguration<CoursePrerequisite>
    {
        public void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
        {
            
            builder.HasKey(cp => new { cp.CourseId, cp.PrerequisiteId });

            builder.HasOne(cp => cp.Course) 
                   .WithMany(c => c.Prerequisites) 
                   .HasForeignKey(cp => cp.CourseId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(cp => cp.Prerequisite)
                   .WithMany(c => c.Dependents) 
                   .HasForeignKey(cp => cp.PrerequisiteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}