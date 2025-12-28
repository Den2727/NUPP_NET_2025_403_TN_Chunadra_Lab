namespace University.Infrastructure.Models;

public abstract class PersonModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
}
