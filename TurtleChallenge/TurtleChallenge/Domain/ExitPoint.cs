using System;

namespace TurtleChallenge.Domain
{
    public class ExitPoint : Point
    {
        protected ExitPoint()
        {
            IgnoreDirection = true;
        }

        public static ExitPoint SetExitPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            return new ExitPoint { X = x, Y = y };
        }
    }
}
