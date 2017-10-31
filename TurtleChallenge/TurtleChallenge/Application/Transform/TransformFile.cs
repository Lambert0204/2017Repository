using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TurtleChallenge.Domain;
using TurtleChallenge.Domain.Enum;
using TurtleChallenge.Helper;

namespace TurtleChallenge.Application.Transform
{
    public class TransformFile : ITransform
    {
        public TransformFile(string filePath)
        {
            FilePath = filePath;

            if (!File.Exists(FilePath))
                throw new System.Exception("File path does not exists.");

            Lines = File.ReadAllLines(FilePath);

        }

        private string FilePath { get; set; }
        private string[] Lines { get; set; }

        public BoardSetting IntoBoardSetting()
        {
            string[] boardSize = Lines[0].Divide();

            if (!boardSize.IsFormatCorrect(2))
                throw new Exception("BoardSettings: Invalid point format.");

            return BoardSetting.SetBoardSize(boardSize[0].ToInt(), boardSize[1].ToInt());
        }

        public ICollection<Mine> IntoMines()
        {
            string[] mines = Lines[1].Divide();

            var setMines = new List<Mine>();

            foreach (var mine in mines)
            {
                string[] m = mine.Split(',');

                if (!m.IsFormatCorrect(2))
                    throw new Exception("Mines: Invalid point format.");

                setMines.Add(
                            Mine.SetMinePoint(m[0].ToInt(), m[1].ToInt())
                            );
            }

            return setMines;
        }

        public ExitPoint IntoExitPoint()
        {
            string[] exitPoint = Lines[2].Divide();

            if (!exitPoint.IsFormatCorrect(2))
                throw new Exception("ExitPoint: Invalid point format.");

            return ExitPoint.SetExitPoint(exitPoint[0].ToInt(), exitPoint[1].ToInt());
        }

        public Turtle IntoTurtle()
        {
            string[] turtlePoint = Lines[3].Divide();

            if (!turtlePoint.IsFormatCorrect(3))
                throw new Exception("CurrentPoint: Invalid point format.");

            return Turtle.SetTurtle(turtlePoint[0].ToInt(), turtlePoint[1].ToInt(), DefineDirection(turtlePoint[2]));
        }

        private Direction DefineDirection(string text)
        {
            if (text.Length != 1)
                throw new Exception("CurrentPoint: Invalid direction format.");

            switch (text)
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new Exception("NextPoint: Invalid character format.");
            }
        }

    }
}
