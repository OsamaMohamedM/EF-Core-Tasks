namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }

        public ICollection<PatientConsultant> PatientConsultants { get; set; }
        public ICollection<PatientDrugNurse> PatientDrugs { get; set; }

        public Ward Ward { get; set; }

        public int WardId { get; set; }
    }
}