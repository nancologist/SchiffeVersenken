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

            Board.InitHiddenField();

            Player.Play(board);

            //PlayGround.TestArrayEqauls();

            Console.ReadLine();
        }
    }
}
