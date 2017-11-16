namespace TurtleChallenge.Domain.Interface
{
    public interface IPoint : IDirection
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
