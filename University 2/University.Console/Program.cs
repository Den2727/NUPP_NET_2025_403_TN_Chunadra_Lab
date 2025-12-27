using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var service = new CrudServiceAsync<Student>("students.json", s => s.Id);

        int count = 1000;

        await Task.WhenAll(
            Enumerable.Range(0, count)
                .Select(_ => Task.Run(() =>
                    service.CreateAsync(Student.CreateNew())))
        );

        var students = await service.ReadAllAsync();

        Console.WriteLine($"AGE: min={students.Min(s => s.Age)}, max={students.Max(s => s.Age)}, avg={students.Average(s => s.Age):F2}");
        Console.WriteLine($"GPA: min={students.Min(s => s.GPA)}, max={students.Max(s => s.GPA)}, avg={students.Average(s => s.GPA):F2}");

        await service.SaveAsync();
        Console.WriteLine("Saved to students.json");
    }
}
