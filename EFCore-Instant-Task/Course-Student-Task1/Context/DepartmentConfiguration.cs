using EFCore_Instant_Task.Course_Student_Task1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Entities.Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.HiringDate).HasDefaultValueSql("GetDate()");
            builder.HasOne(d => d.Manager)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}