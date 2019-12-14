using System;

namespace SchiffeVersenken
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Board board = new Board();
            board.InitField();

            //int[,] realField = Board.field;

            // i want to implement this "realField" in the class player
            // i also need the list "readyToShip" to have the coordinates...

            Console.ReadLine();
        }
    }
}
