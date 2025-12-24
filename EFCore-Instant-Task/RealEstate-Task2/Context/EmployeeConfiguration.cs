using EFCore_Instant_Task.RealEstate_Task7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.HasOne(e => e.SalesOffice)
                   .WithMany(s => s.Employees)
                   .HasForeignKey(e => e.SalesOfficeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
