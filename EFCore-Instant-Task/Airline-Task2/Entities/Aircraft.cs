namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
        
        public Crew Crew { get; set; }
        public ICollection<AircraftRoute> AircraftRoutes { get; set; }
    }
}
