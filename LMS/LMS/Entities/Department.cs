namespace LMS.Entities
{
    internal class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; }

        public ICollection<Instructor> DepartmentMembers { get; set; }
        public int? DeanId { get; set; }
        public Instructor? Dean { get; set; }
    }
}