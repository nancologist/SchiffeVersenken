﻿using System;
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
            while (true)
            {
                int x = -1;
                int y = -1;

                try
                {
                    AskUserToShoot(x, y, board);
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
                        Console.WriteLine("You left the game... :(");
                        break;
                    }
                }  
            }
        }

        public static void AskUserToShoot(int x, int y, Board board)
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
                        isShiptHit = true;
                        Board.InitHiddenField(point, isShiptHit);

                        break;
                    }
                    
                }

            }

            Board.InitHiddenField(shot, isShiptHit);

        }

    }
}
