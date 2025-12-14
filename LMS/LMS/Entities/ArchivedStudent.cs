using System.ComponentModel.DataAnnotations;

namespace LMS.Entities
{
    internal class ArchivedStudent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public DateTime GraduationYear { get; set; }

        [Required]
        public decimal gpa { get; set; }
    }
}