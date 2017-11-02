using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enum;

namespace TurtleChallenge.Common
{
    public static class Definitions
    {
        public static Direction DefineDirection(this string text)
        {
            if (text.Length != 1)
                throw new Exception("Direction: Invalid direction format.");

            switch (text)
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new Exception("Direction: Invalid character format.");
            }
        }

        public static Rotation DefineRotation(this string text)
        {
            if (text.Length != 1)
                throw new Exception("Rotation: Invalid direction format.");

            switch (text)
            {
                case "R":
                    return Rotation.Right;
                case "L":
                    return Rotation.Left;
                default:
                    throw new Exception("Rotation: Invalid character format.");
            }
        }

        public static bool IsRotation(this string text)
        {
            if (text == "R" || text == "L")
                return true;

            return false;
        }

        public static bool IsMove(this string text)
        {
            if (text == "M")
                return true;

            return false;
        }
    }
}
