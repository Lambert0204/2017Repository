using System.IO;
using TurtleChallenge.Application.Transform;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public class BoardApp : IBoardApp
    {
        private ITransform Transform;

        public BoardApp(ITransform _transform)
        {
            Transform = _transform;
        }

        public Board CreateBoard()
        {
            return new Board()
            {
                BoardSetting = Transform.IntoBoardSetting(),
                Mines = Transform.IntoMines(),
                ExitPoint = Transform.IntoExitPoint(),
                Turtle = Transform.IntoTurtle()
            };
        }

    }
}
