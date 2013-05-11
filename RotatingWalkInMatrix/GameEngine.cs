using System;
using System.Collections.Generic;
using System.Linq;

namespace RotatingWalkInMatrix
{
    public class GameEngine
    {
        private Matrix matrix;

        public GameEngine(int matrixSize)
        {
            Matrix matrix = new Matrix(matrixSize);
            this.matrix = matrix;
        }

        public Matrix Matrix
        {
            get
            {
                return this.matrix;
            }
            set
            {
                this.matrix = value;
            }
        }

        public string Run()
        {
            int matrixSize = this.Matrix.Cells.GetLength(0);
            int currentNumber = 1;
            int currentRow = 0;
            int currentCol = 0;
            bool areCurrentCoordsInRange = matrix.IsInRange(LimitType.Rows, currentRow) &&
                                           matrix.IsInRange(LimitType.Cols, currentCol);
            List<Direction> directions = new List<Direction>()
            {
                new Direction(1,1), //down right
                new Direction(1,0), //down
                new Direction(1,-1), //down left
                new Direction(0,-1), //left
                new Direction(-1,-1), //up left     
                new Direction(-1,0), //up
                new Direction(-1,1), //up right
                new Direction(0,1), //right
            };
            int directionIndex = 0;
            Direction currentDirection = directions[directionIndex];
            int newRow = currentRow + currentDirection.X;
            int newCol = currentCol + currentDirection.Y;
            bool areNewCoordsInRange = matrix.IsInRange(LimitType.Rows, newRow) &&
                                       matrix.IsInRange(LimitType.Cols, newCol);

            while (currentNumber <= matrixSize * matrixSize)
            {
                if (areCurrentCoordsInRange)
                {
                    matrix.Cells[currentRow, currentCol].Value = currentNumber;
                    matrix.Cells[currentRow, currentCol].IsVisited = true;
                    currentNumber++;
                }

                if (!matrix.ExistPossibleNeighbouringCell(currentRow, currentCol))
                {
                    // break;
                    matrix.FindStartingCell(out currentRow, out currentCol);
                    continue;
                }

                while (!(areNewCoordsInRange) || matrix.Cells[newRow, newCol].IsVisited)
                {
                    //Change direction
                    directionIndex = (directionIndex + 1) % directions.Count;
                    currentDirection = directions[directionIndex];
                    newRow = currentRow + currentDirection.X;
                    newCol = currentCol + currentDirection.Y;
                    areNewCoordsInRange = matrix.IsInRange(LimitType.Rows, newRow) &&
                                          matrix.IsInRange(LimitType.Cols, newCol);
                }

                currentRow += currentDirection.X;
                currentCol += currentDirection.Y;
                areCurrentCoordsInRange = matrix.IsInRange(LimitType.Rows, currentRow) &&
                                          matrix.IsInRange(LimitType.Cols, currentCol);

                newRow = currentRow + currentDirection.X;
                newCol = currentCol + currentDirection.Y;
                areNewCoordsInRange = matrix.IsInRange(LimitType.Rows, newRow) &&
                                      matrix.IsInRange(LimitType.Cols, newCol);
            }

            return matrix.ToString();
        }
    }
}