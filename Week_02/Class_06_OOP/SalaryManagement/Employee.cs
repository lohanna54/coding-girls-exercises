namespace Class_06_OOP.SalaryManagement
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }

        public float Salary { get; set; }

        public Employee(int id, string name, string role, float salary)
        {
            Id = id;
            Name = name;
            Role = role;
            Salary = salary;
        }

        public Employee(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
            Salary = 0f;
        }

        public void UpdateSalary(float percentual)
        {
            Salary += (Salary * percentual / 100f);
        }
    }
}
