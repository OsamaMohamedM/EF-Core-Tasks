namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    internal class MusicianSong
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}