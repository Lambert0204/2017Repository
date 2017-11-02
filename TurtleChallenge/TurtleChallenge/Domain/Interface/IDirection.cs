using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain.Interface
{
    public interface IDirection
    {
        bool IgnoreDirection { get; set; }
        Direction Direction { get; set; }
    }
}
