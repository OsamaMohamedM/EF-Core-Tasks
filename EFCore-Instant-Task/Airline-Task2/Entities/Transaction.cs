namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
    }
}
