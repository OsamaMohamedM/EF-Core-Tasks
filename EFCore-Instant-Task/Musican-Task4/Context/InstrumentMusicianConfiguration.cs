using EFCore_Instant_Task.Musican_Task4.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class InstrumentMusicianConfiguration : IEntityTypeConfiguration<InstrumentMusician>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstrumentMusician> builder)
        {
            builder.HasKey(im => new { im.InstrumentId, im.MusicianId });
            builder.HasOne(im => im.Instrument)
                   .WithMany()
                   .HasForeignKey(im => im.InstrumentId);
            builder.HasOne(im => im.Musician)
                   .WithMany()
                   .HasForeignKey(im => im.MusicianId);
        }
    }
}