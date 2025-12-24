using LMS.Context;
using LMS.Entities;
using LMS.Enums;

namespace LMS.DataSeed
{
    internal static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Departments.Any()) return;

            var random = new Random();

            string[] maleNames = { "Ahmed", "Mohamed", "Mahmoud", "Omar", "Youssef", "Khaled", "Amr", "Hassan", "Ali", "Mostafa", "Ibrahim", "Tarek", "Karim", "Ziad", "Sherif" };
            string[] femaleNames = { "Sara", "Nour", "Mona", "Salma", "Dina", "Heba", "Aya", "Fatma", "Mariam", "Yara", "Mai", "Rana", "Esraa", "Hadeer", "Sohaila" };
            string[] lastNames = { "El-Sayed", "Hassan", "Ali", "Ibrahim", "Mohamed", "Kamel", "Samir", "Fawzy", "Radwan", "Osman", "Salem", "Helmy", "Nasser", "Mansour", "Amer" };

            var addresses = new List<Address>
            {
                new Address { Street = "90th Street", City = "New Cairo", Country = "Egypt" },
                new Address { Street = "Makram Ebeid", City = "Nasr City", Country = "Egypt" },
                new Address { Street = "Tahrir Street", City = "Dokki", Country = "Egypt" },
                new Address { Street = "El-Merghany", City = "Heliopolis", Country = "Egypt" },
                new Address { Street = "Sea Road", City = "Alexandria", Country = "Egypt" }
            };

            string[] csCourses = {
                "Introduction to Programming", "Data Structures", "Algorithms Analysis",
                "Database Management Systems", "Operating Systems", "Computer Networks",
                "Software Engineering", "Artificial Intelligence", "Web Development",
                "Mobile App Development", "Cyber Security Basics", "Cloud Computing",
                "Machine Learning", "Computer Vision", "Discrete Mathematics"
            };

            var departments = new List<Department>();
            string[] deptNames = { "Computer Science", "Information Systems", "Artificial Intelligence", "Software Engineering", "Cyber Security" };

            foreach (var name in deptNames)
            {
                departments.Add(new Department { Name = name });
            }
            context.Departments.AddRange(departments);
            context.SaveChanges();

            var offices = new List<Office>();
            for (int i = 1; i <= 5; i++)
            {
                offices.Add(new Office { OfficeName = $"Room {100 + i}-C", Building = "Main Building" });
            }
            context.Offices.AddRange(offices);
            context.SaveChanges();

            var loadedDepartments = context.Departments.ToList();
            var loadedOffices = context.Offices.ToList();

            var instructors = new List<Instructor>();
            for (int i = 0; i < 15; i++)
            {
                bool isMale = random.Next(2) == 0;
                string fName = isMale ? maleNames[random.Next(maleNames.Length)] : femaleNames[random.Next(femaleNames.Length)];
                string lName = lastNames[random.Next(lastNames.Length)];

                var instructor = new Instructor
                {
                    FirstName = fName,
                    LastName = lName,
                    Email = $"{fName.ToLower()}.{lName.ToLower()}{i}@university.edu.eg",
                    Salary = random.Next(15000, 45000),
                    HireDate = DateTime.Now.AddYears(-random.Next(2, 15)),
                    DepartmentId = loadedDepartments[random.Next(loadedDepartments.Count)].Id,
                    Office = i < 5 ? loadedOffices[i] : null,
                    Address = new Address
                    {
                        Street = addresses[random.Next(addresses.Count)].Street,
                        City = addresses[random.Next(addresses.Count)].City,
                        Country = addresses[random.Next(addresses.Count)].Country,
                        State = ""
                    }
                };
                instructors.Add(instructor);
            }
            context.Staff.AddRange(instructors);
            context.SaveChanges();

            foreach (var dept in loadedDepartments)
            {
                var deptInstructors = context.Staff.OfType<Instructor>()
                                             .Where(i => i.DepartmentId == dept.Id)
                                             .ToList();

                if (deptInstructors.Any())
                {
                    var randomDean = deptInstructors[random.Next(deptInstructors.Count)];
                    dept.DeanId = randomDean.Id;
                }
            }
            context.SaveChanges();
            var tas = new List<TeachingAssistant>();
            for (int i = 0; i < 15; i++)
            {
                bool isMale = random.Next(2) == 0;
                string fName = isMale ? maleNames[random.Next(maleNames.Length)] : femaleNames[random.Next(femaleNames.Length)];
                string lName = lastNames[random.Next(lastNames.Length)];

                tas.Add(new TeachingAssistant
                {
                    FirstName = fName,
                    LastName = lName,
                    Email = $"{fName.ToLower()}.{lName.ToLower()}.ta{i}@university.edu.eg",
                    Salary = random.Next(5000, 12000),
                    HireDate = DateTime.Now.AddMonths(-random.Next(1, 36)),
                    DepartmentId = loadedDepartments[random.Next(loadedDepartments.Count)].Id,
                    Address = new Address
                    {
                        Street = addresses[random.Next(addresses.Count)].Street,
                        City = addresses[random.Next(addresses.Count)].City,
                        Country = addresses[random.Next(addresses.Count)].Country,
                        State = ""
                    }
                });
            }
            context.Staff.AddRange(tas);
            context.SaveChanges();

            var courses = new List<Course>();
            var loadedInstructors = context.Staff.OfType<Instructor>().ToList();

            foreach (var title in csCourses)
            {
                courses.Add(new Course
                {
                    Title = title,
                    InstructorId = loadedInstructors[random.Next(loadedInstructors.Count)].Id,
                    DepartmentId = loadedDepartments[random.Next(loadedDepartments.Count)].Id,
                    CourseStatus = CourseStatus.Published,
                    Hours = random.Next(2, 3),
                    Description = $"Advanced course covering {title}."
                });
            }
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var loadedCourses = context.Courses.ToList();
            var basicCourses = loadedCourses.Take(5).ToList();
            var advancedCourses = loadedCourses.Skip(5).ToList();

            foreach (var advCourse in advancedCourses)
            {
                var randomPrereqs = basicCourses
                                    .OrderBy(x => random.Next())
                                    .Take(random.Next(1, 4))
                                    .ToList();

                foreach (var pre in randomPrereqs)
                {
                    context.Set<CoursePrerequisite>().Add(new CoursePrerequisite
                    {
                        CourseId = advCourse.Id,
                        PrerequisiteId = pre.Id
                    });
                }
            }
            context.SaveChanges();

            var sections = new List<Section>();
            var loadedTAs = context.Staff.OfType<TeachingAssistant>().ToList();

            for (int i = 1; i <= 20; i++)
            {
                var course = loadedCourses[random.Next(loadedCourses.Count)];
                sections.Add(new Section
                {
                    Title = $"Sec {i} - {course.Title.Substring(0, Math.Min(10, course.Title.Length))}",
                    CourseId = course.Id,
                    TeachingAssistantId = loadedTAs[random.Next(loadedTAs.Count)].Id,
                    Description = $"Lab session on {i % 5 + 1} PM"
                });
            }
            context.Sections.AddRange(sections);
            context.SaveChanges();

            var students = new List<Student>();
            for (int i = 0; i < 20; i++)
            {
                bool isMale = random.Next(2) == 0;
                string fName = isMale ? maleNames[random.Next(maleNames.Length)] : femaleNames[random.Next(femaleNames.Length)];
                string lName = lastNames[random.Next(lastNames.Length)];
                var randAddr = addresses[random.Next(addresses.Count)];

                students.Add(new Student
                {
                    FirstName = fName,
                    LastName = lName,
                    Address = new Address { Street = randAddr.Street, City = randAddr.City, Country = randAddr.Country, State = "" },
                    AdmissionDate = DateTime.Now.AddYears(-random.Next(1, 5))
                });
            }
            context.Students.AddRange(students);
            context.SaveChanges();

            var loadedSections = context.Sections.ToList();
            var loadedStudents = context.Students.ToList();

            foreach (var student in loadedStudents)
            {
                int coursesToTake = random.Next(3, 7);
                var studentSections = loadedSections
                                      .OrderBy(x => random.Next())
                                      .DistinctBy(s => s.CourseId)
                                      .Take(coursesToTake)
                                      .ToList();

                foreach (var section in studentSections)
                {
                    context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = student.Id,
                        SectionId = section.Id,
                        CourseId = section.CourseId,
                        Grade = random.Next(60, 100)
                    });
                }
            }
            context.SaveChanges();
        }
    }
}