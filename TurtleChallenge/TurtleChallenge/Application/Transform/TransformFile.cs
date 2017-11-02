using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TurtleChallenge.Common;
using TurtleChallenge.Domain;
using TurtleChallenge.Helper;

namespace TurtleChallenge.Application.Transform
{
    public class TransformFile : ITransform
    {
        private string[] Lines { get; set; }

        public TransformFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("File path does not exists.");

            Lines = File.ReadAllLines(filePath);
        }

        public BoardSetting IntoBoardSetting()
        {
            string[] boardSize = Lines[0].SplitInfo();

            if (!boardSize.IsFormatCorrect(2))
                throw new Exception("BoardSettings: Invalid point format.");

            return BoardSetting.SetBoardSize(boardSize[0].ToInt(), boardSize[1].ToInt());
        }

        public ICollection<Mine> IntoMines()
        {
            string[] mines = Lines[1].SplitInfo();

            var setMines = new List<Mine>();

            foreach (var mine in mines)
            {
                string[] m = mine.GetAxis();

                if (!m.IsFormatCorrect(2))
                    throw new Exception("Mines: Invalid point format.");

                setMines.Add( Mine.SetMinePoint( m[0].ToInt(), m[1].ToInt() ) );
            }

            return setMines;
        }

        public ExitPoint IntoExitPoint()
        {
            string[] exitPoint = Lines[2].SplitInfo();

            if (!exitPoint.IsFormatCorrect(2))
                throw new Exception("ExitPoint: Invalid point format.");

            return ExitPoint.SetExitPoint( exitPoint[0].ToInt(), exitPoint[1].ToInt() );
        }

        public Turtle IntoTurtle()
        {
            string[] turtlePoint = Lines[3].SplitInfo();

            if (!turtlePoint.IsFormatCorrect(3))
                throw new Exception("CurrentPoint: Invalid point format.");

            return Turtle.Create( turtlePoint[0].ToInt(), 
                                     turtlePoint[1].ToInt(), 
                                     turtlePoint[2].DefineDirection() );
        }

        public ICollection<Sequence> IntoSequences()
        {
            var sequences = new List<Sequence>();

            var lines = Lines.ToList().GetRange(4, Lines.Count() - 4);

            if (lines.Count() == 0)
                throw new Exception("No given sequence(s).");

            var sequenceNumber = Constants.InitSequenceNumber;

            foreach (var line in lines)
                sequences.Add( Sequence.SetSquence(++sequenceNumber, line.SplitInfo()) );

            return sequences;
        }
    }
}
