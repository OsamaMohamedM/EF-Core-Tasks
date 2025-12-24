namespace EFCore_Instant_Task.RealEstate_Task7.Entities
{
    internal class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<PropertyOwner> PropertyOwners { get; set; }
    }
}
