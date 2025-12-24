using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Entities.Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(i => i.Office)
              .WithOne(o => o.instructor)
              .HasForeignKey<Entities.Office>(o => o.InstructorId)
              .HasPrincipalKey<Instructor>(i => i.Id)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Courses)
                   .WithOne(i => i.Instructor)
                   .HasForeignKey(i => i.InstructorId);

        }
    }
}