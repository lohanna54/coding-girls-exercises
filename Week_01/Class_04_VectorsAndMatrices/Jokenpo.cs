using System;

namespace Class_04_VectorsAndMatrices
{
    public static class Jokenpo
    {
        public static void Play()
        {
            var playGame = true;

            while (playGame)
            {
                Console.WriteLine("Digite a quantidade de rodadas:");
                var numberOfRounds = int.Parse(Console.ReadLine());

                var options = new string[3] { "Pedra", "Papel", "Tesoura" };

                var random = new Random();
                var userWins = 0;
                var computerWins = 0;

                string winner;
                var round = 1;

                Console.Clear();
                do
                {
                    Console.WriteLine($"\n--- Rodada {round} ---\n ");
                    Console.WriteLine("         __________________________________");
                    Console.WriteLine("        |          |          |            |");
                    Console.WriteLine("Escolha:| 1. Pedra | 2. Papel | 3. Tesoura |");
                    Console.WriteLine("        |__________|__________|____________|");

                    if (int.TryParse(Console.ReadLine(), out int userOption) && userOption is >= 1 and <= 3)
                    {
                        var userChoice = options[userOption - 1];

                        var randomOption = random.Next(options.Length);
                        var computerChoice = options[randomOption];

                        var roundResult = ComputeRound(userChoice, userWins, computerChoice, computerWins);

                        Console.Clear();
                        Console.WriteLine("\n--- Rodada anterior ---\n");
                        Console.WriteLine($"Sua escolha: {userChoice}");
                        Console.WriteLine($"Escolha do computador: {computerChoice}");

                        userWins = roundResult.userWins;
                        computerWins = roundResult.computerWins;

                        round++;
                        numberOfRounds--;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }

                } while (numberOfRounds > 0);

                winner = DefineWinner(userWins, computerWins);

                Console.WriteLine("\n --- Resultado --- \n");
                Console.WriteLine($"Vencedor: {winner}!");
                Console.WriteLine("\n --- Vitórias --- \n");
                Console.WriteLine($"Suas: {userWins}\nComputador: {computerWins}\n\n");

                Console.WriteLine("Jogar novamente? S/N");
                var playAgain = Console.ReadLine();

                playGame = string.Equals(playAgain, "s", StringComparison.OrdinalIgnoreCase);
            }
        }

        private static (int userWins, int computerWins) ComputeRound(string userChoice, int userWins, string computerChoice, int computerWins)
        {
            if ((computerChoice.Equals("Pedra") && userChoice.Equals("Tesoura")) ||
                (computerChoice.Equals("Papel") && userChoice.Equals("Pedra")) ||
                (computerChoice.Equals("Tesoura") && userChoice.Equals("Papel")))
            {
                computerWins++;
            }
            else if ((computerChoice.Equals("Tesoura") && userChoice.Equals("Pedra")) ||
                (computerChoice.Equals("Pedra") && userChoice.Equals("Papel")) ||
                (computerChoice.Equals("Papel") && userChoice.Equals("Tesoura")))
            {
                userWins++;
            }

            return (userWins, computerWins);
        }

        private static string DefineWinner(int userWins, int computerWins)
        {
            if (userWins > computerWins)
            {
                return "Você";
            }
            else if (computerWins > userWins)
            {
                return "Computador";
            }
            else
            {
                return "Empate";
            }
        }
    }
}
