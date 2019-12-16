using System;
using System.Linq;

namespace SchiffeVersenken
{
    public class Player
    {
        public static int bingo;

        public static void Play(Board board)
        {
            while (bingo < 10)
            {
                int bingo_0 = bingo;
                int x = -1;
                int y = -1;

                // Try&Catch:
                // Catch1: Wenn der User eine Zahl größer als neun eingibt...
                // Catch2: Damit wenn der User aus Versehen eine andere Taste wie "Enter" druckt, der Programm uns nicht rausschmeißt
                try
                {
                    AskUserToShoot(x, y, bingo_0, board);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The input number should be between 0 and 9 (inclusive)");
                    AskUserToShoot(x, y, bingo_0, board);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input. Do you want to leave the game? (y/n): ");

                    string answer = Console.ReadLine().ToLower();

                    if (answer == "n")
                    {
                        AskUserToShoot(x, y, bingo_0, board);
                    }
                    else
                    {
                        Console.WriteLine("You left the game... :(");
                        break;
                    }
                }

                
            }

            if (bingo == 10)
            {
                Console.WriteLine("~~~~~~ YOU WON!!! ~~~~~~");
            }

        }

        public static void AskUserToShoot(int x, int y, int bingo_0, Board board)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Enter x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter y: ");
            y = Convert.ToInt32(Console.ReadLine());
            int shipNumber = 0;
            foreach (Ship ship in board.ships)
            {
                shipNumber++;

                foreach (int[] point in ship.points)
                {
                    if (Enumerable.SequenceEqual(point, new int[] { y, x }))
                    {

                        foreach (int[] killedPoint in ship.points)
                        {
                            Console.Clear();
                            Board.InitBlankField(killedPoint[0], killedPoint[1], 3);
                        }

                        bingo++;
                        Console.WriteLine($"Bingo! {10 - bingo} more ships to kill!");
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Sorry, you did not shoot any ship, try again!");
                Console.WriteLine($"Only {10 - bingo} more ships!");
            }
        }

    }
}
