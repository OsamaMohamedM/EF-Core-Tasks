using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class TAConfiguration : IEntityTypeConfiguration<TeachingAssistant>
    {
        public void Configure(EntityTypeBuilder<TeachingAssistant> builder)
        {
            builder.HasMany(ta => ta.Sections)
                   .WithOne(s => s.TeachingAssistant)
                   .HasForeignKey(s => s.TeachingAssistantId);
        }
    }
}