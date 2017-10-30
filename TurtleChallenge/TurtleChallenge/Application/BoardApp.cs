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

        public Board CreateBoardByFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new System.Exception("File path does not exists.");

            string[] lines = File.ReadAllLines(filePath);

            return new Board()
            {
                BoardSetting = Transform.IntoBoardSetting(lines[0]),
                Mines = Transform.IntoMines(lines[1]),
                ExitPoint = Transform.IntoExitPoint(lines[2]),
                CurrentPoint = Transform.IntoCurrentPoint(lines[3])
            };
        }
    }
}
