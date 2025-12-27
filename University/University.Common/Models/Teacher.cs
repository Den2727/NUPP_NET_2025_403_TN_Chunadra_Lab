namespace University.Common.Models
{
    public class Teacher : Person
    {
        public string Department { get; set; }
        public int ExperienceYears { get; set; }

        public Teacher(string name, int age, string email, string department, int experience)
            : base(name, age, email)
        {
            Department = department;
            ExperienceYears = experience;
        }
    }
}
