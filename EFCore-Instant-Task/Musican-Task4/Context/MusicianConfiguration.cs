using EFCore_Instant_Task.Musican_Task4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class MusicianConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(m => m.PhNumber)
                   .IsRequired();
            builder.OwnsOne(m => m.Address, a =>
            {
                a.Property(p => p.Street).HasMaxLength(200);
                a.Property(p => p.City).HasMaxLength(100);
            });
        }
    }
}