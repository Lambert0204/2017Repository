using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Application
{
    public interface IRules
    {
        void CheckStatus();
        void MineHit();
        void Exit();
        void OutOfTheBoard();
        void StillInDanger();
    }
}
