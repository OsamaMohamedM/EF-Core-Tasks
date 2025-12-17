namespace LMS.Entities
{
    internal class TeachingAssistant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}