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
        void Move(int x, int y);
    }
}
