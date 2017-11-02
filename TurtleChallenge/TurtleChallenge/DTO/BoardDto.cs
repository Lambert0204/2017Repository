using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Domain;

namespace TurtleChallenge.DTO
{
    public class BoardDto
    {
        public BoardSetting BoardSetting { get; set; }
        public ICollection<Mine> Mines { get; set; }
        public ExitPoint ExitPoint { get; set; }
        public Turtle InitialTurtle { get; set; }
        public Turtle Turtle { get; set; }

        public ICollection<Sequence> Sequences { get; set; }
    }
}
