using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}