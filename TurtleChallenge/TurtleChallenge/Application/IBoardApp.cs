using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Application.Text;
using TurtleChallenge.Domain;
using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public interface IBoardApp
    {
        Board CreateBoard(string filePath, ITransform info);
    }
}
