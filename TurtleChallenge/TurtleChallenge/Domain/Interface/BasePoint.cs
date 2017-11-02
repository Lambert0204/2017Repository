using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain.Interface
{
    public abstract class BasePoint : IPoint, IDirection
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IgnoreDirection { get; set; }
        public Direction Direction { get; set; }

        #region Point
        public void Set(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Step(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }
        public bool IsEqual(int x, int y)
        {
            if (this.X == x && this.Y == y)
                return true;

            return false;
        }
        #endregion Point

        #region Direction
        public void Set(Direction direction)
        {
            if(!IgnoreDirection)
                Direction = direction;
        }

        public void Rotate(Rotation rotate)
        {
            if (!IgnoreDirection)
                switch (rotate)
                {
                    case Rotation.Right:
                        if (this.Direction == Direction.West)
                            this.Direction = Direction.North;
                        else
                            this.Direction++;
                        break;
                    case Rotation.Left:
                        if (this.Direction == Direction.North)
                            this.Direction = Direction.West;
                        else
                            this.Direction--;
                        break;
                    default:
                        throw new Exception("Invalid Rotation.");
                }
        }
        #endregion Direction

    }
}
