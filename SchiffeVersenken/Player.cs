using System;
using System.Linq;

namespace SchiffeVersenken
{
    public class Player
    {
        public string name;
        public int countHits;
        public int totalShots; //Negative score for the player.
        public static int playerId = 1;


        public Player()
        {
            Console.Write($"Player{playerId}, enter your name: ");
            this.name = Console.ReadLine();

            playerId++;
            countHits = 0;
            totalShots = 0;
        }

        public void Play(Board board)
        {
            while (countHits < 30)
            {
                int x = -1;
                int y = -1;

                try
                {
                    AskUserToShoot(x, y, board);
                    totalShots++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The input number should be between 0 and 9 (inclusive)");
                    AskUserToShoot(x, y, board);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input. Do you want to leave the game? (y/n): ");

                    string answer = Console.ReadLine().ToLower();

                    if (answer == "n")
                    {
                        AskUserToShoot(x, y, board);
                    }
                    else
                    {
                        Console.WriteLine($"{name} left the game... :(");
                        break;
                    }
                }  
            }

            if (countHits >= board.CountBlocksToHit())
            {
                Console.WriteLine($"~~~~~ YOU WON {name}! ~~~~~");
                Console.WriteLine($"Total shots = {totalShots}");
            }
        }

        public void AskUserToShoot(int x, int y, Board board)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Enter x: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter y: ");
            y = Convert.ToInt32(Console.ReadLine());

            int[] shot = {y, x};
            bool isShiptHit = false;

            foreach (Ship ship in board.ships)
            {

                foreach (int[] point in ship.points)
                {
                    if (Enumerable.SequenceEqual(point, shot))
                    {
                        countHits++;
                        Console.WriteLine("Number of hits:" + countHits);

                        isShiptHit = true;
                        Board.CheckShots(point, isShiptHit);

                        ship.points.Remove(point);

                        break;
                    }
                    
                }

            }

            Board.CheckShots(shot, isShiptHit);

        }

    }
}
