using System;

namespace SchiffeVersenken
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Board board = new Board();
            board.ShowShipsOnField();
            Console.WriteLine("\n\n\n");

            Board.CheckShots();

            Player player1 = new Player();

            player1.Play(board);

            //PlayGround.TestArrayEqauls();

            Console.ReadLine();
        }
    }
}
