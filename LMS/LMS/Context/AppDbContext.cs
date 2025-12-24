using LMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            modelBuilder.ApplyConfiguration(new LMS.Context.StaffConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LMS.Context.CoursePrerequisiteConfiguration());

            #endregion Apply Configurations

            modelBuilder.Entity<Entities.ArchivedStudent>()
                        .ToTable("ArchivedStudents", t => t.ExcludeFromMigrations());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Property(x => x.CreatedOn).IsModified = false;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    // 1. تحويل العملية لتحديث بدلاً من مسح
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;

                    // 2. منع تحديث CreatedOn
                    entry.Property(x => x.CreatedOn).IsModified = false;

                    // 3. تأمين الـ Owned Entities (مثل Address)
                    // نمر على كل المراجع (References) التي تمثل Owned Types ونغير حالتها لـ Unchanged
                    foreach (var navigationEntry in entry.Navigations)
                    {
                        if (navigationEntry is ReferenceEntry referenceEntry &&
                            referenceEntry.TargetEntry != null &&
                            referenceEntry.TargetEntry.Metadata.IsOwned())
                        {
                            referenceEntry.TargetEntry.State = EntityState.Unchanged;
                        }
                    }

                    // 4. تأمين باقي الخصائص في الكائن الأب
                    foreach (var property in entry.Properties)
                    {
                        if (property.Metadata.Name != nameof(BaseEntity.IsDeleted) &&
                            property.Metadata.Name != nameof(BaseEntity.LastModifiedOn))
                        {
                            property.IsModified = false;
                        }
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<StaffMember> Staff { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.ArchivedStudent> ArchivedStudents { get; set; }

        public DbSet<Entities.Section> Sections { get; set; }
        public DbSet<Entities.Department> Departments { get; set; }

        public DbSet<Entities.CoursePrerequisite> CoursePrerequisites { get; set; }

        public DbSet<Entities.Office> Offices { get; set; }

        public DbSet<Entities.StudentCourse> StudentCourses { get; set; }
        public DbSet<Entities.TeachingAssistant> TAs { get; set; }
    }
}