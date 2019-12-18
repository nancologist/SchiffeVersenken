using System;
using System.Collections.Generic;

namespace SchiffeVersenken
{
    // TODO modify the Access Modifiers
    // Todo All magic numbers should be replaced 
    public class Ship
    {
        private const int FIELD_SIZE = 10;

        const int NORTH = 1;
        const int EAST = 2;
        const int SOUTH = 3;
        const int WEST = 4;
        private const int BLUE = 1;

        private int shipSize;
        int x;
        int y;
        int direction; // 1: north (decrement y), 2:east (increment x),
                       //3: south (increment y), 4: west (decrement x).

        int color;

        // Comfort Zone: where all the four directions are valid to place the ship
        bool xInComfortZoneLeft;
        bool xInComfortZoneRight;
        bool xInComfortZone;
        bool yInComfortZoneTop;
        bool yInComfortZoneBottom;
        bool yInComfortZone;
        bool xAndYinComfortZone;

        bool inTopLeft;
        bool inTopRight;
        bool inBottomLeft;
        bool inBottomRight;

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
            direction = CorrectDirection();

            points = new List<int[]>();

            int x_initVal = x;
            int y_initVal = y;

            switch (direction)
            {
                case NORTH:

                    CheckHeadAndTailOfShip(y_initVal, x_initVal, NORTH, field);

                    for (int j = FIELD_SIZE - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < FIELD_SIZE; i++)
                        {
                            if (i == x && j == y
                                && y_initVal - y < shipSize
                                && points.Count < shipSize)
                            {
                                CheckSidesOfShip_NS(i, j, field);
                                y--;
                            }
                        }
                    }
                    break;

                case EAST:

                    CheckHeadAndTailOfShip(y_initVal, x_initVal, EAST, field);

                    for (int j = 0; j < FIELD_SIZE; j++)
                    {
                        for (int i = 0; i < FIELD_SIZE; i++)
                        {
                            if (i == x && j == y
                                && x - x_initVal < shipSize
                                && points.Count < shipSize)
                            {
                                if (j == 0)
                                {
                                    CheckSidesOfShipAtBounderies(i, j, 1, "horizontal", field);

                                    //if (field[j, i] != BLUE || field[j + 1, i ] != BLUE)
                                    //{
                                    //    points.Clear();
                                    //    PlaceShip(field);
                                    //}
                                    //else
                                    //{
                                    //    points.Add(new int[] { j, i });
                                    //}
                                }
                                else if (j == FIELD_SIZE - 1)
                                {
                                    CheckSidesOfShipAtBounderies(i, j, -1, "horizontal", field);

                                    //if (field[j, i] != BLUE || field[j - 1, i ] != BLUE)
                                    //{
                                    //    points.Clear();
                                    //    PlaceShip(field);
                                    //}
                                    //else
                                    //{
                                    //    points.Add(new int[] { j, i });
                                    //}
                                }
                                else
                                {
                                    if (field[j, i] != BLUE || field[j - 1, i ] != BLUE
                                        || field[j + 1, i ] != BLUE)
                                    {
                                        points.Clear();
                                        PlaceShip(field);
                                    }
                                    else
                                    {
                                        points.Add(new int[] { j, i });
                                    }
                                }
                                x++;
                            }
                        }
                    }
                    break;

                case SOUTH:

                    CheckHeadAndTailOfShip(y_initVal, x_initVal, SOUTH, field);

                    for (int j = 0; j < FIELD_SIZE; j++)
                    {
                        for (int i = 0; i < FIELD_SIZE; i++)
                        {
                            if (i == x && j == y
                                && y - y_initVal < shipSize
                                && points.Count < shipSize)
                            {
                                CheckSidesOfShip_NS(i, j, field);
                                y++;
                            }
                        }
                    }
                    break;

                case WEST:

                    CheckHeadAndTailOfShip(y_initVal, x_initVal, WEST, field);

                    for (int j = 0; j < FIELD_SIZE; j++)
                    {
                        for (int i = FIELD_SIZE - 1; i >= 0; i--)
                        {
                            if (i == x && j == y
                                && x_initVal - x < shipSize
                                && points.Count < shipSize)
                            {

                                if (j == 0)
                                {
                                    CheckSidesOfShipAtBounderies(i, j, 1, "horizontal", field);

                                    //if (field[j, i] != BLUE || field[j + 1, i] != BLUE)
                                    //{
                                    //    points.Clear();
                                    //    PlaceShip(field);
                                    //}
                                    //else
                                    //{
                                    //    points.Add(new int[] { j, i });
                                    //}
                                }
                                else if (j == FIELD_SIZE - 1)
                                {
                                    CheckSidesOfShipAtBounderies(i, j, -1, "horizontal", field);

                                    //if (field[j, i] != BLUE || field[j - 1, i] != BLUE)
                                    //{
                                    //    points.Clear();
                                    //    PlaceShip(field);
                                    //}
                                    //else
                                    //{
                                    //    points.Add(new int[] { j, i });
                                    //}
                                }
                                else
                                {
                                    if (field[j, i] != BLUE || field[j - 1, i] != BLUE
                                        || field[j + 1, i] != BLUE)
                                    {
                                        points.Clear();
                                        PlaceShip(field);
                                    }
                                    else
                                    {
                                        points.Add(new int[] { j, i });
                                    }
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

        public void CheckHeadAndTailOfShip(int coordY, int coordX, int direction , int[,] field)
        {
            switch(direction)
            {
                case NORTH:
                    if (direction == NORTH)
                    {
                        if (coordY == FIELD_SIZE - 1)
                        {
                            if (field[coordY - shipSize, coordX] != BLUE)
                            {
                                points.Clear();
                                PlaceShip(field);
                            }
                        }
                        else if (coordY < shipSize)
                        {
                            if (field[coordY + 1, coordX] != BLUE)
                            {
                                points.Clear();
                                PlaceShip(field);
                            }
                        }
                        else
                        {
                            if (field[coordY + 1, coordX] != BLUE ||
                            field[coordY - shipSize, coordX] != BLUE)
                            {
                                points.Clear();
                                PlaceShip(field);
                            }
                        }
                    }
                    break;

                case WEST:
                    if (coordX == FIELD_SIZE - 1)
                    {
                        if (field[coordY, coordX - shipSize] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else if (coordX < shipSize)
                    {
                        if (field[coordY, coordX + 1] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else
                    {
                        if (field[coordY, coordX + 1] != BLUE ||
                        field[coordY, coordX - shipSize] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    break;

                case EAST:
                    if (coordX == 0)
                    {
                        if (field[coordY, coordX + shipSize] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else if (coordX >= FIELD_SIZE - shipSize)
                    {
                        if (field[coordY, coordX - 1] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else
                    {
                        if (field[coordY, coordX - 1] != BLUE ||
                        field[coordY, coordX + shipSize] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    break;

                case SOUTH:

                    if (coordY == 0)
                    {
                        if (field[coordY + shipSize, coordX] != 1)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else if (coordY >= FIELD_SIZE - shipSize)
                    {
                        if (field[coordY - 1, coordX] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    else
                    {
                        if (field[coordY - 1, coordX] != BLUE ||
                        field[coordY + shipSize, coordX] != BLUE)
                        {
                            points.Clear();
                            PlaceShip(field);
                        }
                    }
                    break;
            }

        }

        public void CheckSidesOfShip_NS(int i, int j, int[,] field)
        {
            if (i == 0)
            {
                CheckSidesOfShipAtBounderies(i, j, 1, "vertical", field);
            }
            else if (i == FIELD_SIZE - 1)
            {
                CheckSidesOfShipAtBounderies(i, j, -1, "vertical", field);
            }
            else
            {
                if (field[j, i] != BLUE || field[j, i - 1] != BLUE
                    || field[j, i + 1] != BLUE)
                {
                    points.Clear();
                    PlaceShip(field);
                }
                else
                {
                    points.Add(new int[] { j, i });
                }
            }
        }

        public void CheckSidesOfShipAtBounderies(int i, int j, int adjacent, string orientation, int[,] field)
        {
            switch(orientation)
            {
                case "vertical":
                    if (field[j, i] != BLUE || field[j, i + adjacent] != BLUE)
                    {
                        points.Clear();
                        PlaceShip(field);
                    }
                    else
                    {
                        points.Add(new int[] { j, i });
                    }
                    break;

                case "horizontal":
                    if (field[j, i] != BLUE || field[j + adjacent, i] != BLUE)
                    {
                        points.Clear();
                        PlaceShip(field);
                    }
                    else
                    {
                        points.Add(new int[] { j, i });
                    }
                    break;
            }
        }

        public int CorrectDirection()
        {
            if (xAndYinComfortZone)
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
            this.x = random.Next(0, FIELD_SIZE);
            this.y = random.Next(0, FIELD_SIZE);
            this.direction = random.Next(1, 5);

            // - DEBUG - 
            //Console.WriteLine($"x0: {x}, y0: {y}, direction0: {direction}");

            // check position of ship
            xInComfortZoneLeft = x >= shipSize - 1;
            xInComfortZoneRight = x <= FIELD_SIZE - shipSize - 1;
            yInComfortZoneTop = y >= shipSize - 1;
            yInComfortZoneBottom = y <= FIELD_SIZE - shipSize - 1;

            xInComfortZone = (xInComfortZoneLeft && xInComfortZoneRight);
            yInComfortZone = (yInComfortZoneTop && yInComfortZoneBottom);
            xAndYinComfortZone = xInComfortZone && yInComfortZone;

            inTopLeft = !xInComfortZoneLeft && !yInComfortZoneTop;
            inTopRight = !xInComfortZoneRight && !yInComfortZoneTop;
            inBottomLeft = !xInComfortZoneLeft && !yInComfortZoneBottom;
            inBottomRight = !xInComfortZoneRight && !yInComfortZoneBottom;
        }
    }
}
