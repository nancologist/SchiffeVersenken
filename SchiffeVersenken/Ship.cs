using System;
using System.Collections.Generic;

namespace SchiffeVersenken
{
    // TODO modify the Access Modifiers
    public class Ship
    {
        const int FIELD_SIZE = 9;

        const int NORTH = 1;
        const int EAST = 2;
        const int SOUTH = 3;
        const int WEST = 4;

        private int shipSize;
        int x;
        int y;
        int direction; // 1: north (decrement y), 2:east (increment x),
                       //3: south (increment y), 4: west (decrement x).

        int color;

        // Comfort Zone: where all the four directions are valid to place the ship
        bool xInComfortZoneLeft;
        bool xInComfortZoneRight;
        bool yInComfortZoneTop;
        bool yInComfortZoneBottom;

        bool xInComfortZone;
        bool yInComfortZone;

        bool inTopLeft;
        bool inTopRight;
        bool inBottomLeft;
        bool inBottomRight;

        bool inComfortZone;

        public List<int[]> points;

        Random random = new Random();

        public Ship(int shipSize)
        {
            
            this.shipSize = shipSize;
            color = shipSize;
        }

        public int[,] PlaceShip(int[,] field)
        {
            InitCoordinationsAndDirection();
            direction = SetDirection();

            points = new List<int[]>();

            int x_initVal = x;
            int y_initVal = y;

            switch (direction)
            {
                case 1:
                    for (int j = field.GetLength(0) - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < field.GetLength(1); i++)
                        {
                            if (i == x && j == y
                                && y_initVal - y < shipSize
                                && points.Count < shipSize)
                            {
                                
                                if (field[j, i] != 1)
                                {
                                    points = new List<int[]>();
                                    PlaceShip(field);
                                }
                                else
                                {
                                    points.Add(new int[] { j, i });
                                }

                                y--;
                            }

                        }
                    }
                    break;

                case 2:
                    for (int j = 0; j < field.GetLength(0); j++)
                    {
                        for (int i = 0; i < field.GetLength(1); i++)
                        {
                            if (i == x && j == y
                                && x - x_initVal < shipSize
                                && points.Count < shipSize) // Diese letzte Beschränkung hat mich nach 2 Stunden gerettet!
                            {
                                if (field[j, i] != 1)
                                {
                                    points = new List<int[]>();
                                    PlaceShip(field);
                                }
                                else
                                {
                                    points.Add(new int[] { j, i });
                                }

                                x++;

                            }

                        }
                    }
                    break;

                case 3:
                    for (int j = 0; j < field.GetLength(0); j++)
                    {
                        for (int i = 0; i < field.GetLength(1); i++)
                        {
                            if (i == x && j == y
                                && y - y_initVal < shipSize
                                && points.Count < shipSize)
                            {

                                if (field[j, i] != 1)
                                {
                                    points = new List<int[]>();
                                    PlaceShip(field);
                                }
                                else
                                {
                                    points.Add(new int[] { j, i });
                                }

                                y++;

                            }

                        }
                    }
                    break;

                case 4:
                    for (int j = 0; j < field.GetLength(0); j++)
                    {
                        for (int i = field.GetLength(1) - 1; i >= 0; i--)
                        {
                            if (i == x && j == y
                                && x_initVal - x < shipSize
                                && points.Count < shipSize)
                            {

                                if (field[j, i] != 1)
                                {
                                    points = new List<int[]>();
                                    PlaceShip(field);
                                }
                                else
                                {
                                    points.Add(new int[] { j, i });
                                }

                                x--;

                            }

                        }
                    }
                    break;
            }

            // - DEBUG -
            Console.WriteLine($"ship size: {shipSize}\nx0: {x_initVal}, y0: " +
                $"{y_initVal}\ndirection: {direction}");
            

            foreach (int[] coord in points)
            {
                field[coord[0], coord[1]] = color;
            }

            return field;

        }
        
        public int SetDirection()
        {
            if (inComfortZone) // in Region CZ
            {
                return direction;
            }
            else
            {
                if (!yInComfortZoneTop)  // in Region (1),(2),(3)
                {
                    if (!inTopLeft && !inTopRight)  // in Region(2)
                    {
                        while (direction == NORTH)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }
                    else if (inTopLeft)  // in Region(1)
                    {
                        while (direction == NORTH || direction == WEST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;

                    }
                    else // inTopRight -> in Region(3)
                    {
                        while (direction == NORTH || direction == EAST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }

                }
                else if (!yInComfortZoneBottom) // in Region 6,7,8
                {

                    if (!inBottomLeft && !inBottomRight) // in Region 7
                    {
                        while (direction == SOUTH)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }
                    else if (inBottomLeft) // Region 6
                    {
                        while (direction == SOUTH || direction == WEST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }
                    else // in Region 8
                    {
                        while (direction == SOUTH || direction == EAST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }

                }
                else // in Region 4 , 5
                {
                    if (!xInComfortZoneLeft) // in Region 4
                    {
                        while (direction == WEST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }
                    else // !xInComfortZoneRight in Region 5
                    {
                        while (direction == EAST)
                        {
                            direction = random.Next(1, 5);
                        }
                        return direction;
                    }

                }
            }
        }

        public void InitCoordinationsAndDirection()
        {
            this.x = random.Next(0, FIELD_SIZE + 1);
            this.y = random.Next(0, FIELD_SIZE + 1);
            this.direction = random.Next(1, 5);

            // - DEBUG - 
            //Console.WriteLine($"x0: {x}, y0: {y}, direction0: {direction}");

            // check position of ship
            xInComfortZoneLeft = x >= shipSize - 1;
            xInComfortZoneRight = x <= FIELD_SIZE - shipSize;
            yInComfortZoneTop = y >= shipSize - 1;
            yInComfortZoneBottom = y <= FIELD_SIZE - shipSize;

            xInComfortZone = (xInComfortZoneLeft && xInComfortZoneRight);
            yInComfortZone = (yInComfortZoneTop && yInComfortZoneBottom);
            inComfortZone = xInComfortZone && yInComfortZone;

            inTopLeft = !xInComfortZoneLeft && !yInComfortZoneTop;
            inTopRight = !xInComfortZoneRight && !yInComfortZoneTop;
            inBottomLeft = !xInComfortZoneLeft && !yInComfortZoneBottom;
            inBottomRight = !xInComfortZoneRight && !yInComfortZoneBottom;
        }
    }
}
