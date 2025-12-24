using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.Musican_Task4.Context
{
    internal class MusicianDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicianSongConfiguration());
            modelBuilder.ApplyConfiguration(new InstrumentMusicianConfiguration());
            modelBuilder.ApplyConfiguration(new MusicianConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new InstrumentConfiguration()); // Added
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Musician> Musicians { get; set; }
        public DbSet<Entities.Album> Albums { get; set; }
        public DbSet<Entities.InstrumentMusician> InstrumentMusicians { get; set; }
        public DbSet<Entities.Instrument> Instruments { get; set; }
        public DbSet<Entities.Song> Songs { get; set; }
        public DbSet<Entities.MusicianSong> MusicianSongs { get; set; }
    }
}