            int[,] field = new int[10, 10];
            Random random = new Random();

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    field[x, y] = random.Next(1, 4);
                }
            }

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    switch (field[x, y])
                    {
                        case 1:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case 3:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                    }
                    Console.Write("  ");
                }
                Console.Write("\n");
            }
            Console.Read();