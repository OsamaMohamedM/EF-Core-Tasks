namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class PatientDrugNurse
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public string DrugCode { get; set; }
        public Drug Drug { get; set; }

        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Dosage { get; set; }
    }
}