public class Student : Person
{
    public string Group { get; set; }
    public double GPA { get; set; }

    public static new Student CreateNew()
    {
        var p = Person.CreateNew();
        return new Student
        {
            Id = p.Id,
            Name = p.Name,
            Age = p.Age,
            Group = $"Group-{rand.Next(1, 5)}",
            GPA = Math.Round(rand.NextDouble() * 4, 2)
        };
    }
}
