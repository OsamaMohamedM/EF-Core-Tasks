namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class PatientConsultant
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
    }
}