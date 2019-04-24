using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var snakeBody = new Snakebody("*", 4);
            var snakeHead = new Snakehead("X");

            DrawSnake(snakeBody, snakeHead);

            Console.ReadLine();
        }

        private static void DrawSnake(Snakebody body, Snakehead head)
        {
            for (int i = 0; i < body; i++)
            {
                Console.Write($"{body}");
            }
        }
    }
}
