using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entities
{
    [Table("Teachers")]
    internal class Instructor
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Comment("Annual salary of the instructor in USD")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public Office Office { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}