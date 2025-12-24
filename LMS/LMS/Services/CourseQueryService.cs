using LMS.Context;
using LMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Services
{
    /// <summary>
    /// Service responsible for demonstrating various EF Core Loading Strategies
    /// Shows: Eager Loading, Explicit Loading, and Projection Loading
    /// </summary>
    internal class CourseQueryService
    {
        private readonly AppDbContext _context;

        public CourseQueryService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demonstrates EAGER LOADING using .Include() and .ThenInclude()
        /// Why? Loads all related data in a single query (1 SQL query with JOINs)
        /// Best for: When you know you'll need related data upfront
        /// Pros: Single query, no lazy loading issues
        /// Cons: Can load unnecessary data if not careful
        /// </summary>
        public async Task<Course?> GetCourseWithRelatedDataEagerLoadingAsync(int courseId)
        {
            return await _context.Courses
                .Include(c => c.Department)           // Include Department
                .Include(c => c.Instructor)           // Include Instructor
                    .ThenInclude(i => i.Office)       // Then include Instructor's Office
                .Include(c => c.Instructor)
                    .ThenInclude(i => i.Address)      // Then include Instructor's Address
                .Where(c => !c.IsDeleted && c.Id == courseId)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Demonstrates EXPLICIT LOADING using context.Entry().Collection().Load()
        /// Why? Gives you fine-grained control over what to load and when
        /// Best for: When you want to load related data conditionally or on-demand
        /// Pros: Load only what you need, control over timing
        /// Cons: Multiple database queries
        /// </summary>
        public async Task<Department?> GetDepartmentWithExplicitLoadingAsync(int departmentId)
        {
            // First, load the Department
            var department = await _context.Departments
                .Where(d => !d.IsDeleted && d.Id == departmentId)
                .FirstOrDefaultAsync();

            if (department == null)
            {
                return null;
            }

            // Explicitly load the related collections ONLY if needed
            // This executes separate queries for each collection

            // Load all courses in this department
            await _context.Entry(department)
                .Collection(d => d.Courses)
                .Query()
                .Where(c => !c.IsDeleted)
                .LoadAsync();

            // Load all department members (instructors)
            await _context.Entry(department)
                .Collection(d => d.DepartmentMembers)
                .Query()
                .Where(dm => !dm.IsDeleted)
                .LoadAsync();

            // Load the Dean reference
            await _context.Entry(department)
                .Reference(d => d.Dean)
                .LoadAsync();

            return department;
        }

        /// <summary>
        /// Demonstrates PROJECTION LOADING using .Select()
        /// Why? Only retrieves specific columns, reducing data transfer and memory usage
        /// Best for: Performance-critical scenarios, DTOs, reports, dashboards
        /// Pros: Optimal performance, only loads what you need, no tracking overhead
        /// Cons: Returns anonymous types or DTOs (not entities), can't use navigation properties
        /// </summary>
        public async Task<List<CourseProjectionDto>> GetCoursesProjectionAsync()
        {
            return await _context.Courses
                .Where(c => !c.IsDeleted)
                .Select(c => new CourseProjectionDto
                {
                    CourseId = c.Id,
                    CourseTitle = c.Title,
                    Hours = c.Hours,
                    DepartmentName = c.Department.Name,
                    InstructorFullName = c.Instructor != null ? c.Instructor.FullName : "No Instructor Assigned",
                    StudentCount = c.StudentCourses.Count(sc => !sc.IsDeleted)
                })
                .OrderByDescending(c => c.StudentCount)
                .ToListAsync();
        }

        /// <summary>
        /// Bonus: Demonstrates mixed approach - Projection with calculated fields
        /// </summary>
        public async Task<object> GetCourseStatisticsAsync(int courseId)
        {
            return await _context.Courses
                .Where(c => !c.IsDeleted && c.Id == courseId)
                .Select(c => new
                {
                    CourseTitle = c.Title,
                    EnrolledStudents = c.StudentCourses.Count(sc => !sc.IsDeleted),
                    AverageGrade = c.StudentCourses
                        .Where(sc => !sc.IsDeleted && sc.Grade.HasValue)
                        .Average(sc => sc.Grade) ?? 0,
                    PassRate = c.StudentCourses
                        .Where(sc => !sc.IsDeleted && sc.Grade.HasValue)
                        .Count(sc => sc.Grade >= 60) * 100.0 /
                        c.StudentCourses.Count(sc => !sc.IsDeleted && sc.Grade.HasValue)
                })
                .FirstOrDefaultAsync();
        }
    }

    /// <summary>
    /// DTO for Course Projection - demonstrates transferring only necessary data
    /// </summary>
    public class CourseProjectionDto
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public double Hours { get; set; }
        public string DepartmentName { get; set; }
        public string InstructorFullName { get; set; }
        public int StudentCount { get; set; }
    }
}
