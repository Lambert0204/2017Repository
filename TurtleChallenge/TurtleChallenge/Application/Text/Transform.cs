using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Domain;
using TurtleChallenge.Domain.Enum;

namespace TurtleChallenge.Application.Text
{
    public class Transform : ITransform
    {
        public BoardSetting IntoBoardSetting(string text)
        {
            string[] boardSize = text.Split(' ');
            if (boardSize.Count() != 2)
                throw new Exception("BoardSettings: Invalid point format.");

            return BoardSetting.SetBoardSize(Convert.ToInt32(boardSize[0]), Convert.ToInt32(boardSize[1]));
        }

        public ICollection<Mine> IntoMines(string text)
        {
            string[] mines = text.Split(' ');
            var setMines = new List<Mine>();
            foreach (var mine in mines)
            {
                string[] m = mine.Split(',');
                if (m.Count() != 2)
                    throw new Exception("Mines: Invalid point format.");

                setMines.Add(Mine.SetMinePoint(Convert.ToInt32(m[0]), Convert.ToInt32(m[1])));
            }

            return setMines;
        }

        public ExitPoint IntoExitPoint(string text)
        {
            string[] exitPoint = text.Split(' ');
            if (exitPoint.Count() != 2)
                throw new Exception("ExitPoint: Invalid point format.");

            return ExitPoint.SetExitPoint(Convert.ToInt32(exitPoint[0]), Convert.ToInt32(exitPoint[1]));
        }

        public CurrentPoint IntoCurrentPoint(string text)
        {
            string[] currentPoint = text.Split(' ');
            if (currentPoint.Count() != 3)
                throw new Exception("CurrentPoint: Invalid point format.");

            var setCurrentPoint = CurrentPoint.SetCurrentPoint(Convert.ToInt32(currentPoint[0]), Convert.ToInt32(currentPoint[1]));

            return setCurrentPoint;

        }

        public NextPoint IntoDirection(string text)
        {
            if (text.Length != 1)
                throw new Exception("CurrentPoint: Invalid direction format.");

            switch (text)
            {
                case "N":
                    return NextPoint.SetDirection(Direction.North);
                case "E":
                    return NextPoint.SetDirection(Direction.East);
                case "S":
                    return NextPoint.SetDirection(Direction.South);
                case "W":
                    return NextPoint.SetDirection(Direction.West);
                default:
                    throw new Exception("NextPoint: Invalid character format.");
            }
        }

    }
}
