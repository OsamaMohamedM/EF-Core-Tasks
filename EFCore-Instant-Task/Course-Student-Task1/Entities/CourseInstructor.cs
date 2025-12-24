namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public Course Course { get; set; }
        public Instructor Instructor { get; set; }

        public decimal Evaluation { get; set; }
    }
}