namespace EFCore_Instant_Task.RealEstate_Task7.Entities
{
    internal class SalesOffice
    {
        public int Number { get; set; }
        public string Location { get; set; }
        
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
