namespace Class_06_OOP.TicTacToe_v2
{
    public class Player
    {
        public int Number { get; set; }

        public char GameMark { get; set; }

        public Player(int number, char gameMark)
        {
            Number = number;
            GameMark = gameMark;
        }
    }
}
