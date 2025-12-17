namespace LMS.Entities
{
    internal class Instructor : StaffMember
    {
        public Office Office { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}