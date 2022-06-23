using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_06_OOP.SalaryManagement
{
    public class Management
    {
        public IList<Employee> Employees;

        public Management()
        {
            Employees = new List<Employee>();
        }

        public static void Start()
        {
            var instance = new Management();

            instance.InsertEmployee();

            var shouldExecute = true;

            do
            {
                Console.WriteLine("O que deseja fazer?\n" +
                    "1. Atualizar salário\n" +
                    "2. Verificar salário\n" +
                    "3. Incluir novo funcionário\n" +
                    "4. Sair\n");

                if (int.TryParse(Console.ReadLine(), out int selectedOption) && selectedOption is >= 1 and <= 4)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            instance.UpdateEmployeeSalary();
                            break;
                        case 2:
                            instance.ShowEmployeeSalary();
                            break;
                        case 3:
                            instance.InsertEmployee();
                            break;
                        case 4:
                            break;
                    }

                    Console.WriteLine("Deseja realizar outra operação? S/N");
                    var chosenOption = char.ToUpper(Console.ReadLine()[0]);

                    shouldExecute = chosenOption is 'S';
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }

            } while (shouldExecute);
        }

        public void InsertEmployee()
        {
            Console.WriteLine("Entre com o ID do(a) funcionário(a)");
            var employeeId = int.Parse(Console.ReadLine());

            if (!IsExistentId(employeeId))
            {
                Console.WriteLine("Entre com o nome do(a) funcionário(a)");
                var employeeName = Console.ReadLine();

                Console.WriteLine("Entre com o cargo do(a) funcionário(a)");
                var employeeRule = Console.ReadLine();

                Console.WriteLine("Informar salário? S/N");
                var chosenOption = char.ToUpper(Console.ReadLine()[0]);

                if (chosenOption is 'S')
                {
                    Console.WriteLine("Entre com o salário do(a) funcionário(a)");
                    var employeeSalary = float.Parse(Console.ReadLine());

                    Employees.Add(new Employee(employeeId, employeeName, employeeRule, employeeSalary));
                }
                else
                {
                    Employees.Add(new Employee(employeeId, employeeName, employeeRule));
                }
            }
            else
            {
                Console.WriteLine("ID já existente. Informe outro.");
            }
        }

        public void ShowEmployeeSalary()
        {
            Console.WriteLine("Informe o ID do funcionário: ");
            var id = int.Parse(Console.ReadLine());

            var result = Employees.FirstOrDefault(e => e.Id == id);

            if (result is not null)
            {
                Console.WriteLine($"Salário do(a) funcionário(a): {result.Name}: {result.Salary:0.00}");
            }
            else{
                Console.WriteLine("Funcionário(a) não encontrado(a)");
            }
        }

        public void UpdateEmployeeSalary()
        {
            Console.WriteLine("Informe o ID do funcionário: ");
            var id = int.Parse(Console.ReadLine());

            var employee = Employees.First(e => e.Id == id);

            if (employee is not null)
            {
                employee.UpdateSalary(CalculateSalaryIncrease(employee.Salary));
                Console.WriteLine($"Salário do(a) funcionário(a): {employee.Name} atualizado");
            }
            else
            {
                Console.WriteLine("Funcionário(a) não encontrado(a)");
            }
        }

        public static float CalculateSalaryIncrease(float salary)
        {
            const float MINIMUM_INCREASE_PERCENTAGE = 4f;

            if (salary <= 400.00)
            {
                return 15f;
            }
            else if (salary >= 400.01 && salary <= 800.00)
            {
                return 12f;
            }
            else if (salary >= 800.01 && salary <= 1200.00)
            {
                return 10f;
            }
            else if (salary >= 1200.01 && salary <= 2000.00)
            {
                return 7f;
            }

            return MINIMUM_INCREASE_PERCENTAGE;
        }

        public bool IsExistentId(int id)
        {
            var result = Employees.FirstOrDefault(e => e.Id == id);
            return result is not null;
        }
    }
}
