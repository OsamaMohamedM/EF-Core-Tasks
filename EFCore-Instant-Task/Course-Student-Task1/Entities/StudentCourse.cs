namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class StudentCourse
    {
        // Id removed to use Composite Key (StudentId, CourseId)
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public decimal Grade { get; set; }
    }
}