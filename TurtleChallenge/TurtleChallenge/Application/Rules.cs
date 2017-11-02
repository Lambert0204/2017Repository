using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public class Rules : IRules
    {
        public bool MineHit(BoardDto dto)
        {
            foreach (var mine in dto.Mines)
            {
                if (dto.Turtle.IsEqualToTurtle(mine.X, mine.Y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Exit(BoardDto dto)
        {
            if (dto.Turtle.IsEqualToTurtle(dto.ExitPoint.X, dto.ExitPoint.Y))
                return true;

            return false;
        }

        public bool OutOfTheBoard(BoardDto dto)
        {
            if (dto.Turtle.X >= dto.BoardSetting.Length ||
                dto.Turtle.Y >= dto.BoardSetting.Width ||
                dto.Turtle.X < 0 || dto.Turtle.Y < 0)
                return true;

            return false;
        }
    }
}
