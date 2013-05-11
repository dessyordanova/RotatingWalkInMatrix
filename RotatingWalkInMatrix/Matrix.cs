using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RotatingWalkInMatrix
{
    public class Matrix
    {
        private Cell[,] cells;

        public Matrix(int size)
        {
            this.Cells = new Cell[size, size];
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int i = 0; i < this.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.Cells.GetLength(1); j++)
                {
                    this.Cells[i, j] = new Cell();
                }
            }
        }

        public Cell[,] Cells
        {
            get
            {
                return this.cells;
            }
            internal set
            {
                if (value.GetLength(0) <= 0 || value.GetLength(1) <= 0)
                {
                    throw new ArgumentException("Invalid matrix size!");
                }
                this.cells = value;
            }
        }

        public void FindStartingCell(out int newX, out int newY)
        {
            newX = 0;
            newY = 0;
            int matrixRows = this.Cells.GetLength(0);
            int matrixCols = this.Cells.GetLength(1);

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    if (!this.Cells[row, col].IsVisited)
                    {
                        newX = row;
                        newY = col;

                        return;
                    }
                }
            }
        }

        public bool ExistPossibleNeighbouringCell(int startX, int startY)
        {
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
            int currentX = 0;
            int currentY = 0;
            bool existPossibleNeighbouring = false;

            foreach (Direction direction in directions)
            {
                currentX = startX + direction.X;
                currentY = startY + direction.Y;

                if (IsInRange(LimitType.Rows, currentX) && IsInRange(LimitType.Cols, currentY))
                {
                    if (!this.Cells[currentX, currentY].IsVisited)
                    {
                        existPossibleNeighbouring = true;
                        break;
                    }
                }
            }

            return existPossibleNeighbouring;
        }

        public bool IsInRange(LimitType limitType, int dimension)
        {
            bool isInRange = false;
            int limit = 0;

            if (limitType == LimitType.Rows)
            {
                limit = this.Cells.GetLength(0);
            }
            else
            {
                limit = this.Cells.GetLength(1);
            }

            if (0 <= dimension && dimension < limit)
            {
                isInRange = true;
            }

            return isInRange;
        }

        public override string ToString()
        {
            StringBuilder matrixPrint = new StringBuilder();

            for (int row = 0; row < this.Cells.GetLength(0); row++)
            {
                for (int col = 0; col < this.Cells.GetLength(1); col++)
                {
                    matrixPrint.AppendFormat("{0,3}|", this.Cells[row, col].Value);
                }
                matrixPrint.Append("\n");
                matrixPrint.AppendFormat(new string('-', this.Cells.GetLength(0) * 4));
                matrixPrint.Append("\n");
            }

            return matrixPrint.ToString();
        }
    }
}