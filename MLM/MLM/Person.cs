using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM
{
    class Person
    {

        #region Enum

        enum Direction: int
        {
            INVALID = -1,
            Up = 0,
            Right = 1,
            Left = 2,
            Down = 3,
            COUNT = 4
        }

        #endregion

        #region Variables

        private Point position;
        private bool isSaleman;

        #endregion

        #region Properties

        public bool IsSalesman
        {
            get { return isSaleman; }
            set { isSaleman = value; }
        }

        #endregion

        #region Constructor

        public Person()
        {
        }

        public Person(int positionX, int positionY)
        {
            this.position = new Point(positionX, positionY);
        }

        public Person(int positionX, int positionY, bool isSalesman)
        {
            this.position = new Point(positionX, positionY);
            this.isSaleman = isSalesman;
        }

        #endregion

        #region Methods

        public void MoveSalesman(Grid grid)
        {
            Random randomDirection = new Random();
            Direction newDirection = Direction.INVALID;
            bool isMoveValid = false;
            while (!isMoveValid)
            {
                newDirection = (Direction) randomDirection.Next((int) Direction.COUNT);
                switch (newDirection)
                {
                    case Direction.Up:
                        if (IsMoveValid(grid, 0, -1))
                        {
                            position.Y -= 1;
                            isMoveValid = true;
                        }
                        break;
                    case Direction.Right:
                        if (IsMoveValid(grid, 1, 0))
                        {
                            position.X += 1;
                            isMoveValid = true;
                        }
                        break;
                    case Direction.Left:
                        if (IsMoveValid(grid, -1, 0))
                        {
                            position.X -= 1;
                            isMoveValid = true;
                        }
                        break;
                    case Direction.Down:
                        if (IsMoveValid(grid, 0, 1))
                        {
                            position.Y += 1;
                            isMoveValid = true;
                        }
                        break;
                }
            }
        }

        private bool IsMoveValid(Grid grid, int moveX, int moveY)
        {
            if (moveX == 1)
            {
                // Salesman can move downwards.
                return (position.X + 1) > 0 && (position.X + 1) < grid.SizeX - 1;
            } 
            else if (moveX == -1)
            {
                // Salesman can move upwards.
                return (position.X - 1) > 0 && (position.X - 1) < grid.SizeX - 1;
            }
            else if (moveY == 1)
            {
                // Salesman can move to the right.
                return (position.Y + 1) > 0 && (position.Y + 1) < grid.SizeY - 1;
            }
            else if (moveY == -1)
            {
                // Salesman can move to the left.
                return (position.Y - 1) > 0 && (position.Y - 1) < grid.SizeY - 1;
            }
            else
            {
                return false;
            }

        }

        public void SetPosition(int newPositionX, int newPositionY)
        {
            position.X = newPositionX;
            position.Y = newPositionY;
        }

        public Point GetPosition()
        {
            return position;
        }

        public int GetPositionX()
        {
            return position.X;
        }

        public int GetPositionY()
        {
            return position.Y;
        }

        #endregion

    }
}
