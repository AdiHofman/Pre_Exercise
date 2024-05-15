using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Board
    {

        public int[,] Data { get; protected set; }

        public Board()
        {
            Data = new int[4, 4];

            FillRandomCell();
            FillRandomCell();
        }

        // filling empty random cell with 2 or 4
        private void FillRandomCell()
        {
            Random rnd = new Random();

            int cellCollumn = rnd.Next(4);
            int cellRow = rnd.Next(4);

            while (!Data[cellCollumn, cellRow].Equals(0))
            {
                cellCollumn = rnd.Next(4);
                cellRow = rnd.Next(4);
            }

            Data[cellCollumn, cellRow] = 2 * rnd.Next(1,3);
        }

        // making a move - left, right, bottom or up. returning the points that the player got for that move
        public int Move(Direction direction)
        {
            int movePoints = 0;
            if (direction.Equals(Direction.Left) || direction.Equals(Direction.Top))
            {
                // order the board by the move
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);
                
                // adding identical cells
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            movePoints += CombineIdenticalcells(direction, i, j);

                // ordering again after the add
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);
            }
            else if (direction.Equals(Direction.Right))
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 3; j >= 0; j--)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);
                    

                for (int i = 0; i < 4; i++)
                    for (int j = 3; j >= 0; j--)
                        if (!Data[i, j].Equals(0))
                            movePoints += CombineIdenticalcells(direction, i, j);

                for (int i = 0; i < 4; i++)
                    for (int j = 3; j >= 0; j--)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);
            }
            else
            {
                for (int i = 3; i >= 0; i--)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);

                for (int i = 3; i >= 0; i--)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            movePoints += CombineIdenticalcells(direction, i, j);
                
                for (int i = 3; i >= 0; i--)
                    for (int j = 0; j < 4; j++)
                        if (!Data[i, j].Equals(0))
                            MoveCellByDirection(direction, i, j);

            }

            FillRandomCell();
            return movePoints;
        }

        private void MoveCellByDirection(Direction direction, int i, int j)
        {
            int emptySpaceIndex = GetEmptyCellIndex(direction, i, j);
            switch (direction)
            {
                case Direction.Left:
                    if (emptySpaceIndex != -1 && emptySpaceIndex < j)
                    {
                        Data[i, emptySpaceIndex] = Data[i, j];
                        Data[i, j] = 0;
                    }
                    break;
                case Direction.Top:
                    if (emptySpaceIndex != -1 && emptySpaceIndex < i)
                    {
                        Data[emptySpaceIndex, j] = Data[i, j];
                        Data[i, j] = 0;
                    }
                    break;

                case Direction.Right:
                    if (emptySpaceIndex != -1 && emptySpaceIndex > j)
                    {
                        Data[i, emptySpaceIndex] = Data[i, j];
                        Data[i, j] = 0;
                    }
                    break;
                case Direction.Bottom:
                    if (emptySpaceIndex != -1 && emptySpaceIndex > i)
                    {
                        Data[emptySpaceIndex, j] = Data[i, j];
                        Data[i, j] = 0;
                    }
                    break;
            }
        }
        
        private int CombineIdenticalcells(Direction direction, int i, int j)
        {
            int points = 0;

            switch (direction)
            {
                case Direction.Left:
                    if (j > 0)
                        if (Data[i, j - 1] == Data[i, j])
                        {
                            points += Data[i, j] * 2;
                            Data[i, j - 1] = Data[i, j] * 2;
                            Data[i, j] = 0;
                        }
                    break;
                case Direction.Right:
                    if (j < 3)
                        if (Data[i, j + 1] == Data[i, j])
                        {
                            points += Data[i, j] * 2;
                            Data[i, j + 1] = Data[i, j] * 2;
                            Data[i, j] = 0;
                        }
                    break;

                case Direction.Top:
                    if (i > 0)
                        if (Data[i - 1, j] == Data[i, j])
                        {
                            points += Data[i, j] * 2;
                            Data[i - 1, j] = Data[i, j] * 2;
                            Data[i, j] = 0;
                        }
                    break;
                case Direction.Bottom:
                    if (i < 3)
                        if (Data[i + 1, j] == Data[i, j])
                        {
                            points += Data[i, j] * 2;
                            Data[i + 1, j] = Data[i, j] * 2;
                            Data[i, j] = 0;
                        }
                    break;
            }

            return points;
        }

        private int GetEmptyCellIndex(Direction direction, int i, int j)
        {
            if (direction.Equals(Direction.Left))
            {
                for (int x = 0; x < 4; x++)
                    if (Data[i, x].Equals(0))
                        return x;
            }
            else if(direction.Equals(Direction.Right))
            {
                for (int x = 3; x >= 0; x--)
                    if (Data[i, x].Equals(0))
                        return x;
            }
            else if(direction.Equals(Direction.Top))
            {
                for (int x = 0; x < 4; x++)
                    if (Data[x, j].Equals(0))
                        return x;
            }
            else
            {
                for (int x = 3; x >= 0; x--)

                    if (Data[x, j].Equals(0))
                        return x;
            }

            return -1;
        }

        // gets the board status - after making a move
        public GameStatus GetBoardStatus()
        {
            bool hasEmptyCells = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Data[i, j].Equals(0))
                        hasEmptyCells = true;
                    else if (Data[i, j].Equals(2048))
                        return GameStatus.Win;
                }
            }

            if (hasEmptyCells)
                return GameStatus.Idle;

            return GameStatus.Lost;
        }
    }
}
