using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain.Interface
{
    public interface IPoint
    {
        void Set(int x, int y);
        void Step(int x, int y);
        bool IsEqual(int x, int y);
    }
}
