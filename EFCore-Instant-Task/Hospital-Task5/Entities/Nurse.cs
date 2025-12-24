namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class Nurse
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }

        public int WardId { get; set; }
        public Ward Ward { get; set; }
        public ICollection<PatientDrugNurse> PatientDrugsNurse { get; set; }
    }
}