using EFCore_Instant_Task.Musican_Task4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(s => s.Author)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasOne(s => s.Album) // Updated name
                   .WithMany()
                   .HasForeignKey(s => s.AlbumId);
        }
    }
}