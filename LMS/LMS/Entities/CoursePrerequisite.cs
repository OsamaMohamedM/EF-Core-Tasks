namespace LMS.Entities
{
    internal class CoursePrerequisite:BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int PrerequisiteId { get; set; }
        public Course Prerequisite { get; set; }
    }
}