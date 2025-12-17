namespace LMS.Entities
{
    internal class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }

        public TeachingAssistant TeachingAssistant { get; set; }
        public int TeachingAssistantId { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}