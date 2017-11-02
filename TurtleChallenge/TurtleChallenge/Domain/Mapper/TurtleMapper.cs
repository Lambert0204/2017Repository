using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain.Mapper
{
    public static class TurtleMapper 
    {
        public static Turtle Map(this Turtle turtle)
        {
            var map = Turtle.Create(turtle.X, turtle.Y, turtle.Direction);
            map.Distance.SetDistance(turtle.Direction);
            map.SetStatus(String.Empty);
            return map;
        }
    }
}
