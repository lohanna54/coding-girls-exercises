using System;

namespace Class_06_OOP.NumericalDraw
{
    public class NumericalDraw
    {
        private readonly Random random;
        private int attempts;
        private int drawNumber;

        public NumericalDraw()
        {
            random = new Random();
            Reset();
        }

        public static void Start()
        {
            var game = new NumericalDraw();

            bool playAgain;

            do
            {
                Console.WriteLine("Escolha um número entre 0 e 1000");
                var number = int.Parse(Console.ReadLine());

                if (game.IsMatchWithDrawnNumber(number))
                {
                    Console.WriteLine($"Você acertou!\nTentativas utilizadas: {game.attempts}");

                    Console.WriteLine("Deseja jogar novamente? S/N");
                    playAgain = char.ToUpper(Console.ReadLine()[0]) is 'S';

                    if (playAgain)
                    {
                        game.Reset();
                    }
                }
                else
                {
                    Console.WriteLine(LossMessage(game.IsGreaterThanDrawnNumber(number)));

                    game.attempts++;

                    Console.WriteLine("Deseja tentar novamente? S/N");
                    playAgain = char.ToUpper(Console.ReadLine()[0]) is 'S';
                }

            } while (playAgain);
        }

        private int DrawNumber()
        {
            return random.Next(0, 1000);
        }

        private bool IsMatchWithDrawnNumber(int chosenNumber)
        {
            return chosenNumber == drawNumber;
        }

        private bool IsGreaterThanDrawnNumber(int chosenNumber)
        {
            return chosenNumber > drawNumber;
        }

        private static string LossMessage(bool chosenNumberIsGreater)
        {
            var comparer = chosenNumberIsGreater ? "menor" : "maior";

            return $"Você errou! O número sorteado é {comparer}";
        }

        private void Reset()
        {
            drawNumber = DrawNumber();
            attempts = 1;
        }
    }
}
