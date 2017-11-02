using System;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain
{
    public class Turtle : Point
    {
        protected Turtle()
        {
            IgnoreDirection = false;
            Distance = new Distance();
        }

        public Distance Distance { get; set; }
        public string StatusMessage { get; set; }

        public static Turtle Create(int x, int y, Direction direction)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            var point = new Turtle { X = x, Y = y, Direction = direction };

            point.Distance.SetDistance(direction);

            return point;
        }

        public void RotateTurtle(Rotation rotate)
        {
            this.Rotate(rotate);

            this.Distance.SetDistance(Direction);
        }

        public void MoveTurtleToNextStep()
        {
            this.Step(Distance.ToX, Distance.ToY);
        }

        public void SetStatus(string message)
        {
            this.StatusMessage = message;
        }

        public bool IsEqualToTurtle(int x, int y)
        {
            return this.IsEqual(x, y);
        }
    }
}
