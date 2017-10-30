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

            var a = new TransformText();

            var b = new BoardApp(a);

            var board = b.CreateBoardByFile(ConfigurationManager.AppSettings["FilePath"]);

            Console.ReadLine();
        }
    }
}
