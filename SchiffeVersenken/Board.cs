using System;
using System.Collections.Generic;

namespace SchiffeVersenken
{
    public class Board
    {
        public const int FIELD_SIZE = 10;
        private const int ON_TARGET = 7;
        private const int OFF_TARGET = 6;

        public Ship ship5;
        public Ship ship4_1;
        public Ship ship4_2;
        public Ship ship3_1;
        public Ship ship3_2;
        public Ship ship3_3;
        public Ship ship2_1;
        public Ship ship2_2;
        public Ship ship2_3;
        public Ship ship2_4;
        public List<Ship> ships;

        public static int[,] field = new int[FIELD_SIZE, FIELD_SIZE];
        public static int[,] hiddenField = new int[FIELD_SIZE, FIELD_SIZE];

        static Board()
        {
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    hiddenField[y, x] = 1;
                }
            }
        }

        public Board()
        {
            ship5 = new Ship(5);
            ship4_1 = new Ship(4);
            ship4_2 = new Ship(4);
            ship3_1 = new Ship(3);
            ship3_2 = new Ship(3);
            ship3_3 = new Ship(3);
            ship2_1 = new Ship(2);
            ship2_2 = new Ship(2);
            ship2_3 = new Ship(2);
            ship2_4 = new Ship(2);

            ships = new List<Ship>()
            {
                ship5,
                ship4_2,
                ship4_1,
                ship3_3,
                ship3_2,
                ship3_1,
                ship2_4,
                ship2_3,
                ship2_2,
                ship2_1
            };
        }

        public static void InitHiddenField(int[] inputPoint = null, bool hitShip = false)
        {
            if (inputPoint != null && hitShip)
            {
                hiddenField[inputPoint[0], inputPoint[1]] = ON_TARGET;
            }
            
            if (inputPoint != null && !hitShip)
            {
                hiddenField[inputPoint[0], inputPoint[1]] = OFF_TARGET;
            }


            MapShipsAndShotsToConsole(hiddenField);
        }


        public void ShowShipsOnField()
        {

            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    field[y, x] = 1;
                }
            }

            foreach (Ship ship in ships)
            {
                field = ship.PlaceShip(field);

                // - DEBUG - 
                //Console.Write("Points -->");
                //foreach (int[] point in ship.points)
                //{
                //    Console.Write($"(j={point[0]}, i={point[1]}), ");

                //}
                //Console.WriteLine("\n################################");
                //Console.WriteLine("\n");
            }

            MapShipsAndShotsToConsole(field);


        }

        private static void MapShipsAndShotsToConsole(int[,] arr)
        {
            Console.WriteLine("\t   0   1   2   3   4   " +
                                "5   6    7   8    9\n");
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                Console.Write(y + "\t");
                for (int x = 0; x < arr.GetLength(1); x++)
                {

                    switch (arr[y, x])
                    {
                        case 1: // sea
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;

                        case 2:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case 3:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;

                        case 4:
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            break;

                        case 5:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;

                        case OFF_TARGET: // shoot off target
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;

                        case ON_TARGET: //bingo
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;

                    }
                    Console.Write("  ");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
                Console.Write("\n\n");
            }
        }
    }
}
