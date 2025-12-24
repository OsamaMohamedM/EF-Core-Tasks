using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.Hospital_Task5.Context
{
    internal class HospitalDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultantConfiguration());
            modelBuilder.ApplyConfiguration(new WardConfiguration());
            modelBuilder.ApplyConfiguration(new NurseConfiguration());
            modelBuilder.ApplyConfiguration(new DrugConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConsultantConfiguration());
            modelBuilder.ApplyConfiguration(new PatientDrugNurseConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Patient> Patients { get; set; }
        public DbSet<Entities.Consultant> Consultants { get; set; }
        public DbSet<Entities.Ward> Wards { get; set; }
        public DbSet<Entities.Nurse> Nurses { get; set; }
        public DbSet<Entities.Drug> Drugs { get; set; }
        public DbSet<Entities.PatientConsultant> PatientConsultants { get; set; }
        public DbSet<Entities.PatientDrugNurse> PatientDrugs { get; set; }
        public DbSet<Entities.PatientWard> PatientWards { get; set; }
    }
}