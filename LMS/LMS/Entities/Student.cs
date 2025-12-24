using LMS.Enums;

namespace LMS.Entities
{
    internal class Student : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Address Address { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public DateTime AdmissionDate { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}