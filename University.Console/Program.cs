using University.Infrastructure;
using University.Infrastructure.Models;
using University.Infrastructure.Repositories;

class Program
{
    static async Task Main()
    {
        using var context = new UniversityContext();

        var studentRepo = new Repository<StudentModel>(context);
        var teacherRepo = new Repository<TeacherModel>(context);
        var groupRepo = new Repository<GroupModel>(context);

        var group = new GroupModel { Name = "CS-101" };
        await groupRepo.AddAsync(group);
        await groupRepo.SaveAsync();

        var student1 = new StudentModel { FullName = "Ivan Ivanov", Course = 1, GroupId = group.Id };
        var student2 = new StudentModel { FullName = "Olena Petrenko", Course = 2, GroupId = group.Id };

        await studentRepo.AddAsync(student1);
        await studentRepo.AddAsync(student2);
        await studentRepo.SaveAsync();

        var teacher = new TeacherModel { FullName = "Dr. Smith", Subject = "Math" };
        await teacherRepo.AddAsync(teacher);
        await teacherRepo.SaveAsync();

        var students = await studentRepo.GetAllAsync();
        Console.WriteLine("Students:");
        foreach (var s in students)
        {
            Console.WriteLine($"{s.FullName} | Course: {s.Course} | Group: {group.Name}");
        }

        var teachers = await teacherRepo.GetAllAsync();
        Console.WriteLine("\nTeachers:");
        foreach (var t in teachers)
        {
            Console.WriteLine($"{t.FullName} | Subject: {t.Subject}");
        }
    }
}
