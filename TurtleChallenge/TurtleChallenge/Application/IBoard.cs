using System.Collections.Generic;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public interface IBoard 
    {
        void CreateBoard();
        void Play();
        void ReadSequences();
        void Evaluate(string nextMove);
    }
}
