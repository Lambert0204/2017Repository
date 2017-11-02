using System;

namespace TurtleChallenge.Domain
{
    public class Mine : Point
    {
        protected Mine()
        {
            IgnoreDirection = true;
        }

        public static Mine SetMinePoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid mine point settings. It only accepts positive integers. ");

            return new Mine
            {
                X = x,
                Y = y
            };
        }
    }
}
