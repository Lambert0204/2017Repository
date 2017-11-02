using System;
using TurtleChallenge.Application.Transform;
using TurtleChallenge.Common;
using TurtleChallenge.Domain.Mapper;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public class Game : IBoard, IRules
    {
        private ITransform Transform;
        private BoardDto Board { get; set; }
        public Game(ITransform _transform)
        {
            Transform = _transform;
        }

        #region BOARD
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

        public void Play()
        {
            this.ReadSequences();
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
                this.Board.Turtle.RotateTurtle(nextMove.DefineRotation());

            else if (nextMove.IsMove())
                this.Board.Turtle.MoveTurtleToNextStep();

            else
                this.Board.Turtle.SetStatus(Constants.UnknownMove);

            CheckStatus();
        }
        #endregion BOARD

        #region RULES
        public void CheckStatus()
        {
            this.OutOfTheBoard();
            this.MineHit();
            this.Exit();
            this.StillInDanger();
        }

        public void MineHit()
        {
            foreach (var mine in this.Board.Mines)
            {
                if (this.Board.Turtle.IsEqualToTurtle(mine.X, mine.Y))
                {
                    this.Board.Turtle.SetStatus(Constants.MineHit);
                    break;
                }
            }
        }

        public void Exit()
        {
            if (this.Board.Turtle.IsEqualToTurtle(this.Board.ExitPoint.X, this.Board.ExitPoint.Y))
                this.Board.Turtle.SetStatus(Constants.Success);
        }

        public void OutOfTheBoard()
        {
            if (this.Board.Turtle.X >= this.Board.BoardSetting.Length ||
                this.Board.Turtle.Y >= this.Board.BoardSetting.Width ||
                this.Board.Turtle.X < 0 || this.Board.Turtle.Y < 0)
                this.Board.Turtle.SetStatus(Constants.WallHit);
        }

        public void StillInDanger()
        {
            if (String.IsNullOrEmpty(this.Board.Turtle.StatusMessage))
                this.Board.Turtle.SetStatus(Constants.StillInDanger);
        }
        #endregion RULES
    }
}
