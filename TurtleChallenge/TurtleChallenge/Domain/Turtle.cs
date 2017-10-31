using System;
using TurtleChallenge.Domain.Enum;
using TurtleChallenge.Domain.Interface;

namespace TurtleChallenge.Domain
{
    public class Turtle : BasePoint
    {
        protected Turtle()
        {
            IgnoreDirection = false;
            NextStep = new Steps();
        }
        public Steps NextStep { get; set; }

        public static Turtle SetTurtle(int x, int y, Direction direction)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            var point = new Turtle { X = x, Y = y, Direction = direction };

            point.NextStep.SetSteps(direction);

            return point;
        }

        public void RotateTurtle(Rotation rotate)
        {
            this.Rotate(rotate);
            this.NextStep.SetSteps(Direction);
        }

        public void MoveTurtleToNextStep()
        {
            this.Move(NextStep.ToX, NextStep.ToY);
        }
    }
}
