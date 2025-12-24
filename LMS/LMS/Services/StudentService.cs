using LMS.Context;
using LMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Services
{
    /// <summary>
    /// Service responsible for Student CRUD operations
    /// Demonstrates: Basic EF Core operations and Soft Delete pattern
    /// </summary>
    internal class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new student in the database
        /// </summary>
        public async Task<Student> CreateStudentAsync(string firstName, string lastName, Address address)
        {
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                FullName = $"{firstName} {lastName}",
                Address = address,
                AdmissionDate = DateTime.UtcNow,
                StudentStatus = Enums.StudentStatus.Active
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        /// <summary>
        /// Retrieves a student by ID Returns null if student is not found or soft deleted
        /// </summary>
        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students
                .Where(s => !s.IsDeleted)
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        /// <summary>
        /// Updates a student's name
        /// </summary>
        public async Task<bool> UpdateStudentNameAsync(int studentId, string newFirstName, string newLastName)
        {
            var student = await GetStudentByIdAsync(studentId);

            if (student == null)
            {
                return false;
            }

            student.FirstName = newFirstName;
            student.LastName = newLastName;
            student.FullName = $"{newFirstName} {newLastName}";

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Soft deletes a student (sets IsDeleted = true) Why Soft Delete? Preserves historical
        /// data, allows for recovery, maintains referential integrity The
        /// DbContext.SaveChangesAsync override automatically handles this
        /// </summary>
        public async Task<bool> SoftDeleteStudentAsync(int studentId)
        {
            var student = await GetStudentByIdAsync(studentId);

            if (student == null)
            {
                return false;
            }

            // Remove() triggers soft delete via SaveChangesAsync override
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Verifies if a student is soft deleted
        /// </summary>
        public async Task<bool> IsStudentDeletedAsync(int studentId)
        {
            var student = await _context.Students
                .IgnoreQueryFilters() // Bypass soft delete filter to check IsDeleted status
                .FirstOrDefaultAsync(s => s.Id == studentId);

            return student?.IsDeleted ?? false;
        }
    }
}