﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Domain;

namespace TurtleChallenge.DTO
{
    public class Board
    {
        public BoardSetting BoardSetting { get; set; }
        public ICollection<Mine> Mines { get; set; }
        public ExitPoint ExitPoint { get; set; }
        public CurrentPoint CurrentPoint { get; set; }
    }
}
