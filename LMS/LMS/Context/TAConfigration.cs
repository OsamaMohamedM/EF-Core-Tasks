using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class TAConfiguration : IEntityTypeConfiguration<TeachingAssistant>
    {
        public void Configure(EntityTypeBuilder<TeachingAssistant> builder)
        {
            builder.ToTable("TeachingAssistants");
            builder.HasKey(ta => ta.Id);
            builder.Property(ta => ta.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(ta => ta.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(ta => ta.FullName)
                   .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.Property(ta => ta.HireDate)
                    .HasDefaultValueSql("GETDATE()")
                     .IsRequired();

            builder.HasMany(ta => ta.Sections)
                   .WithOne(s => s.TeachingAssistant)
                   .HasForeignKey(s => s.TeachingAssistantId);
        }
    }
}