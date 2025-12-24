using Microsoft.EntityFrameworkCore;

namespace EFCore_Instant_Task.Course_Student_Task1.Context
{
    internal class CourseStudentDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseInstructorConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        }

        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Topic> Topics { get; set; }
        public DbSet<Entities.Department> Departments { get; set; }
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Entities.StudentCourse> StudentCourses { get; set; }
    }
}