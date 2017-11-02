using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public interface IRules
    {
        bool MineHit(BoardDto dto);
        bool Exit(BoardDto dto);
        bool OutOfTheBoard(BoardDto dto);
    }
}
