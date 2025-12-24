namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class Consultant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> AssignedPatients { get; set; }
        public ICollection<PatientConsultant> ExmainePatients { get; set; }
    }
}