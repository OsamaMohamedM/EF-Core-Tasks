using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.Airline_Task6.Context
{
    internal class AirlineDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AirlineDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirlineConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftConfiguration());
            modelBuilder.ApplyConfiguration(new CrewConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftRouteConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Airline> Airlines { get; set; }
        public DbSet<Entities.Phone> Phones { get; set; }
        public DbSet<Entities.Employee> Employees { get; set; }
        public DbSet<Entities.Aircraft> Aircrafts { get; set; }
        public DbSet<Entities.Crew> Crews { get; set; }
        public DbSet<Entities.Transaction> Transactions { get; set; }
        public DbSet<Entities.Route> Routes { get; set; }
        public DbSet<Entities.AircraftRoute> AircraftRoutes { get; set; }
    }
}
