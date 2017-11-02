using System;
using TurtleChallenge.Domain.Interface;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain
{
    public class Distance
    {
        public int ToX { get; set; }
        public int ToY { get; set; }

        public void SetDistance(Direction direction)
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
