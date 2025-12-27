namespace University.Common.Models
{
    public class Student : Person
    {
        public string Group { get; set; }
        public double GPA { get; set; }

        public Student(string name, int age, string email, string group, double gpa)
            : base(name, age, email)
        {
            Group = group;
            GPA = gpa;
        }
    }
}
