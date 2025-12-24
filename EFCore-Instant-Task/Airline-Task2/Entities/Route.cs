namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Route
    {
        public int Id { get; set; }
        public string Classification { get; set; }
        public decimal Distance { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        
        public ICollection<AircraftRoute> AircraftRoutes { get; set; }
    }
}
