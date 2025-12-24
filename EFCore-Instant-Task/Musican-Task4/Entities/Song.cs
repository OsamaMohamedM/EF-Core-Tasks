namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    internal class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}