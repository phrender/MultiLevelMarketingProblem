using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM
{
    /**
     * Simple class to represent a 
     * position inside of a 2D grid.
     */
    class Point
    {
        #region Variable

        private int x;
        private int y;

        #endregion

        #region Properties

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        #endregion

        #region Constructor

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Methods 
        #endregion

    }
}
