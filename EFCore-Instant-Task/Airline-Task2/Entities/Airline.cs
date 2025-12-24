namespace EFCore_Instant_Task.Airline_Task6.Entities
{
    internal class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string ContactPerson { get; set; }
        
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
