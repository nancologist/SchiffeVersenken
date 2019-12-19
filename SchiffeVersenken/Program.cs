using System;
using static SchiffeVersenken.Board;

namespace SchiffeVersenken
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Board board = new Board();
            board.ShowShipsOnField();
            Console.WriteLine("\n\n\n");
            MapToConsole(hiddenField);

            Player player1 = new Player();
            player1.Play(board);

            Console.ReadLine();
        }
    }
}
