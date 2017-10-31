using System;
using TurtleChallenge.Domain.Enum;
using TurtleChallenge.Domain.Interface;

namespace TurtleChallenge.Domain
{
    public class Steps
    {
        protected internal int ToX { get; set; }
        protected internal int ToY { get; set; }

        public void SetSteps(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    this.ToX = 0;
                    this.ToY = -1;
                    break;
                case Direction.East:
                    this.ToX = 1;
                    this.ToY = 0;
                    break;
                case Direction.West:
                    this.ToX = -1;
                    this.ToY = 0;
                    break;
                case Direction.South:
                    this.ToX = 0;
                    this.ToY = 1;
                    break;
                default:
                    throw new Exception("Invalid Direction.");
            }
        }
    }
}
