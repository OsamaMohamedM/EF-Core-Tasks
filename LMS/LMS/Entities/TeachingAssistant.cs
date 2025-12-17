namespace LMS.Entities
{
    internal class TeachingAssistant : StaffMember
    {
        public ICollection<Section> Sections { get; set; }
    }
}