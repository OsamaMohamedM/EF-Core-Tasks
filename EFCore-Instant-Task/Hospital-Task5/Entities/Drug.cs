using System.ComponentModel.DataAnnotations;

namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class Drug
    {
        [Key]
        public string Code { get; set; }
        public string Brand { get; set; }
        public string Dosage { get; set; }
        
        public ICollection<PatientDrugNurse> PatientDrugs { get; set; }
    }
}