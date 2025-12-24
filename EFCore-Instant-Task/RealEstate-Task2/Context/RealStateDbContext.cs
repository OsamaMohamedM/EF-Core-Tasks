using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class RealStateDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RealEstateDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyOwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOfficeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Employee> Employees { get; set; }
        public DbSet<Entities.Location> Locations { get; set; }
        public DbSet<Entities.Property> Properties { get; set; }
        public DbSet<Entities.SalesOffice> SalesOffices { get; set; }
        public DbSet<Entities.Owner> Owners { get; set; }

        public DbSet<Entities.PropertyOwner> PropertyOwners
        {
            get; set;
        }
    }
}