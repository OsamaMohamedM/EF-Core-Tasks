namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    internal class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public Musician Musician { get; set; } // Renamed from musician
        public int MusicianId { get; set; }
    }
}