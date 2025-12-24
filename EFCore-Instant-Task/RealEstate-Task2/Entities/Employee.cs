namespace EFCore_Instant_Task.RealEstate_Task7.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SalesOfficeId { get; set; }
        public SalesOffice SalesOffice { get; set; }

        public SalesOffice ManagedOffice { get; set; }
    }
}