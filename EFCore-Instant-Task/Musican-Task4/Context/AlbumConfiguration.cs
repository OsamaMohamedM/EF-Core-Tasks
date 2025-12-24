using EFCore_Instant_Task.Musican_Task4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Date)
                  .HasDefaultValueSql("GetDate()");

            builder.HasOne(a => a.Musician)
                  .WithMany()
                  .HasForeignKey(a => a.MusicianId);
        }
    }
}