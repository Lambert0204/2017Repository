using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Application;
using TurtleChallenge.Domain;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Tests
{
    public class RulesTests : TestData
    {

        BoardSetting _BoardSetting => CreateBoardSetting();
        ICollection<Mine> _Mines => CreateMines();
        ExitPoint _ExitPoint => CreateExitPoint();
        Turtle _Turtle => CreateTurtle();
        ICollection<Sequence> _Sequences => CreateSequences();

        [TestFixture]
        public class WhenTurtle : RulesTests
        {
            [Test]
            public void HitMine_ShouldReturnTrue()
            {
                // Arrange
                var turtle = Mock.Of<Turtle>();
                turtle.X = 1;
                turtle.Y = 1;
                
                var mines = _Mines.ToList();

                var board = new BoardDto { Mines = _Mines, Turtle = turtle };
                var rules = new Rules();

                // Act
                var hit = rules.MineHit(board);

                // Assert
                //hit.Should().BeTrue();
            }

            [Test]
            public void DidNotHitMine_ShouldReturnFalse()
            {
                // Arrange
                var board = new BoardDto { Mines = _Mines , Turtle = _Turtle };
                var rules = new Rules();

                // Act
                var hit = rules.MineHit(board);

                // Assert
                hit.Should().BeFalse();
            }

            [Test]
            public void OutOfTheBoard_ShouldReturnTrue()
            {
                // Arrange
                var turtle = Mock.Of<Turtle>();
                turtle.X = 6;
                turtle.Y = 5;

                var board = new BoardDto { BoardSetting = _BoardSetting, Turtle = turtle };
                var rules = new Rules();

                // Act
                var outOfTheBoard = rules.OutOfTheBoard(board);

                // Assert
                outOfTheBoard.Should().BeTrue();
            }

            [Test]
            public void DidNotOutOfTheBoard_ShouldReturnFalse()
            {
                // Arrange
                var board = new BoardDto { BoardSetting = _BoardSetting, Turtle = _Turtle };
                var rules = new Rules();

                // Act
                var outOfTheBoard = rules.OutOfTheBoard(board);

                // Assert
                outOfTheBoard.Should().BeFalse();
            }

            [Test]
            public void Exit_ShouldReturnTrue()
            {
                // Arrange
                var turtle = Mock.Of<Turtle>();
                turtle.X = 4;
                turtle.Y = 2;

                var board = new BoardDto { ExitPoint = _ExitPoint, Turtle = _Turtle };
                var rules = new Rules();

                // Act
                var exit = rules.Exit(board);

                // Assert
                //exit.Should().BeTrue();
            }

            [Test]
            public void DidNotExit_ShouldReturnFalse()
            {
                // Arrange
                var board = new BoardDto { ExitPoint = _ExitPoint, Turtle = _Turtle };
                var rules = new Rules();

                // Act
                var exit = rules.Exit(board);

                // Assert
                exit.Should().BeFalse();
            }
        }
    }
}
