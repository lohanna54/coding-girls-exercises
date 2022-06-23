using System;

namespace Class_06_OOP.TicTacToe_v2
{
    public class TicTacToe
    {
        private char[,] Board { get; }

        public TicTacToe()
        {
            Board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        public static void Play()
        {
            var game = new TicTacToe();
            var players = new Player[2];

            var playerIndex = 0;

            var definedPlayers = false;

            do
            {
                Console.WriteLine("Jogador 1: escolha entre X e O");
                var markSelected = char.ToUpper(Console.ReadLine()[0]);

                if (!(markSelected is 'X' or 'O'))
                {
                    Console.WriteLine("Opção inválida");
                }
                else
                {
                    players = CreatePlayers(markSelected);
                    definedPlayers = true;
                }

            } while (!definedPlayers);

            game.ShowBoard();
            var gameStarted = true;

            while (gameStarted)
            {
                Console.WriteLine($"Vez do jogador {players[playerIndex].Number}");
                Console.WriteLine("Escolha um campo: ");

                if (int.TryParse(Console.ReadLine(), out int playerInput) && playerInput is >= 1 and <= 9)
                {
                    if (game.AlreadyFilled(playerInput))
                    {
                        Console.WriteLine("Campo já marcado. Escolha outro");
                    }
                    else
                    {
                        game.BoardPositionMark(playerInput, players[playerIndex].GameMark);
                        game.ShowBoard();

                        if (game.CheckWon())
                        {
                            gameStarted = false;
                            Console.WriteLine($"Jogador {players[playerIndex].Number} venceu!");
                        }

                        playerIndex = SwitchPlayer(playerIndex);
                    }
                }
                else
                {
                    Console.WriteLine("Escolha um campo válido");
                }
            }
        }

        public void ShowBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {Board[0, 0]}  |  {Board[0, 1]}  |  {Board[0, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {Board[1, 0]}  |  {Board[1, 1]}  |  {Board[1, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {Board[2, 0]}  |  {Board[2, 1]}  |  {Board[2, 2]}");
            Console.WriteLine("     |     |      ");
        }

        public static Player[] CreatePlayers(char playerOneMark)
        {
            var playerTwoMark = playerOneMark is 'X' ? 'O' : 'X';

            return new Player[2]
            {
                new Player(1, playerOneMark),
                new Player(2, playerTwoMark)
            };
        }

        public bool AlreadyFilled(int input)
        {
            int boardWidth = Board.GetLength(0);
            int boardHeight = Board.GetLength(1);

            for (int x = 0; x < boardWidth; ++x)
            {
                for (int y = 0; y < boardHeight; ++y)
                {
                    if (int.TryParse(Board[x, y].ToString(), out int availablePosition) && availablePosition == input)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void BoardPositionMark(int selectedPosition, char userMark)
        {
            int boardWidth = Board.GetLength(0);
            int boardHeight = Board.GetLength(1);

            for (int x = 0; x < boardWidth; ++x)
            {
                for (int y = 0; y < boardHeight; ++y)
                {
                    if (int.TryParse(Board[x, y].ToString(), out int position) && position == selectedPosition)
                    {
                        Board[x, y] = userMark;
                    }
                }
            }
        }

        public bool CheckWon()
        {
            return
                (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2]) ||
                (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0]) ||
                (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) ||
                (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]) ||
                (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2]) ||
                (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1]) ||
                (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2]) ||
                (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2]);
        }

        public static int SwitchPlayer(int player)
        {
            return 1 - player;
        }
    }
}
