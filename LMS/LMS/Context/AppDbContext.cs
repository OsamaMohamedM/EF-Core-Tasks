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
            modelBuilder.ApplyConfiguration(new LMS.Context.SectionConfigure());

            modelBuilder.Entity<Entities.Instructor>()
                        .HasOne(i => i.Office)
                        .WithOne(o => o.instructor)
                        .HasForeignKey<Entities.Office>(o => o.InstructorId);

            modelBuilder.Entity<Entities.Course>()
                        .HasMany(c => c.sections)
                        .WithOne(s => s.course)
                        .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Entities.Instructor>()
                .HasMany(c=>c.Courses)
                .WithOne(i=>i.Instructor)
                .HasForeignKey(i=>i.InstructorId);

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