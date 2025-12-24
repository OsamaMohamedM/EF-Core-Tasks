using System.ComponentModel.DataAnnotations;

namespace EFCore_Instant_Task.Musican_Task4.Entities
{
    internal class Instrument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}