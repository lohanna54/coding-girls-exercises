using System.Collections.Generic;
using System.Linq;

namespace Class_05_POOIntroduction.StudentSystem
{
    public class Student
    {
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public IList<float> Grades { get; set; }

        public Student(string registrationId, string name)
        {
            RegistrationId = registrationId;
            Name = name;
            Grades = new List<float>();
        }

        public static float CurrentAverage(IList<float> grades)
        {
            return grades.Sum() / grades.Count;
        }
    }
}
