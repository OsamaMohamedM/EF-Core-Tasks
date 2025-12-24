namespace EFCore_Instant_Task.RealEstate_Task7.Entities
{
    internal class PropertyOwner
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public decimal Percent { get; set; }
    }
}