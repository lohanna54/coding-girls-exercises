using System;
using System.Linq;

namespace Class_06_OOP.Extensions
{
    public static class StringExtensions
    {
        public static void Start()
        {
            var shouldExecute = true;

            do
            {
                Console.WriteLine("O que deseja fazer?\n" +
                    "1. Abreviar nome\n" +
                    "2. Inverter palavra\n" +
                    "3. Contador de vogais e consoantes");

                if (int.TryParse(Console.ReadLine(), out int selectedOption) && selectedOption is >= 1 and <= 3)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            NameAbbreviation();
                            break;
                        case 2:
                            WordInverter();
                            break;
                        case 3:
                            ConsonantAndVowelCounter();
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

        private static void NameAbbreviation()
        {
            Console.WriteLine("Informe seu nome completo");
            var fullName = Console.ReadLine();

            var fullNameSplitted = fullName.Split(" ");

            var abbreviatedName = "";

            foreach (var word in fullNameSplitted)
            {
                abbreviatedName += word.Length > 2 ? $"{char.ToUpper(word[0])}. " : word;
            }

            Console.WriteLine($"Abreviado: {abbreviatedName}");
        }

        private static void WordInverter()
        {
            Console.WriteLine("Informe uma palavra:");
            var word = Console.ReadLine();

            var wordLetters = word.ToCharArray();
            Array.Reverse(wordLetters);

            var invertedWord = new string(wordLetters);

            Console.WriteLine($"Inverso de {word}: {invertedWord}");
        }

        private static void ConsonantAndVowelCounter()
        {
            Console.WriteLine("Informe uma palavra:");
            var word = Console.ReadLine().ToUpper();

            var vowelCount = word.Count(x => (x == 'A') || (x == 'E') || (x == 'I') || (x == 'O') || (x == 'U'));

            var consonantCount = word.Length - vowelCount;

            Console.WriteLine($"Palavra: {word}\nVogais: {vowelCount}\nConsoantes: {consonantCount}");
        }
    }
}
