using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain
{
    public class BoardSetting
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public static BoardSetting SetBoardSize(int length, int width)
        {
            if (length < 0 || width < 0)
                throw new Exception("Invalid board size settings. It only accepts positive integers.");

            return new BoardSetting
            {
                Length = length,
                Width = width
            };
        }
    }
}
