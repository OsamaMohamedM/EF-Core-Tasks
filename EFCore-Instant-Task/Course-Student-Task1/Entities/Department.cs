using System.ComponentModel.DataAnnotations;

namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class Department
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Name { get; set; }

        public Instructor Manager { get; set; } 

        public int ManagerId { get; set; } 

        public DateTime HiringDate { get; set; }
    }
}