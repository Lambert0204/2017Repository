using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain
{
    public class Mine
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public static Mine SetMinePoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid mine point settings. It only accepts positive integers. ");

            return new Mine
            {
                PositionX = x,
                PositionY = y
            };
        }
    }
}
