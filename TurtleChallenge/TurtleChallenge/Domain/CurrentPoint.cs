using System;

namespace TurtleChallenge.Domain
{
    public class CurrentPoint : BasePoint
    {
        public NextPoint NextPoint { get; set; }

        public static CurrentPoint SetCurrentPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            return new CurrentPoint
            {
                X = x,
                Y = y
            };
        }

        public void MoveForward()
        {
            this.Move(NextPoint.StepsOnX, NextPoint.StepsOnY);
        }
    }
}
