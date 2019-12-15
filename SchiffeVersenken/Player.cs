using System;
using System.Linq;

namespace SchiffeVersenken
{
    public class Player
    {
        public static int bingo;

        public Player()
        {
        }

        public static void Play(Board board)
        {
            while (bingo < 10)
            {
                int bingo_0 = bingo;

                Console.Write("Enter x: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter y: ");
                int y = Convert.ToInt32(Console.ReadLine());

                int shipNumber = 0;
                foreach (Ship ship in board.ships)
                {
                    shipNumber++;

                    foreach(int[] point in ship.points)
                    {
                        if (Enumerable.SequenceEqual(point, new int[] { y, x }))
                        {

                            foreach (int[] killedPoint in ship.points)
                            {
                                Console.Clear();
                                Board.InitBlankField(killedPoint[0], killedPoint[1], 3);
                            }

                            bingo++;
                            Console.WriteLine($"{10 - bingo} more ships to kill!");
                            //Console.WriteLine("+++++++++++++++++++++++++++++++++++");

                            // we clear elements to remove the cheat-win-bug!!!!
                            ship.points.Clear();
                            break; // without break there is an error!
                        }
                    }
                }

                if (bingo == bingo_0)
                {
                    Board.InitBlankField(y, x, 2);
                    Console.WriteLine("Sorry, you did not shoot any ship, try again!");
                }
            }

            Console.WriteLine("~~~~~~ YOU WON!!! ~~~~~~");

        }

        public void AskUserToShoot()
        {

        }

    }
}
