namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class AircraftRoute
    {
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        
        public int RouteId { get; set; }
        public Route Route { get; set; }
        
        public int NumOfPassengers { get; set; }
        public decimal Price { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int Duration { get; set; }
    }
}
