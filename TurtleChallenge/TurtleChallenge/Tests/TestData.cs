using Moq;
using System.Collections.Generic;
using TurtleChallenge.Domain;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Tests
{
    public class TestData
    {

        public BoardSetting CreateBoardSetting()
            => Mock.Of<BoardSetting>(side => side.Length == 5 && side.Width == 4);

        public ICollection<Mine> CreateMines()
        {
            var mines = new List<Mine>();
            mines.Add(Mock.Of<Mine>(axis => axis.X == 1 && axis.Y == 1));
            mines.Add(Mock.Of<Mine>(axis => axis.X == 1 && axis.Y == 3));
            mines.Add(Mock.Of<Mine>(axis => axis.X == 3 && axis.Y == 3));
            return mines;
        }

        public ExitPoint CreateExitPoint()
            => Mock.Of<ExitPoint>(axis => axis.X == 4 && axis.Y == 2);

        public Turtle CreateTurtle()
        {
            var mockTurtle = Mock.Of<Turtle>(obj => obj.X == 0 &&
                                        obj.Y == 1 &&
                                        obj.Direction == Direction.North &&
                                        obj.StatusMessage == string.Empty);

            mockTurtle.Distance = Mock.Of<Distance>(obj => obj.ToX == 0 &&
                                        obj.ToY == -1);

            return mockTurtle;
        }

        public ICollection<Sequence> CreateSequences()
        {
            string[] seqList1 = { "M", "R", "M", "M", "M", "M", "R", "M", "M" };
            string[] seqList2 = { "R", "M", "M", "M" };
            string[] seqList3 = { "L", "L", "M", "L", "M", "M", "M", "M" };
            string[] seqList4 = { "M", "R", "M", "M", "M" };

            var sequence = new List<Sequence>();

            sequence.Add(Mock.Of<Sequence>(seq => seq.SequenceNo == 1 && seq.SequenceList == seqList1));
            sequence.Add(Mock.Of<Sequence>(seq => seq.SequenceNo == 2 && seq.SequenceList == seqList2));
            sequence.Add(Mock.Of<Sequence>(seq => seq.SequenceNo == 3 && seq.SequenceList == seqList3));
            sequence.Add(Mock.Of<Sequence>(seq => seq.SequenceNo == 4 && seq.SequenceList == seqList4));

            return sequence;
        }
    }
}
