namespace University.Infrastructure.Models;

public class GroupModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<StudentModel> Students { get; set; }
        = new List<StudentModel>();
}
