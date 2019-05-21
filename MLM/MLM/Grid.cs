using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM
{
    class Grid
    {

        #region Enum

        public enum CornersAndLayers
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            InFirstLayer,
            PastFirstLayer
        }

        #endregion

        #region Variables

        private int sizeX;
        private int sizeY;
        private Point[,] gridArea;

        private Point topLeft;
        private Point topRight;
        private Point bottomLeft;
        private Point bottomRight;

        #endregion

        #region Properties

        public int SizeX
        {
            get { return sizeX; }
            set { sizeX = value; }
        }

        public int SizeY
        {
            get { return sizeY; }
            set { sizeY = value; }
        }

        public Point TopLeft
        {
            get { return topLeft; }
            private set { topLeft = value; }
        }

        public Point TopRight
        {
            get { return topRight; }
            private set { topRight = value; }
        }

        public Point BottomLeft
        {
            get { return bottomLeft; }
            private set { bottomLeft = value; }
        }

        public Point BottomRight
        {
            get { return bottomRight; }
            private set { bottomRight = value; }
        }

        #endregion

        #region Constructor

        public Grid(int iSizeX, int iSizeY)
        {
            this.sizeX = iSizeX;
            this.sizeY = iSizeY;
            this.gridArea = new Point[iSizeX, iSizeY];

            this.topLeft = new Point(0, 0);
            this.topRight = new Point(sizeX - 1, 0);
            this.bottomLeft = new Point(0, sizeY - 1);
            this.bottomRight = new Point(sizeX - 1, sizeY - 1);

            InitializeGrid();
        }

        #endregion

        #region Methods

        private void InitializeGrid()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    gridArea[x, y] = new Point(x, y);
                }
            }
        }

        public Point GetPosition(int indexX, int indexY)
        {
            return gridArea[indexX, indexY];
        }

        #endregion

    }
}
