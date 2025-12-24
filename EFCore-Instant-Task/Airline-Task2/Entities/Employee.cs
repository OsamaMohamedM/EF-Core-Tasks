namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Qualifications { get; set; }
        
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
    }
}
