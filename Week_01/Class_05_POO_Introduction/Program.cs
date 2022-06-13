using Class_05_POOIntroduction.StudentSystem;
using System;
using System.Threading;

namespace Class_05_POOIntroduction
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Escreva uma classe cujos objetos representam alunos matriculados em uma disciplina. " +
                "\nCada objeto dessa classe deve guardar os seguintes dados do aluno: matrícula, nome, 2 notas de prova e 1 nota de trabalho." +
                "\nMétodos: " +
                "\n- Calcular média: calcula e exibe a média final do aluno com base em suas notas;" +
                "\n- Calculo nota final: calcula quanto o aluno precisa tirar na prova final para ser aprovado.\n\n" +

                "2. Escreva uma classe em que cada objeto representa um vôo que acontece em determinada data e em determinado horário. " +
                "\nCada vôo possui no máximo 100 passageiros, e a classe permite controlar a ocupação das vagas." +
                "\nMétodos: " +
                "\n- Ocupar Vaga: ocupa determinada cadeira do vôo, cujo número é recebido como parâmetro, e retorna verdadeiro se a cadeira ainda não estiver ocupada (operação foi bem sucedida) e falso caso contrário" +
                "\n- Vagas Livres: retorna o número de cadeiras vagas disponíveis (não ocupadas) no vôo;" +
                "\n- Cadeira Livre: Retorna o número da próxima cadeira livre;" +
                "\n- Ocupa: ocupa determinada cadeira do vôo, cujo número é recebido como parâmetro. Caso a cadeira esteja ocupada exibe uma mensagem, caso esteja vazia, reserva e exibe uma mensagem de confirmação;" +
                "\n- Ver horário: Imprime a data e o horário do vôo.\n\n" +

                "3. Crie uma classe Calculadora, que possui como métodos a multiplicação, divisão, subtração e soma de dois valores e exibe para o usuário.\n\n");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        StudentSystem(2, 1, 70);
                        break;
                    case 2:
                        FlightSystem.FlightSystem.Start();
                        break;
                    case 3:
                        TwoNumberCalculator();
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

        public static void StudentSystem(int examsAmount, int workAmount, int minimumAverage)
        {
            Console.WriteLine("Entre com o nome do(a) aluno(a)");
            var studentName = Console.ReadLine();

            Console.WriteLine("Entre com a matrícula do(a) aluno(a)");
            var studentRegistration = Console.ReadLine();

            var student = new Student(studentRegistration, studentName);

            for (int i = 0; i < workAmount; i++)
            {
                Console.WriteLine($"Insira a nota do trabalho {i + 1}:");
                student.Grades.Add(float.Parse(Console.ReadLine()));
            }

            for (int x = 0; x < examsAmount; x++)
            {
                Console.WriteLine($"Insira a nota da prova {x + 1}:");
                student.Grades.Add(float.Parse(Console.ReadLine()));
            }

            var shouldExecute = true;

            do
            {
                Console.WriteLine("O que deseja fazer?\n" +
                    "1. Calular média\n" +
                    "2. Calcular nota final");

                if (int.TryParse(Console.ReadLine(), out int selectedOption) && selectedOption is 1 or 2)
                {
                    if (selectedOption.Equals(1))
                    {
                        Console.WriteLine($"Média do(a) aluno(a): {Student.CurrentAverage(student.Grades)}");
                    }
                    else
                    {
                        var currentAverage = Student.CurrentAverage(student.Grades);
                        Console.WriteLine($"O(a) aluno(a) precisa de {(int)(minimumAverage - currentAverage)} ponto(s) para ser aprovado(a)");
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

        public static void TwoNumberCalculator()
        {
            Console.WriteLine("Escolha a operação desejada:\n1. Soma\n2. Subtração\n3. Multiplicação\n4. Divisão");
            if (int.TryParse(Console.ReadLine(), out int operation) && operation is >= 1 and <= 4)
            {
                Console.WriteLine("Primeiro número:");
                var firstNumber = float.Parse(Console.ReadLine());

                Console.WriteLine("Segundo número:");
                var secondNumber = float.Parse(Console.ReadLine());
                var result = 0f;

                switch (operation)
                {
                    case 1:
                        result = Calculator.Calculator.Sum(firstNumber, secondNumber);
                        break;
                    case 2:
                        result = Calculator.Calculator.Subtract(firstNumber, secondNumber);
                        break;
                    case 3:
                        result = Calculator.Calculator.Multiply(firstNumber, secondNumber);
                        break;
                    case 4:
                        result = Calculator.Calculator.Divide(firstNumber, secondNumber);
                        break;
                }

                Console.WriteLine($"Resultado: {result}");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
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
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
