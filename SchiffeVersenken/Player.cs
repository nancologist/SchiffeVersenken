using System;
namespace SchiffeVersenken
{
    public class Player
    {
        private int[,] blankField = new int[10, 10];

        public Player()
        {
        }

        public void ShowBlankField()
        {

            for (int y = 0; y < blankField.GetLength(0); y++)
            {
                for (int x = 0; x < blankField.GetLength(1); x++)
                {
                    blankField[y, x] = 1;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("  ");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
                Console.Write("\n\n");
            }

        }

        public void AskUserToShoot()
        {

        }

    }
}
