namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
    }
}
