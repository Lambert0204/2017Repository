using System;
using TurtleChallenge.Domain.Interface;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain
{
    public class Point : BasePoint
    {
        #region Point
        protected override void Set(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override void Step(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        protected override bool IsEqual(int x, int y)
        {
            if (this.X == x && this.Y == y)
                return true;

            return false;
        }
        #endregion Point

        #region Direction
        protected override void Set(Direction direction)
        {
            if (!IgnoreDirection)
                Direction = direction;
        }

        protected override void Rotate(Rotation rotate)
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
