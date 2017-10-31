using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Domain.Enum;

namespace TurtleChallenge.Domain.Interface
{
    public abstract class BasePoint : IPoint, IDirection
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected bool IgnoreDirection { get; set; }
        protected Direction Direction { get; set; }
        public void Move(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        public void Set(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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
    }
}
