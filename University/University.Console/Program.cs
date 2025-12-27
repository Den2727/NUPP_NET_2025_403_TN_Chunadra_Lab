using System;
using University.Common.Models;
using University.Common.Services;
using University.Common.Extensions;

class Program
{
    static void Main()
    {
        var studentService = new CrudService<Student>();
        var teacherService = new CrudService<Teacher>();

        UniversityNotifier.OnEvent += msg => Console.WriteLine($"EVENT: {msg}");

        var teacher = new Teacher(
            name: "Dr. Smith",
            age: 45,
            email: "smith@uni.edu",
            department: "Computer Science",
            experienceYears: 20
        );

        var student = new Student(
            name: "Alice",
            age: 20,
            email: "alice@student.uni.edu",
            group: "CS-101",
            gpa: 4.5
        );

        teacherService.Create(teacher);
        studentService.Create(student);

        Console.WriteLine("=== Students ===");
        foreach (var s in studentService.ReadAll())
        {
            Console.WriteLine($"Name: {s.Name}, Age: {s.Age}, Adult: {s.IsAdult()}, GPA: {s.GPA}");
        }

        Console.WriteLine("\n=== Teachers ===");
        foreach (var t in teacherService.ReadAll())
        {
            Console.WriteLine($"Name: {t.Name}, Department: {t.Department}, Experience: {t.ExperienceYears} years");
        }

        UniversityNotifier.Notify("University data loaded successfully");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

