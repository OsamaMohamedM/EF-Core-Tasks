using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Context
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Entities.Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(d => d.Dean)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.DeanId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.DepartmentMembers)
                   .WithOne(i => i.Department)
                   .HasForeignKey(i => i.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Courses)
                   .WithOne(c => c.Department)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}