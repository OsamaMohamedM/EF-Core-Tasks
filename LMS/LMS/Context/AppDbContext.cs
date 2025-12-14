using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OSOS\\OSAMA;Database=LMS;Trusted_Connection=True;");
        }
    }
}