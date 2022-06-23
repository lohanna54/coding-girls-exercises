using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_03_ComparisonOperators
{
    public static class Program
    {
        public const string CURRENCY_FORMAT = "0.00";

        public static void Main()
        {
            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Leia um valor de ponto flutuante com duas casas decimais. Este valor representa um valor monetário." +
                "\nA seguir, calcule o menor número de notas e moedas possíveis no qual o valor pode ser decomposto." +
                "\nAs notas consideradas são de 100, 50, 20, 10, 5, 2.\n\n" +

                "2. Faça um programa que leia três valores e apresente o maior dos três valores lidos seguido da mensagem 'x é o maior'.\n\n" +

                "3. Leia 3 valores que são as três notas de um aluno. A seguir, calcule a média do aluno." +
                "\nConsidere que cada nota pode ir de 0 até 10.0, sempre com uma casa decimal." +
                "\nImprima se o aluno foi aprovado ou reprovado considerando a média 7.\n\n" +

                "4. Leia 3 valores que são as três notas de um aluno. A seguir, calcule a média do aluno." +
                "\nRegras: " +
                "\n- Se a nota for menor que 6.0, deve exibir a nota F." +
                "\n- Se a nota for de 6.0 até 7.0, deve exibir a nota D." +
                "\n- Se a nota for entre 7.0 e 8.0, deve exibir a nota C." +
                "\n- Se a nota for entre 8.0 e 9.0, deve exibir a nota B." +
                "\n- Se a nota fot entre 9.0 e 10.0, deve exibir a nota A.\n\n" +

                "5. Leia o salário do funcionário e calcule e mostre o novo salário, bem como o valor de reajuste ganho e o índice reajustado, em percentual." +
                "\nRegras: " +
                "\n- Salário de 0 até 400.00 ganha 15% " +
                "\n- Salário de 400.01 até 800.00 ganha 12%" +
                "\n- Salário de 800.01 até 1200.00 ganha 10%" +
                "\n- Salário de 1200.01 até 2000.00 ganha 7%" +
                "\n- Acima de 2000.00 ganha 4%");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        CalculateBanknotes();
                        break;
                    case 2:
                        CalculateHigherValueBetweenThreeNumbers();
                        break;
                    case 3:
                        GetStudentStatusByAverageGrade();
                        break;
                    case 4:
                        GetGradeByStudentAverageGrade();
                        break;
                    case 5:
                        CalculateSalaryIncrease();
                        break;
                    default:
                        Console.WriteLine("Por favor, envie uma das opções:\n");
                        Main();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Por favor, envie somente números:\n");
                Main();
            }

            AskToExecuteAgain();
        }

        public static void CalculateBanknotes()
        {
            Console.WriteLine("Envie o valor desejado");
            var informedMoney = float.Parse(Console.ReadLine());

            var banknotes = new float[6] { 100, 50, 20, 10, 5, 2 };

            foreach (var value in banknotes)
            {
                var actualValue = (int)informedMoney / value;
                Console.Write($"{(int)actualValue} nota(s) de R$ {value.ToString(CURRENCY_FORMAT)}. ");
                informedMoney %= value;
            }
        }

        public static void CalculateHigherValueBetweenThreeNumbers()
        {
            Console.WriteLine("Entre com 3 números separados por espaço");
            var numbers = Console.ReadLine();

            var splittedNumbers = numbers.Split(" ");

            Console.WriteLine($"{splittedNumbers.Max()} é o maior");
        }

        public static void GetStudentStatusByAverageGrade()
        {
            var averageGrade = CalculateAverageGrade();

            var statusByAverageGrade = averageGrade >= 7 ? "aprovado" : "reprovado";

            Console.WriteLine($"O aluno tirou {averageGrade} e foi {statusByAverageGrade}.");
        }

        public static void GetGradeByStudentAverageGrade()
        {
            var averageGrade = CalculateAverageGrade();

            var averageReferenceGrades = new Dictionary<float, List<string>>
            {
                { 9.00f, new List<string> {"A", "Parabéns!" } },
                { 8.00f, new List<string> {"B", "Muito bom!" } },
                { 7.00f, new List<string> {"C", "OK!" } },
                { 6.00f, new List<string> {"D", "Poxa :(" } }
            };

            var finalGradeByAverage = "F";
            var finalGradeMessage = "Que pena!";

            foreach (var averageReferenceGrade in averageReferenceGrades)
            {
                if (averageGrade >= averageReferenceGrade.Key)
                {
                    finalGradeByAverage = averageReferenceGrade.Value[0];
                    finalGradeMessage = averageReferenceGrade.Value[1];
                    break;
                }
            }

            Console.WriteLine($"O aluno tirou {finalGradeByAverage}. {finalGradeMessage}");
        }

        public static void CalculateSalaryIncrease()
        {
            const float MINIMUM_INCREASE_PERCENTAGE = 4f;

            Console.WriteLine("Informe o salário atual");
            var salary = float.Parse(Console.ReadLine());

            float percentageIncrease = MINIMUM_INCREASE_PERCENTAGE;

            if (salary <= 400.00)
            {
                percentageIncrease = 15f;
            }
            else if (salary >= 400.01 && salary <= 800.00)
            {
                percentageIncrease = 12f;
            }
            else if (salary >= 800.01 && salary <= 1200.00)
            {
                percentageIncrease = 10f;
            }
            else if (salary >= 1200.01 && salary <= 2000.00)
            {
                percentageIncrease = 7f;
            }
        
            var valueToIncrease = salary * percentageIncrease / 100f;
            var adjustedSalary = salary + valueToIncrease;

            Console.WriteLine($"Novo salário: {adjustedSalary.ToString(CURRENCY_FORMAT)} " +
                $"Reajuste ganho: {valueToIncrease.ToString(CURRENCY_FORMAT)} " +
                $"Em percentual: {percentageIncrease}%");
        }

        public static float CalculateAverageGrade()
        {
            Console.WriteLine("Entre as 3 notas do aluno separadas por espaço");
            var studentGrades = Console.ReadLine();

            var splittedstudentGrades = studentGrades.Split(" ");

            var converterdGrades = splittedstudentGrades.Select(float.Parse);

            return converterdGrades.Sum() / converterdGrades.Count();
        }

        public static void AskToExecuteAgain()
        {
            Console.WriteLine("\nExecutar novamente? Digite S para continuar e qualquer tecla para SAIR");
            var executeAgain = Console.ReadLine();

            if (string.Equals(executeAgain, "s", StringComparison.OrdinalIgnoreCase))
            {
                Main();
            }
            else
            {
                Console.WriteLine("Finalizando...");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
