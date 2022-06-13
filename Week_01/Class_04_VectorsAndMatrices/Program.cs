using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Class_04_VectorsAndMatrices
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Crie um programa que solicite a entrada de 10 números pelo usuário, armazenando-os em um vetor, " +
                "e então monte outro vetor com os valores do primeiro multiplicados por 5.\n\n" +

                "2. Crie um programa que armazene 10 números digitados pelo usuário em dois vetores: um somente para números pares, e outro somente para números ímpares. " +
                "\nApós, exiba os valores dos dois vetores na tela, um vetor em cada linha.\n\n" +

                "3. Crie um programa que lê 5 palavras e as ordena em um vetor de strings pelo seu tamanho. " +
                "\nSe o tamanho das strings for igual, deve-se manter a ordem inserida pelo usuário.\n\n" +

                "4. Jogo Jokenpô" +
                "\nRegras: " +
                "\n- Permitir que eu decida quantas rodadas iremos fazer." +
                "\n- Ler a minha escolha (Pedra, papel ou tesoura)." +
                "\n- Decidir de forma aleatória a decisão do computador." +
                "\n- Mostrar quantas rodadas cada jogador ganhou." +
                "\n- Determinar quem foi o grande campeão de acordo com a quantidade de vitórias de cada um (computador e jogador)" +
                "\n- Perguntar se o Jogador quer jogar novamente, se sim inicie volte a escolha de quantidade de rodadas, se não finalize o programa. \n\n" +

                "5. Jogo da Velha" +
                "\nRegras: " +
                "\n- O tabuleiro é uma matriz de três linhas e três colunas." +
                "\n- Dois jogadores escolhem uma marcação cada um, geralmente um círculo (O) e um xis (X)." +
                "\n- Os jogadores jogam alternadamente, uma marcação por vez, numa célula que esteja vazia." +
                "\n- O objetivo é conseguir três círculos ou três xis em linha, quer horizontal, vertical ou diagonal , e ao mesmo tempo, quando possível, impedir o adversário de ganhar na próxima jogada.");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        MultiplyNumbers(5);
                        break;
                    case 2:
                        SeparateEvenAndOddNumbers();
                        break;
                    case 3:
                        OrdainFiveWords();
                        break;
                    case 4:
                        Jokenpo.Play();
                        break;
                    case 5:
                        TicTacToe.Play();
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

        public static void MultiplyNumbers(int numberToMultiply)
        {
            var numbers = new int[10];
            var multipliedNumbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Entre com o número {i + 1}");
                numbers[i] = int.Parse(Console.ReadLine());

                multipliedNumbers[i] = numbers[i] * numberToMultiply;
            }

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(string.Join(", ", multipliedNumbers));
        }

        public static void SeparateEvenAndOddNumbers()
        {
            var oddNumbers = new List<int>();
            var pairNumbers = new List<int>();

            var numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Entre com o número {i + 1}");
                numbers[i] = int.Parse(Console.ReadLine());

                if (numbers[i] % 2 == 0)
                {
                    pairNumbers.Add(numbers[i]);
                }
                else
                {
                    oddNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine($"Números ímpares: {string.Join(", ", oddNumbers.ToArray())}");
            Console.WriteLine($"Números pares: {string.Join(", ", pairNumbers.ToArray())}");
        }

        public static void OrdainFiveWords()
        {
            var words = new string[5];

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"Informe a palavra {i + 1}");
                words[i] = Console.ReadLine();
            }

            var orderedWords = words.OrderBy(w => w.Length);

            Console.WriteLine($"Palavras ordenadas por tamanho: {string.Join(", ", orderedWords)}");
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