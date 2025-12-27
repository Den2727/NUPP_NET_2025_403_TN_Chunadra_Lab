using University.Common.Models;

namespace University.Common.Extensions
{
    public static class PersonExtensions
    {
        public static bool IsAdult(this Person person)
        {
            return person.Age >= 18;
        }
    }
}
