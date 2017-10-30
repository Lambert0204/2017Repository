using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Domain;
using TurtleChallenge.Domain.Enum;

namespace TurtleChallenge.Application.Transform
{
    public class TransformText : ITransform
    {
        public BoardSetting IntoBoardSetting(string param)
        {
            string[] boardSize = param.ToString().Split(' ');
            if (boardSize.Count() != 2)
                throw new Exception("BoardSettings: Invalid point format.");

            return BoardSetting.SetBoardSize(Convert.ToInt32(boardSize[0]), Convert.ToInt32(boardSize[1]));
        }

        public ICollection<Mine> IntoMines(string param)
        {
            string[] mines = param.ToString().Split(' ');
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

        public ExitPoint IntoExitPoint(string param)
        {
            string[] exitPoint = param.ToString().Split(' ');
            if (exitPoint.Count() != 2)
                throw new Exception("ExitPoint: Invalid point format.");

            return ExitPoint.SetExitPoint(Convert.ToInt32(exitPoint[0]), Convert.ToInt32(exitPoint[1]));
        }

        public CurrentPoint IntoCurrentPoint(string param)
        {
            string[] currentPoint = param.ToString().Split(' ');
            if (currentPoint.Count() != 3)
                throw new Exception("CurrentPoint: Invalid point format.");

            var setCurrentPoint = CurrentPoint.SetCurrentPoint(Convert.ToInt32(currentPoint[0]), Convert.ToInt32(currentPoint[1]));

            setCurrentPoint.NextPoint = DefineDirection(currentPoint[2]);

            return setCurrentPoint;

        }

        private NextPoint DefineDirection(string text)
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
