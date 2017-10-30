using System.Collections.Generic;
using TurtleChallenge.Domain;

namespace TurtleChallenge.Application.Transform
{
    public interface ITransform
    {
        BoardSetting IntoBoardSetting(string param);
        ICollection<Mine> IntoMines(string param);
        ExitPoint IntoExitPoint(string param);
        CurrentPoint IntoCurrentPoint(string param); //Note: This will also be the starting point.
    }
}
