using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_02_ImplicitConversionAndCasting
{
    public static class Program
    {
        private const string CURRENCY_FORMAT = "0.00";

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Faça um programa que pergunte ao usuário ano de nascimento e imprima sua idade.\n" +
                "2. Escreva um programa que leia 10 valores inteiros e ao final exiba a soma dos números.\n" +
                "3. Escreva um programa que leia o número de horas trabalhadas de um funcionário,\n" +
                    "o valor que recebe por hora e calcula o salário desse funcionário.\n" +
                    "A seguir, mostre o número e o salário do funcionário, com duas casas decimais.\n" +
                "4. Leia um valor inteiro correspondente à idade de uma pessoa e mostre-a em anos, meses e dias.\n" +
                "5. Construa um conversor de moedas. (DÓLAR, EURO, LIBRA ESTERLINA, DÓLAR CANADENSE, PESO ARGENTINO, PESO CHILENO)");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        AgeCalculator();
                        break;
                    case 2:
                        NumbersSum();
                        break;
                    case 3:
                        SalaryCalculator();
                        break;
                    case 4:
                        LifeTimeCalculator();
                        break;
                    case 5:
                        CurrencyConverter();
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

        public static void AgeCalculator()
        {
            Console.WriteLine("\nEnvie seu ano de nascimento");
            var birthYear = int.Parse(Console.ReadLine());

            var actualYear = DateTime.Now.Year;

            var calculatedAge = actualYear - birthYear;
            Console.WriteLine($"Idade prevista: {calculatedAge}");
        }

        public static void NumbersSum()
        {
            var numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Envie o n° {i + 1}:");
                int actualNumber = int.Parse(Console.ReadLine());
                numbers[i] = actualNumber;
            }

            Console.WriteLine($"Soma dos valores: {numbers.Sum()}");
        }

        public static void SalaryCalculator()
        {
            Console.WriteLine("Valor da hora de trabalho:");
            var valuePerHour = float.Parse(Console.ReadLine());

            Console.WriteLine("Horas trabalhadas:");
            var workedHours = float.Parse(Console.ReadLine());

            var salary = (valuePerHour * workedHours).ToString(CURRENCY_FORMAT);

            Console.WriteLine($"Salário previsto: R$ {salary}");
        }

        public static void LifeTimeCalculator()
        {
            const int DAYS_NUMBER_IN_YEAR = 365;
            const int MONTHS_NUMBER_IN_YEAR = 12;

            Console.WriteLine("Envie sua idade atual:");
            var age = int.Parse(Console.ReadLine());

            var ageInDays = DAYS_NUMBER_IN_YEAR * age;
            var ageInMonths = MONTHS_NUMBER_IN_YEAR * age;

            Console.WriteLine("\nSua idade aproximada:" +
                $"\nEm anos: {age}" +
                $"\nEm meses: {ageInMonths}" +
                $"\nEm dias: {ageInDays}");
        }

        public static void CurrencyConverter()
        {
            var currencyValues = new List<Currency>()
            {
                new Currency("Dólar", "US$", 0.21f),
                new Currency("Euro", "€", 0.19f),
                new Currency("Libra Esterlina","£", 0.16f),
                new Currency("Dólar Canadense", "C$", 3.89f),
                new Currency("Peso Argentino","$", 24.91f),
                new Currency("Peso Chileno", "CLP$", 169.56f)
            };

            Console.WriteLine("Entre com o valor em real:");
            var valueInBrCurrency = float.Parse(Console.ReadLine());

            foreach (var currency in currencyValues)
            {
                var converted = (valueInBrCurrency * currency.ValueInBRL).ToString(CURRENCY_FORMAT);

                Console.Out.WriteLine($"R${valueInBrCurrency.ToString(CURRENCY_FORMAT)} em {currency.Name}: " +
                    $"{converted}{currency.Symbol}");
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
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
