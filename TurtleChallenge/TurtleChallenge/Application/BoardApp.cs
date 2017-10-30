using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Application.Text;
using TurtleChallenge.Domain;
using TurtleChallenge.Domain.Enum;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public class BoardApp : IBoardApp
    {
        public Board CreateBoard(string filePath, ITransform transform)
        {
            string[] lines = File.ReadAllLines(filePath);

            return new Board()
            {
                BoardSetting = transform.IntoBoardSetting(lines[0]),
                Mines = transform.IntoMines(lines[1]),
                ExitPoint = transform.IntoExitPoint(lines[2]),
                CurrentPoint = transform.IntoCurrentPoint(lines[3])
            };
        }
    }
}
