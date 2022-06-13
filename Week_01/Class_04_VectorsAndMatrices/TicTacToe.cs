using System;

namespace Class_04_VectorsAndMatrices
{
    public static class TicTacToe
    {
        public static void Play()
        {
            char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

            var playersMark = new char[2];
            var playersName = new string[] { "1", "2" };
            var player = 0;

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
                    playersMark = DefinePlayersMark(markSelected);
                    definedPlayers = true;
                }

            } while (!definedPlayers);

            ShowBoard(board);
            var gameStarted = true;

            while (gameStarted)
            {
                Console.WriteLine($"Vez do jogador {playersName[player]}");
                Console.WriteLine("Escolha um campo: ");

                if (int.TryParse(Console.ReadLine(), out int playerInput) && playerInput is >= 1 and <= 9)
                {
                    if (AlreadyFilled(board, playerInput))
                    {
                        Console.WriteLine("Campo já marcado. Escolha outro");
                    }
                    else
                    {
                        board = BoardPositionMark(board, playerInput, playersMark[player]);
                        ShowBoard(board);

                        if (GameWon(board))
                        {
                            gameStarted = false;
                            Console.WriteLine($"Jogador {playersName[player]} venceu!");
                        }

                        player = SwitchPlayer(player);
                    }
                }
                else
                {
                    Console.WriteLine("Escolha um campo válido");
                }
            }
        }

        private static char[] DefinePlayersMark(char playerOneChoice)
        {
            var playerTwo = playerOneChoice is 'X' ? 'O' : 'X';
            return new char[] { playerOneChoice, playerTwo };
        }

        private static void ShowBoard(char[,] boardPositions)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {boardPositions[0, 0]}  |  {boardPositions[0, 1]}  |  { boardPositions[0, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {boardPositions[1, 0]}  |  {boardPositions[1, 1]}  |  {boardPositions[1, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {boardPositions[2, 0]}  |  { boardPositions[2, 1]}  |  {boardPositions[2, 2]}");
            Console.WriteLine("     |     |      ");
        }

        private static int SwitchPlayer(int player)
        {
            return 1 - player;
        }

        private static bool AlreadyFilled(char[,] positions, int input)
        {
            int boardWidth = positions.GetLength(0);
            int boardHeight = positions.GetLength(1);

            for (int x = 0; x < boardWidth; ++x)
            {
                for (int y = 0; y < boardHeight; ++y)
                {
                    if (int.TryParse(positions[x, y].ToString(), out int availablePosition) && availablePosition == input)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static char[,] BoardPositionMark(char[,] board, int selectedPosition, char userMark)
        {
            int boardWidth = board.GetLength(0);
            int boardHeight = board.GetLength(1);

            for (int x = 0; x < boardWidth; ++x)
            {
                for (int y = 0; y < boardHeight; ++y)
                {
                    if (int.TryParse(board[x, y].ToString(), out int position) && position == selectedPosition)
                    {
                        board[x, y] = userMark;
                    }
                }
            }

            return board;
        }

        private static bool GameWon(char[,] positions)
        {
            return
                (positions[0, 0] == positions[0, 1] && positions[0, 1] == positions[0, 2]) ||
                (positions[1, 0] == positions[1, 1] && positions[1, 1] == positions[1, 2]) ||
                (positions[2, 0] == positions[2, 1] && positions[2, 1] == positions[2, 2]) ||
                (positions[0, 0] == positions[0, 2] && positions[0, 2] == positions[2, 0]) ||
                (positions[0, 1] == positions[1, 1] && positions[1, 1] == positions[2, 1]) ||
                (positions[0, 2] == positions[1, 2] && positions[1, 2] == positions[2, 2]) ||
                (positions[0, 0] == positions[1, 1] && positions[1, 1] == positions[2, 2]) ||
                (positions[0, 2] == positions[1, 1] && positions[1, 1] == positions[2, 2]);
        }
    }
}
