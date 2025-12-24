namespace LMS.Entities
{
    internal class StudentCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }

        public decimal? Grade { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public Section Section { get; set; }
        public int SectionId { get; set; }
    }
}