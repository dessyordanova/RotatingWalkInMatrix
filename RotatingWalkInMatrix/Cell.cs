using System;
using System.Linq;

namespace RotatingWalkInMatrix
{
    public class Cell
    {
        private int value;
        private bool isVisited;

        public Cell()
        {
            this.value = 0;
            this.isVisited = false;
        }

        public Cell(int value, bool isVisited)
        {
            this.value = value;
            this.isVisited = isVisited;
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            internal set
            {
                this.value = value;
            }
        }

        public bool IsVisited
        {
            get
            {
                return this.isVisited;
            }
            internal set
            {
                this.isVisited = value;
            }
        }
    }
}