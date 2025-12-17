using System.ComponentModel.DataAnnotations;

namespace LMS.Entities
{
    internal abstract class StaffMember
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}