using System;
using System.Linq;

namespace RotatingWalkInMatrix
{
    public struct Direction
    {
        private int x;
        private int y;

        public Direction(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            internal set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            internal set
            {
                this.y = value;
            }
        }
    }
}