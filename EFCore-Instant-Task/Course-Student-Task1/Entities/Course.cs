namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Duration { get; set; }

        public string Description { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
    }
}