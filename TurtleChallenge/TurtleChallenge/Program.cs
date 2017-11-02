using System;
using System.Configuration;
using TurtleChallenge.Application;
using TurtleChallenge.Application.Transform;

namespace TurtleChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = ConfigurationManager.AppSettings["FilePath"];

            var file = new TransformFile(filePath);
            var rules = new Rules();

            var game = new Game(file, rules);
            game.CreateBoard();
            game.ReadSequences();

            Console.ReadLine();
        }
    }
}
