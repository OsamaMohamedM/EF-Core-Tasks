using System.ComponentModel.DataAnnotations;

namespace EFCore_Instant_Task.Course_Student_Task1.Entities
{
    internal class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}