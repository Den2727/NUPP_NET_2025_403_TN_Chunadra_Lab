namespace University.Common.Models
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Teacher Instructor { get; set; }

        // конструктор
        public Course(string title, int credits, Teacher instructor)
        {
            Title = title;
            Credits = credits;
            Instructor = instructor;
        }
    }
}
