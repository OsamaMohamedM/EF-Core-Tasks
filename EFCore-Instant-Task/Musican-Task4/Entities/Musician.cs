namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhNumber { get; set; }
        public Address Address { get; set; }
    }
}