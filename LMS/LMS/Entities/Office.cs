using System.ComponentModel.DataAnnotations;

namespace LMS.Entities
{
    internal class Office : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string OfficeName { get; set; }

        [Required, MaxLength(15)]
        public string Building { get; set; }

        public int? InstructorId { get; set; }
        public Instructor instructor { get; set; }
    }
}