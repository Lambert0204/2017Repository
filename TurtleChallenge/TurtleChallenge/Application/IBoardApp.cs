﻿using TurtleChallenge.DTO;

namespace TurtleChallenge.Application
{
    public interface IBoardApp
    {
        Board CreateBoardByFile(string filePath);
    }
}
