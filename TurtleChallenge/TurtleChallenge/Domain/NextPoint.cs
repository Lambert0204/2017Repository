using System;
using TurtleChallenge.Domain.Enum;

namespace TurtleChallenge.Domain
{
    public class NextPoint
    {
        public int StepsOnX { get; set; }
        public int StepsOnY { get; set; }
        public Direction CurrentDirection { get; set; }

        public static NextPoint SetDirection(Direction direction)
        {
            var nextPoint = new NextPoint();

            nextPoint.SetNoOfStepsToTheNextDirection(direction);

            return nextPoint;
        }

        public void SetNoOfStepsToTheNextDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    this.StepsOnX = 0;
                    this.StepsOnY = -1;
                    break;
                case Direction.East:
                    this.StepsOnX = 1;
                    this.StepsOnY = 0;
                    break;
                case Direction.West:
                    this.StepsOnX = -1;
                    this.StepsOnY = 0;
                    break;
                case Direction.South:
                    this.StepsOnX = 0;
                    this.StepsOnY = 1;
                    break;
                default:
                    throw new Exception("Invalid Direction.");
            }

            this.CurrentDirection = direction;

        }

        public void Rotate(Rotation rotate)
        {
            switch (rotate)
            {
                case Rotation.Right:
                    if (this.CurrentDirection == Direction.West)
                        this.CurrentDirection = Direction.North;
                    else
                        this.CurrentDirection++;
                    break;
                case Rotation.Left:
                    if (this.CurrentDirection == Direction.North)
                        this.CurrentDirection = Direction.West;
                    else
                        this.CurrentDirection--;
                    break;
                default:
                    throw new Exception("Invalid Rotation.");
            }

            this.SetNoOfStepsToTheNextDirection(this.CurrentDirection);
        }
    }
}
