using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class SectionConfigure : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");
            builder.HasKey(s => new { s.Id, s.Title });
            builder.Property(s => s.Title).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
            builder.Property(s => s.StartDate).IsRequired();
            builder.Property(s => s.EndDate).IsRequired();
            builder.Property(s => s.CourseId).IsRequired();
        }
    }
}