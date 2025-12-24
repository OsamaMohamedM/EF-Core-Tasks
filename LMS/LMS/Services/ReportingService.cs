using LMS.Context;
using LMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Services
{
    /// <summary>
    /// Service responsible for data aggregation and analytics
    /// Demonstrates: GroupBy, Aggregations, and Complex LINQ queries
    /// </summary>
    internal class ReportingService
    {
        private readonly AppDbContext _context;

        public ReportingService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Calculates average salary per department using GroupBy and Average
        /// Why GroupBy? Allows aggregating data by categories (departments)
        /// This demonstrates server-side aggregation - calculation happens in SQL
        /// </summary>
        public async Task<List<DepartmentSalaryReport>> GetAverageSalaryPerDepartmentAsync()
        {
            return await _context.Staff
                .OfType<Instructor>() // Filter only Instructors (not TAs)
                .Where(i => !i.IsDeleted)
                .GroupBy(i => new { i.DepartmentId, i.Department.Name }) // Group by Department
                .Select(group => new DepartmentSalaryReport
                {
                    DepartmentName = group.Key.Name,
                    AverageSalary = group.Average(i => i.Salary),
                    InstructorCount = group.Count(),
                    MinSalary = group.Min(i => i.Salary),
                    MaxSalary = group.Max(i => i.Salary),
                    TotalSalaryBudget = group.Sum(i => i.Salary)
                })
                .OrderByDescending(r => r.AverageSalary)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the top 3 most popular courses based on student enrollment
        /// Demonstrates: Complex query with multiple joins, grouping, and ordering
        /// Why? Shows how to extract business insights from relational data
        /// </summary>
        public async Task<List<PopularCourseReport>> GetTopPopularCoursesAsync(int topCount = 3)
        {
            return await _context.StudentCourses
                .Where(sc => !sc.IsDeleted)
                .GroupBy(sc => new
                {
                    sc.CourseId,
                    sc.course.Title,
                    InstructorName = sc.course.Instructor != null ? sc.course.Instructor.FullName : "No Instructor",
                    DepartmentName = sc.course.Department.Name
                })
                .Select(group => new PopularCourseReport
                {
                    CourseTitle = group.Key.Title,
                    EnrolledStudents = group.Count(),
                    AverageGrade = group.Where(sc => sc.Grade.HasValue).Average(sc => sc.Grade) ?? 0,
                    InstructorName = group.Key.InstructorName,
                    DepartmentName = group.Key.DepartmentName
                })
                .OrderByDescending(c => c.EnrolledStudents)
                .Take(topCount)
                .ToListAsync();
        }

        /// <summary>
        /// Bonus: Get student performance report showing pass/fail rates
        /// Demonstrates: Conditional aggregation using Count with predicates
        /// </summary>
        public async Task<List<StudentPerformanceReport>> GetStudentPerformanceReportAsync()
        {
            return await _context.Students
                .Where(s => !s.IsDeleted)
                .Select(s => new StudentPerformanceReport
                {
                    StudentName = s.FullName,
                    TotalCourses = s.StudentCourses.Count(sc => !sc.IsDeleted),
                    PassedCourses = s.StudentCourses.Count(sc => !sc.IsDeleted && sc.Grade >= 60),
                    FailedCourses = s.StudentCourses.Count(sc => !sc.IsDeleted && sc.Grade < 60 && sc.Grade.HasValue),
                    AverageGrade = s.StudentCourses
                        .Where(sc => !sc.IsDeleted && sc.Grade.HasValue)
                        .Average(sc => sc.Grade) ?? 0,
                    AdmissionDate = s.AdmissionDate
                })
                .Where(r => r.TotalCourses > 0) // Only students with courses
                .OrderByDescending(r => r.AverageGrade)
                .ToListAsync();
        }

        /// <summary>
        /// Bonus: Department statistics with comprehensive metrics
        /// </summary>
        public async Task<List<DepartmentStatisticsReport>> GetDepartmentStatisticsAsync()
        {
            return await _context.Departments
                .Where(d => !d.IsDeleted)
                .Select(d => new DepartmentStatisticsReport
                {
                    DepartmentName = d.Name,
                    TotalCourses = d.Courses.Count(c => !c.IsDeleted),
                    TotalInstructors = d.DepartmentMembers.Count(dm => !dm.IsDeleted),
                    DeanName = d.Dean != null ? d.Dean.FullName : "No Dean Assigned",
                    TotalStudentsEnrolled = d.Courses
                        .SelectMany(c => c.StudentCourses)
                        .Where(sc => !sc.IsDeleted)
                        .Select(sc => sc.StudentId)
                        .Distinct()
                        .Count()
                })
                .OrderByDescending(d => d.TotalStudentsEnrolled)
                .ToListAsync();
        }
    }

    #region Report DTOs

    /// <summary>
    /// DTO for Department Salary Report
    /// </summary>
    public class DepartmentSalaryReport
    {
        public string DepartmentName { get; set; }
        public decimal AverageSalary { get; set; }
        public int InstructorCount { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal TotalSalaryBudget { get; set; }
    }

    /// <summary>
    /// DTO for Popular Course Report
    /// </summary>
    public class PopularCourseReport
    {
        public string CourseTitle { get; set; }
        public int EnrolledStudents { get; set; }
        public decimal AverageGrade { get; set; }
        public string InstructorName { get; set; }
        public string DepartmentName { get; set; }
    }

    /// <summary>
    /// DTO for Student Performance Report
    /// </summary>
    public class StudentPerformanceReport
    {
        public string StudentName { get; set; }
        public int TotalCourses { get; set; }
        public int PassedCourses { get; set; }
        public int FailedCourses { get; set; }
        public decimal AverageGrade { get; set; }
        public DateTime AdmissionDate { get; set; }
    }

    /// <summary>
    /// DTO for Department Statistics Report
    /// </summary>
    public class DepartmentStatisticsReport
    {
        public string DepartmentName { get; set; }
        public int TotalCourses { get; set; }
        public int TotalInstructors { get; set; }
        public string DeanName { get; set; }
        public int TotalStudentsEnrolled { get; set; }
    }

    #endregion
}
