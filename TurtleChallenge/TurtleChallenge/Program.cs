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

            var boardApp = new BoardApp(file);

            var board = boardApp.CreateBoard();

            Console.ReadLine();
        }
    }
}
