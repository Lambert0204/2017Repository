using System;
using TurtleChallenge.Application.Transform;
using TurtleChallenge.Common;
using TurtleChallenge.Domain.Mapper;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public class Game : IGame
    {
        public ITransform Transform;
        public IRules Rules;

        public BoardDto Board;

        public Game(ITransform _transform, IRules _rules)
        {
            Transform = _transform;
            Rules = _rules;
        }

        public void CreateBoard()
        {
            this.Board = new BoardDto()
            {
                BoardSetting = Transform.IntoBoardSetting(),
                Mines = Transform.IntoMines(),
                ExitPoint = Transform.IntoExitPoint(),
                InitialTurtle = Transform.IntoTurtle(),
                Turtle = Transform.IntoTurtle(),
                Sequences = Transform.IntoSequences()
            };
        }

        public void ReadSequences()
        {
            foreach (var sequence in this.Board.Sequences)
            {
                foreach (var nextMove in sequence.SequenceList)
                {

                    if (this.Board.Turtle.StatusMessage == Constants.MineHit ||
                        this.Board.Turtle.StatusMessage == Constants.WallHit ||
                        this.Board.Turtle.StatusMessage == Constants.Success ||
                        this.Board.Turtle.StatusMessage == Constants.UnknownMove)
                        break;

                    Evaluate(nextMove);
                }

                Console.WriteLine("Sequence {0}: {1}", sequence.SequenceNo, this.Board.Turtle.StatusMessage);

                this.Board.Turtle = this.Board.InitialTurtle.Map();
            }
        }

        public void Evaluate(string nextMove)
        {
            if (nextMove.IsRotation())
            {
                this.Board.Turtle.RotateTurtle(nextMove.DefineRotation());
                CheckStatus();
            }
            else if (nextMove.IsMove())
            {
                this.Board.Turtle.MoveTurtleToNextStep();
                CheckStatus();
            }
            else
                this.Board.Turtle.SetStatus(Constants.UnknownMove);
        }

        #region RULES

        public void CheckStatus()
        {
            if (Rules.OutOfTheBoard(this.Board))
                this.Board.Turtle.SetStatus(Constants.WallHit);

            else if (Rules.MineHit(this.Board))
                this.Board.Turtle.SetStatus(Constants.MineHit);

            else if (Rules.Exit(this.Board))
                this.Board.Turtle.SetStatus(Constants.Success);

            else
                this.Board.Turtle.SetStatus(Constants.StillInDanger);
        }

        #endregion RULES
    }
}
