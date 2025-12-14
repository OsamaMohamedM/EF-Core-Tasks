using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OSOS\\OSAMA;Database=LMS;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LMS.Context.StudentConfiguration());
            modelBuilder.Entity<Entities.ArchivedStudent>()
                        .ToTable("ArchivedStudents", t => t.ExcludeFromMigrations());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.ArchivedStudent> ArchivedStudents { get; set; }
    }
}