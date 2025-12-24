# ?? LMS Console Demo - EF Core 8 Skills Showcase

## ?? Overview
This demo showcases advanced Entity Framework Core 8 skills through a Learning Management System (LMS) implementation following SOLID principles and Clean Code practices.

## ??? Architecture

### Services (Single Responsibility Principle)

#### 1?? **StudentService.cs** - CRUD Operations
Demonstrates basic Entity Framework operations with soft delete pattern:
- **CreateStudentAsync**: Add new student to database
- **GetStudentByIdAsync**: Retrieve student with IsDeleted filter
- **UpdateStudentNameAsync**: Modify student information
- **SoftDeleteStudentAsync**: Implement soft delete (IsDeleted = true)
- **IsStudentDeletedAsync**: Verify deletion status using IgnoreQueryFilters()

**Key Concepts**:
- Soft Delete Pattern for data preservation
- DbContext SaveChangesAsync override for audit fields
- Query filters for automatic IsDeleted filtering

---

#### 2?? **CourseQueryService.cs** - Loading Strategies
Demonstrates three critical EF Core loading strategies:

##### ?? Eager Loading (GetCourseWithRelatedDataEagerLoadingAsync)
- Uses `.Include()` and `.ThenInclude()`
- Loads all related data in **1 SQL query** with JOINs
- **Best for**: When you know you'll need related data upfront
- **Pros**: Single query, no lazy loading issues
- **Cons**: Can load unnecessary data

##### ?? Explicit Loading (GetDepartmentWithExplicitLoadingAsync)
- Uses `context.Entry().Collection().Load()` and `.Reference().Load()`
- Loads related data on-demand with **multiple queries**
- **Best for**: Conditional or on-demand loading scenarios
- **Pros**: Fine-grained control, load only what you need
- **Cons**: Multiple database roundtrips

##### ?? Projection Loading (GetCoursesProjectionAsync)
- Uses `.Select()` to retrieve **specific columns only**
- Returns DTOs instead of tracked entities
- **Best for**: Performance-critical scenarios, reports, dashboards
- **Pros**: Optimal performance, minimal data transfer, no tracking overhead
- **Cons**: Returns DTOs (not entities), can't navigate properties

**Bonus**: GetCourseStatisticsAsync - Projection with calculated fields (Average, Count, PassRate)

---

#### 3?? **ReportingService.cs** - Aggregations & Analytics
Demonstrates complex LINQ queries and data aggregation:

##### ?? GetAverageSalaryPerDepartmentAsync
- **GroupBy**: Groups instructors by department
- **Aggregate Functions**: Average, Min, Max, Sum, Count
- Shows server-side aggregation (executed in SQL)
- Returns comprehensive salary metrics per department

##### ?? GetTopPopularCoursesAsync
- Complex query with multiple joins
- **GroupBy** on StudentCourses to count enrollments
- **OrderByDescending** + **Take** for Top N results
- Includes calculated fields (AverageGrade)

**Bonus Methods**:
- **GetStudentPerformanceReportAsync**: Conditional aggregation (Pass/Fail counts)
- **GetDepartmentStatisticsAsync**: Multi-level aggregation with Distinct

---

## ?? DTOs (Data Transfer Objects)

All services use DTOs for optimal data transfer:
- `CourseProjectionDto` - Course listing with minimal data
- `DepartmentSalaryReport` - Salary analytics
- `PopularCourseReport` - Course popularity metrics
- `StudentPerformanceReport` - Student grades summary
- `DepartmentStatisticsReport` - Department overview

---

## ?? Key Skills Demonstrated

### EF Core Proficiency
? Eager Loading (.Include, .ThenInclude)  
? Explicit Loading (.Entry().Collection().Load())  
? Projection Loading (.Select for performance)  
? Query Filters (IsDeleted automatic filtering)  
? IgnoreQueryFilters() for bypass  
? Complex LINQ Queries  
? Data Aggregation (GroupBy, Average, Count, Sum)  
? Self-Referencing Relationships (CoursePrerequisite)  
? Many-to-Many Relationships (StudentCourse)  
? Inheritance (TPH - Table Per Hierarchy)  

### Design Principles
? SOLID Principles (Single Responsibility)  
? Clean Code Practices  
? Async/Await Pattern  
? Null Safety Checks  
? Comprehensive Comments (Why, not What)  
? DTO Pattern for Data Transfer  

---

## ?? Running the Demo

```bash
dotnet run
```

### Expected Output
The console will display:
1. **Database Seeding** - Initializes test data
2. **Student CRUD** - Create, Read, Update, Soft Delete
3. **Loading Strategies** - Eager, Explicit, Projection examples
4. **Analytics Reports** - Salary analysis, popular courses, performance metrics

---

## ?? Code Quality Features

### Soft Delete Pattern
The `AppDbContext.SaveChangesAsync` override automatically:
- Sets `IsDeleted = true` instead of physically deleting
- Updates `LastModifiedOn` timestamp
- Preserves historical data and referential integrity

### Query Optimization
- Projections reduce data transfer
- Server-side aggregation (SQL execution)
- Minimal memory footprint
- No unnecessary object tracking

---

## ?? Entity Relationships

```
Department (1) ??? (N) Instructor
Department (1) ??? (N) Course
Instructor (1) ??? (N) Course
Instructor (1) ??? (1) Office
Course (N) ??? (M) Student (via StudentCourse)
Course (N) ??? (M) Course (via CoursePrerequisite - Self-Referencing)
```

---

## ?? Technologies Used
- **.NET 10**
- **Entity Framework Core 8**
- **SQL Server**
- **LINQ**
- **Async/Await**

---

## ????? Author Notes
This demo is designed to showcase professional-level EF Core knowledge for:
- Technical interviews
- Code reviews
- Portfolio demonstration
- Teaching/mentoring scenarios

All code follows industry best practices with clear, educational comments explaining the "why" behind each decision.
