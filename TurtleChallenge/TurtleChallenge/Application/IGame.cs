namespace TurtleChallenge.Application
{
    public interface IGame
    {
        void CreateBoard();
        void ReadSequences();
        void Evaluate(string nextMove);
    }
}
