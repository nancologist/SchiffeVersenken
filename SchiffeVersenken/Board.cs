using System;
using System.Collections.Generic;

namespace SchiffeVersenken
{
    public class Board
    {
        private const int FIELD_SIZE = 10;

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
            for (int y = 0; y < hiddenField.GetLength(0); y++)
            {
                for (int x = 0; x < hiddenField.GetLength(1); x++)
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

        public static void InitBlankField(int[] inputPoint = null, int mode = 0)
        {
            if (inputPoint != null && mode == 3)
            {
                hiddenField[inputPoint[0], inputPoint[1]] = mode;
            }
            
            if (inputPoint != null && mode == 2)
            {
                hiddenField[inputPoint[0], inputPoint[1]] = mode;
            }

            Console.WriteLine("   0   1   2   3   4   " +
                "5   6    7   8    9\n");
            for (int y = 0; y < hiddenField.GetLength(0); y++)
            {
                Console.Write(y + "  ");
                for (int x = 0; x < hiddenField.GetLength(1); x++)
                {

                    switch (hiddenField[y, x])
                    {
                        case 1: // sea
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;

                        case 2: // shoot off target
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;

                        case 3: //bingo
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


        public void PositionShipsOnField()
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

                Console.Write("Points -->");
                foreach (int[] point in ship.points)
                {
                    Console.Write($"(j={point[0]}, i={point[1]}), ");
                    
                }
                Console.WriteLine("\n################################");
                Console.WriteLine("\n");
            }

            Console.WriteLine("   0   1   2   3   4   " +
                                "5   6    7   8    9\n");
            for (int y = 0; y < field.GetLength(0); y++)
            {
                Console.Write(y + "  ");
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    
                    switch (field[y, x])
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
