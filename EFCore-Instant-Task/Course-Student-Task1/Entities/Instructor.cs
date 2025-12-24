using System.ComponentModel.DataAnnotations;

namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        [MinLength(5)]
        public string Address { get; set; }

        public decimal Salary { get; set; }

        public decimal Bonus { get; set; }

        public decimal HourlyRate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}