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
                            bingo++;
                            Console.WriteLine("You destroyed the ship " + shipNumber);
                            Console.WriteLine($"{10 - bingo} to kill!");
                            ship.points.Clear(); // before Clear() should all the point in this points be change to white!
                            break;
                        }
                    }
                }

                if (bingo == bingo_0)
                {
                    Console.WriteLine("You did not shoot any ship, try again!");
                }
                
            }

        }

        public void AskUserToShoot()
        {

        }

    }
}
