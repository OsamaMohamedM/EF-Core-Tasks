namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Crew
    {
        public int Id { get; set; }
        public string MajorPilot { get; set; }
        public string AssistantPilot { get; set; }
        public string Host1 { get; set; }
        public string Host2 { get; set; }
        
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
