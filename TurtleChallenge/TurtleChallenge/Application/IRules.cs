using System.Collections.Generic;
using TurtleChallenge.Domain;

namespace TurtleChallenge.Application
{
    public interface IRules
    {
        bool MineHit(ICollection<Mine> m, Turtle t);
        bool Exit(ExitPoint e, Turtle t);
        bool OutOfTheBoard(BoardSetting bs, Turtle p);
    }
}
