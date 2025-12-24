namespace EFCore_Instant_Task.RealEstate_Task7.Entities
{
    internal class Property
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        
        public int SalesOfficeId { get; set; }
        public SalesOffice SalesOffice { get; set; }
        
        public ICollection<PropertyOwner> PropertyOwners { get; set; }
    }
}
