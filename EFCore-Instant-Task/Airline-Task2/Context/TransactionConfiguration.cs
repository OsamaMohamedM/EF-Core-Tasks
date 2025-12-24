using EFCore_Instant_Task.Airline_Task6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(500);
            
            builder.Property(t => t.Date)
                   .IsRequired()
                   .HasDefaultValueSql("GetDate()");
            
            builder.Property(t => t.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            
            builder.HasOne(t => t.Airline)
                   .WithMany(a => a.Transactions)
                   .HasForeignKey(t => t.AirlineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
