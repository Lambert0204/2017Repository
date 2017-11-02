using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TurtleChallenge.Application;
using TurtleChallenge.Application.Transform;
using TurtleChallenge.Common;
using TurtleChallenge.Domain;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Tests
{
    public class GameTests : TestData
    {
        public BoardDto _Board
            => new BoardDto
            {
                BoardSetting = _BoardSetting,
                Mines = _Mines,
                ExitPoint = _ExitPoint,
                InitialTurtle = _Turtle,
                Turtle = _Turtle,
                Sequences = _Sequences
            };

        BoardSetting _BoardSetting => CreateBoardSetting();
        ICollection<Mine> _Mines => CreateMines();
        ExitPoint _ExitPoint => CreateExitPoint();
        Turtle _Turtle => CreateTurtle();
        ICollection<Sequence> _Sequences => CreateSequences();


        [TestFixture]
        public class WhenCreatingAnInstance : GameTests
        {
            [Test]
            public void OfAGame_ShouldSetProperties()
            {
                // Arrange
                var transform = new Mock<ITransform>().Object;
                var rules = new Mock<IRules>().Object;

                // Act
                var game = new Game(transform, rules);

                // Assert
                game.Should().NotBeNull();

                game.Transform.Should().NotBeNull();
                game.Transform.ShouldBeEquivalentTo(transform);
                game.Rules.Should().NotBeNull();
                game.Rules.ShouldBeEquivalentTo(rules);
                game.Board.Should().BeNull();
            }
        }

        [TestFixture]
        public class WhenSettingUp : GameTests
        {
            [Test]
            public void TheGame_ShouldCreateBoard()
            {
                // Arrange
                var mockTransForm = new Mock<ITransform>();
                mockTransForm.Setup(x => x.IntoBoardSetting()).Returns(_BoardSetting);
                mockTransForm.Setup(x => x.IntoMines()).Returns(_Mines);
                mockTransForm.Setup(x => x.IntoExitPoint()).Returns(_ExitPoint);
                mockTransForm.Setup(x => x.IntoTurtle()).Returns(_Turtle);
                mockTransForm.Setup(x => x.IntoSequences()).Returns(_Sequences);
                var transform = mockTransForm.Object;

                var rules = new Mock<IRules>().Object;

                var game = new Game(transform, rules);

                // Act
                game.CreateBoard();

                // Assert
                game.Should().NotBeNull();

                game.Transform.Should().NotBeNull();
                game.Transform.ShouldBeEquivalentTo(transform);
                game.Rules.Should().NotBeNull();
                game.Rules.ShouldBeEquivalentTo(rules);
                game.Board.Should().NotBeNull();

                game.Board.BoardSetting.Should().NotBeNull();
                game.Board.Mines.Should().NotBeNull();
                game.Board.ExitPoint.Should().NotBeNull();
                game.Board.InitialTurtle.Should().NotBeNull();
                game.Board.Turtle.Should().NotBeNull();
                game.Board.Sequences.Should().NotBeNull();
            }
        }

        [TestFixture]
        public class WhenPlaying : GameTests
        {
            [Test]
            public void TheGame_ShouldReadSequences()
            {
                // Arrange
                var transform = new Mock<ITransform>().Object;
                var rules = new Mock<IRules>().Object;

                var game = new Game(transform, rules);
                game.Board = _Board;

                // Act
                game.ReadSequences();

                // Assert
                game.Should().NotBeNull();

                game.Transform.Should().NotBeNull();
                game.Transform.ShouldBeEquivalentTo(transform);
                game.Rules.Should().NotBeNull();
                game.Rules.ShouldBeEquivalentTo(rules);
                game.Board.Should().NotBeNull();

                game.Board.Sequences.Should().NotBeNull();
                game.Board.Sequences.Count.Should().Be(_Sequences.Count);
            }
        }
    }
}
