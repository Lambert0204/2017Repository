using System.Collections.Generic;
using TurtleChallenge.Domain;

namespace TurtleChallenge.Application
{
    public class Rules : IRules
    {
        public bool MineHit(ICollection<Mine> m, Turtle t)
        {
            foreach (var mine in m)
            {
                if (t.IsEqualToTurtle(mine.X, mine.Y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Exit(ExitPoint e, Turtle t)
        {
            if (t.IsEqualToTurtle(e.X, e.Y))
                return true;

            return false;
        }

        public bool OutOfTheBoard(BoardSetting bs, Turtle t)
        {
            if (t.X >= bs.Length || t.Y >= bs.Width || t.X < 0 || t.Y < 0)
                return true;

            return false;
        }
    }
}
