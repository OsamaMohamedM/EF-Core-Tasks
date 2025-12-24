using EFCore_Instant_Task.Musican_Task4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class MusicianSongConfiguration : IEntityTypeConfiguration<MusicianSong>
    {
        public void Configure(EntityTypeBuilder<MusicianSong> builder)
        {
            builder.HasKey(ms => new { ms.MusicianId, ms.SongId });
            builder.HasOne(ms => ms.Musician)
                  .WithMany()
                  .HasForeignKey(ms => ms.MusicianId);
            builder.HasOne(ms => ms.Song)
                  .WithMany()
                  .HasForeignKey(ms => ms.SongId);
        }
    }
}