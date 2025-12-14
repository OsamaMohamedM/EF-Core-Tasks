namespace LMS.Entities
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Section> sections { get; set; }
    }
}