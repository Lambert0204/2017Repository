using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain.Interface
{
    public interface IDirection
    {
        void Set(Direction direction);
        void Rotate(Rotation rotate);
    }
}
