using System;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    protected static Random rand = new();

    public static Person CreateNew() =>
        new Person
        {
            Id = Guid.NewGuid(),
            Name = $"Person_{rand.Next(1000)}",
            Age = rand.Next(18, 80)
        };
}
