using System;
using System.Configuration;
using TurtleChallenge.Application;
using TurtleChallenge.Application.Transform;
using TurtleChallenge.Helper;

namespace TurtleChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = ConfigurationManager.AppSettings["FilePath"];
            var file = new TransformFile(filePath);

            var game = new Game(file);
            game.CreateBoard();
            game.Play();

            Console.ReadLine();
        }
    }
}
