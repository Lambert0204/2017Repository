using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain
{
    public class ExitPoint
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public static ExitPoint SetExitPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid exit point settings. It only accepts positive integers. ");

            return new ExitPoint
            {
                PositionX = x,
                PositionY = y
            };
        }
    }
}
