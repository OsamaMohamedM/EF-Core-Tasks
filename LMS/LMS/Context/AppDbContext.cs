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
            #region Apply Configurations

            modelBuilder.ApplyConfiguration(new LMS.Context.StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.SectionConfigure());
            modelBuilder.ApplyConfiguration(new LMS.Context.StudentCourseConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.TAConfiguration());

            #endregion Apply Configurations

            modelBuilder.Entity<Entities.ArchivedStudent>()
                        .ToTable("ArchivedStudents", t => t.ExcludeFromMigrations());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.ArchivedStudent> ArchivedStudents { get; set; }

        public DbSet<Entities.Section> Sections { get; set; }

        public DbSet<Entities.Office> Offices { get; set; }
    }
}