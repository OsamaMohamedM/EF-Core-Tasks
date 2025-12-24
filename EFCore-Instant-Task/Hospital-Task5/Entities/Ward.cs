namespace EFCore_Instant_Task.Hospital_Task5.Entities
{
    internal class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<Nurse> Nurses { get; set; }

        public Nurse Manager { get; set; }
        public int ManagerId { get; set; }
    }
}