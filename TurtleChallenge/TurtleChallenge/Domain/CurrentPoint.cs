using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain
{
    public class CurrentPoint
    {
        protected CurrentPoint()
        {
            NextPoint = new NextPoint();
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public NextPoint NextPoint { get; set; }
        public static CurrentPoint SetCurrentPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            return new CurrentPoint
            {
                PositionX = x,
                PositionY = y
            };
        }

        public CurrentPoint Move()
        {
            this.PositionX += NextPoint.StepsOnX;
            this.PositionY += NextPoint.StepsOnY;

            return this;
        }
    }
}
