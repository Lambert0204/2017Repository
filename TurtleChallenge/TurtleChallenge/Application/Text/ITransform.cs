using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Domain;

namespace TurtleChallenge.Application.Text
{
    public interface ITransform
    {
        BoardSetting IntoBoardSetting(string text);
        ICollection<Mine> IntoMines(string text);
        ExitPoint IntoExitPoint(string text);
        CurrentPoint IntoCurrentPoint(string text); //Note: This will also be the starting point.
        NextPoint IntoDirection(string text);
    }
}
