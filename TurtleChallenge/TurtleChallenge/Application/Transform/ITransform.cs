using System.Collections.Generic;
using TurtleChallenge.Domain;

namespace TurtleChallenge.Application.Transform
{
    public interface ITransform
    {
        BoardSetting IntoBoardSetting();
        ICollection<Mine> IntoMines();
        ExitPoint IntoExitPoint();
        Turtle IntoTurtle(); //Note: This will also be the starting point.
    }
}
