using System;

namespace SchiffeVersenken
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Board board = new Board();
            board.PositionShipsOnField();
            Console.WriteLine("\n\n\n");

            board.InitBlankField();

            Player.Play(board);

            //PlayGround.TestArrayEqauls();

            Console.ReadLine();
        }
    }
}
