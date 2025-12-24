using LMS.Context;
using LMS.DataSeed;
using LMS.Entities;
using LMS.Services;

Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║        LMS - Learning Management System Demo                           ║");
Console.WriteLine("║     Showcasing EF Core 8 Skills & Data Manipulation                    ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");
Console.WriteLine();

try
{
    using var context = new AppDbContext();

    Console.WriteLine(" Initializing Database and Seeding Data...");
    DataSeeder.Seed(context);
    Console.WriteLine(" Database seeded successfully!");
    Console.WriteLine();

    // Instantiate Services (Simulating Dependency Injection)
    var studentService = new StudentService(context);
    var courseQueryService = new CourseQueryService(context);
    var reportingService = new ReportingService(context);

    PrintSectionHeader("  STUDENT SERVICE - CRUD OPERATIONS");

    // CREATE
    Console.WriteLine(" Creating a new student...");
    var newStudent = await studentService.CreateStudentAsync(
        "Layla",
        "Ahmed",
        new Address { Street = "Zamalek Street", City = "Cairo", Country = "Egypt", State = "" }
    );
    Console.WriteLine($" Student created: {newStudent.FullName} (ID: {newStudent.Id})");
    Console.WriteLine();

    // READ
    Console.WriteLine($" Reading student with ID {newStudent.Id}...");
    var fetchedStudent = await studentService.GetStudentByIdAsync(newStudent.Id);
    if (fetchedStudent != null)
    {
        Console.WriteLine($" Found: {fetchedStudent.FullName}, Admitted: {fetchedStudent.AdmissionDate:yyyy-MM-dd}");
        Console.WriteLine($"   Address: {fetchedStudent.Address.Street}, {fetchedStudent.Address.City}");
    }
    Console.WriteLine();

    // UPDATE
    Console.WriteLine($"  Updating student name...");
    var updated = await studentService.UpdateStudentNameAsync(newStudent.Id, "Layla", "Hassan");
    if (updated)
    {
        var updatedStudent = await studentService.GetStudentByIdAsync(newStudent.Id);
        Console.WriteLine($"  Student updated: {updatedStudent?.FullName}");
    }
    Console.WriteLine();

    // SOFT DELETE
    Console.WriteLine($"   Performing Soft Delete on student ID {newStudent.Id}...");
    var deleted = await studentService.SoftDeleteStudentAsync(newStudent.Id);
    if (deleted)
    {
        Console.WriteLine($"  Student soft deleted (IsDeleted = true)");

        var isDeleted = await studentService.IsStudentDeletedAsync(newStudent.Id);
        Console.WriteLine($"   Verification: IsDeleted status = {isDeleted}");

        var tryFetch = await studentService.GetStudentByIdAsync(newStudent.Id);
        string fetchResult = tryFetch == null ? "❌ Not found (filtered out)" : "Found";
        Console.WriteLine($"   Attempting to fetch deleted student: {fetchResult}");
    }
    Console.WriteLine();

    PrintSectionHeader(" COURSE QUERY SERVICE - LOADING STRATEGIES");

    // EAGER LOADING
    Console.WriteLine("Demonstrating EAGER LOADING with .Include() and .ThenInclude()...");
    var firstCourse = context.Courses.First();
    var courseWithData = await courseQueryService.GetCourseWithRelatedDataEagerLoadingAsync(firstCourse.Id);
    if (courseWithData != null)
    {
        Console.WriteLine($"   Course: {courseWithData.Title}");
        Console.WriteLine($"   Department: {courseWithData.Department?.Name ?? "N/A"}");
        Console.WriteLine($"   Instructor: {courseWithData.Instructor?.FullName ?? "N/A"}");
        Console.WriteLine($"   Instructor Office: {courseWithData.Instructor?.Office?.OfficeName ?? "N/A"}");
        Console.WriteLine($"   💡 Note: All data loaded in a SINGLE query with JOINs");
    }
    Console.WriteLine();

    // EXPLICIT LOADING
    Console.WriteLine("  Demonstrating EXPLICIT LOADING with .Entry().Collection().Load()...");
    var firstDept = context.Departments.First();
    var deptWithExplicit = await courseQueryService.GetDepartmentWithExplicitLoadingAsync(firstDept.Id);
    if (deptWithExplicit != null)
    {
        Console.WriteLine($"   Department: {deptWithExplicit.Name}");
        Console.WriteLine($"   Courses: {deptWithExplicit.Courses?.Count ?? 0} loaded");
        Console.WriteLine($"   Department Members: {deptWithExplicit.DepartmentMembers?.Count ?? 0} loaded");
        Console.WriteLine($"   Dean: {deptWithExplicit.Dean?.FullName ?? "N/A"}");
        Console.WriteLine($"   Note: Each collection loaded with SEPARATE queries (on-demand)");
    }
    Console.WriteLine();

    // PROJECTION
    Console.WriteLine("  Demonstrating PROJECTION LOADING with .Select()...");
    var coursesProjection = await courseQueryService.GetCoursesProjectionAsync();
    Console.WriteLine($"  Retrieved {coursesProjection.Count} courses with projection (specific columns only):");
    foreach (var course in coursesProjection.Take(5))
    {
        Console.WriteLine($"   • {course.CourseTitle} - {course.DepartmentName}");
        Console.WriteLine($"     Instructor: {course.InstructorFullName}, Students: {course.StudentCount}");
    }
    Console.WriteLine($"     Note: Only SELECT specific columns, no tracking, optimal performance");
    Console.WriteLine();

    // BONUS: Statistics
    Console.WriteLine("  Bonus - Course Statistics with Projection:");
    var stats = await courseQueryService.GetCourseStatisticsAsync(firstCourse.Id);
    if (stats != null)
    {
        var statsType = stats.GetType();
        Console.WriteLine($"   Course: {statsType.GetProperty("CourseTitle")?.GetValue(stats)}");
        Console.WriteLine($"   Enrolled: {statsType.GetProperty("EnrolledStudents")?.GetValue(stats)}");
        Console.WriteLine($"   Avg Grade: {statsType.GetProperty("AverageGrade")?.GetValue(stats):F2}");
        Console.WriteLine($"   Pass Rate: {statsType.GetProperty("PassRate")?.GetValue(stats):F2}%");
    }
    Console.WriteLine();

    PrintSectionHeader("3️⃣  REPORTING SERVICE - AGGREGATIONS & ANALYTICS");

    // Average Salary per Department
    Console.WriteLine("  Calculating Average Salary per Department (GroupBy + Average)...");
    var salaryReports = await reportingService.GetAverageSalaryPerDepartmentAsync();
    Console.WriteLine($" Salary Report for {salaryReports.Count} departments:");
    Console.WriteLine($"{"Department",-30} {"Avg Salary",-15} {"Instructors",-12} {"Budget",-15}");
    Console.WriteLine(new string('-', 72));
    foreach (var report in salaryReports)
    {
        Console.WriteLine($"{report.DepartmentName,-30} {report.AverageSalary,10:C} {report.InstructorCount,12} {report.TotalSalaryBudget,15:C}");
    }
    Console.WriteLine();

    // Top 3 Most Popular Courses
    Console.WriteLine(" Top 3 Most Popular Courses (by Student Enrollment)...");
    var popularCourses = await reportingService.GetTopPopularCoursesAsync(3);
    Console.WriteLine($" Top Popular Courses:");
    for (int i = 0; i < popularCourses.Count; i++)
    {
        var course = popularCourses[i];
        string medal = i == 0 ? "🥇" : i == 1 ? "🥈" : "🥉";
        Console.WriteLine($"{medal} #{i + 1}: {course.CourseTitle}");
        Console.WriteLine($"   Students Enrolled: {course.EnrolledStudents}");
        Console.WriteLine($"   Average Grade: {course.AverageGrade:F2}");
        Console.WriteLine($"   Instructor: {course.InstructorName}");
        Console.WriteLine($"   Department: {course.DepartmentName}");
        Console.WriteLine();
    }

    // Bonus: Student Performance
    Console.WriteLine(" Bonus - Student Performance Report (Top 5):");
    var studentPerformance = await reportingService.GetStudentPerformanceReportAsync();
    Console.WriteLine($"{"Student Name",-25} {"Total",-8} {"Passed",-8} {"Failed",-8} {"Avg Grade",-10}");
    Console.WriteLine(new string('-', 69));
    foreach (var student in studentPerformance.Take(5))
    {
        Console.WriteLine($"{student.StudentName,-25} {student.TotalCourses,-8} {student.PassedCourses,-8} {student.FailedCourses,-8} {student.AverageGrade,-10:F2}");
    }
    Console.WriteLine();

    // Bonus: Department Statistics
    Console.WriteLine("  Bonus - Department Statistics:");
    var deptStats = await reportingService.GetDepartmentStatisticsAsync();
    Console.WriteLine($"{"Department",-30} {"Courses",-10} {"Instructors",-12} {"Students",-10}");
    Console.WriteLine(new string('-', 62));
    foreach (var dept in deptStats)
    {
        Console.WriteLine($"{dept.DepartmentName,-30} {dept.TotalCourses,-10} {dept.TotalInstructors,-12} {dept.TotalStudentsEnrolled,-10}");
    }
    Console.WriteLine();

    PrintSectionHeader("  DEMO COMPLETED SUCCESSFULLY");
    Console.WriteLine("   Key Skills Demonstrated:");
    Console.WriteLine("   ✓ CRUD Operations with Soft Delete Pattern");
    Console.WriteLine("   ✓ Eager Loading (.Include, .ThenInclude)");
    Console.WriteLine("   ✓ Explicit Loading (.Entry().Collection().Load())");
    Console.WriteLine("   ✓ Projection Loading (.Select for performance)");
    Console.WriteLine("   ✓ Data Aggregation (GroupBy, Average, Count, Sum)");
    Console.WriteLine("   ✓ Complex LINQ Queries");
    Console.WriteLine("   ✓ SOLID Principles (Single Responsibility)");
    Console.WriteLine("   ✓ Clean Code Practices");
    Console.WriteLine();
}
catch (Exception ex)
{
    Console.WriteLine("  ERROR OCCURRED:");
    Console.WriteLine($"   {ex.Message}");
    Console.WriteLine($"   Stack Trace: {ex.StackTrace}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static void PrintSectionHeader(string title)
{
    Console.WriteLine("═".PadRight(75, '═'));
    Console.WriteLine($"  {title}");
    Console.WriteLine("═".PadRight(75, '═'));
    Console.WriteLine();
}