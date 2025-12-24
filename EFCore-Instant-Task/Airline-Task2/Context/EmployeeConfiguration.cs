using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(e => e.Address)
                   .IsRequired()
                   .HasMaxLength(200);
            
            builder.Property(e => e.Position)
                   .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(e => e.Gender)
                   .IsRequired()
                   .HasMaxLength(10);
            
            builder.Property(e => e.Birthday)
                   .IsRequired();
            
            builder.Property(e => e.Qualifications)
                   .HasMaxLength(500);
            
            builder.ToTable(t => t.HasCheckConstraint("CK_Employee_Birthday", "[Birthday] <= GetDate()"));
            
            builder.HasOne(e => e.Airline)
                   .WithMany(a => a.Employees)
                   .HasForeignKey(e => e.AirlineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
