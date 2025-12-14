using LMS.Context;

AppDbContext appDbContext = new AppDbContext();

appDbContext.Students.AddRange(
                new LMS.Entities.Student { FirstName = "Osama", LastName = "Saeed", AdmissionDate = DateTime.Now },
                new LMS.Entities.Student { FirstName = "Ahmed", LastName = "Ali", AdmissionDate = DateTime.Now },
                new LMS.Entities.Student { FirstName = "Mahmoud", LastName = "Hassan", AdmissionDate = DateTime.Now }
    );

appDbContext.Instructors.AddRange(
    new LMS.Entities.Instructor
    {
        FullName = "Dr. John Smith",
        Email = "john.smith@example.com",
        Salary = 75000m
    },
    new LMS.Entities.Instructor
    {
        FullName = "Prof. Jane Doe",
        Email = "Jame.Doe@gmail.com",
        Salary = 82000m
    },
    new LMS.Entities.Instructor
    {
        FullName = "Dr. Emily Johnson",
        Email = "Emily.Johnson@gmail.com",
        Salary = 90000m
    }
);

appDbContext.Courses.AddRange(
    new LMS.Entities.Course
    {
        Title = "Introduction to Programming",
        Description = "Learn the basics of programming using Python.",
        Price = 199.99
    },
    new LMS.Entities.Course
    {
        Title = "Web Development Bootcamp",
        Description = "Become a full-stack web developer with HTML, CSS, JavaScript, and more.",
        Price = 299.99
    },
    new LMS.Entities.Course
    {
        Title = "Data Science Fundamentals",
        Description = "Explore data analysis, visualization, and machine learning techniques.",
        Price = 399.99
    }
);

appDbContext.SaveChanges();