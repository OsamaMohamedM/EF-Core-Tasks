namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    internal class InstrumentMusician
    {
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}