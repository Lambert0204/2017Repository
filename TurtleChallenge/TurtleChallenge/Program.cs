using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Application;
using TurtleChallenge.Application.Text;
using TurtleChallenge.Domain;
using TurtleChallenge.Domain.Enum;
using TurtleChallenge.DTO;

namespace TurtleChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = @"C:\Users\USER\Documents\GitHub\2017\TurtleChallenge\TurtleChallenge\TurtleChallenge.txt";

            var b = new BoardApp();
            var c = new Transform();
            var board = b.CreateBoard(filePath, c);



            Console.ReadLine();
        }
    }
}
