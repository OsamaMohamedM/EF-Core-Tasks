namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}