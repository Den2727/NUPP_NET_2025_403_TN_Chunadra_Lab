namespace University.Infrastructure.Models;

public class StudentModel : PersonModel
{
    public int Course { get; set; }

    public Guid GroupId { get; set; }
    public GroupModel Group { get; set; } = null!;
}
