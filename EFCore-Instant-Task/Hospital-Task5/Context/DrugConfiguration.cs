using EFCore_Instant_Task.Hospital_Task5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class DrugConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.HasKey(d => d.Code);
            
            builder.Property(d => d.Code)
                   .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(d => d.Brand)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(d => d.Dosage)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}