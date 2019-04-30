using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            object y = x;
            object c = ConsoleColor.Green;


            Console.ForegroundColor = ConsoleColor.Green;
            var snake = new Snake('*', 4);
            var isAlive = true;

            while (isAlive)
            {
                snake.Move();
                Console.Clear();
                DrawSnake(snake);
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }

        private static void DrawSnake(Snake snake)
        {
            foreach (var snakepiece in snake.Body)
            {
                Console.SetCursorPosition(snakepiece.X, snakepiece.Y);
                Console.Write('*');
            }
        }
    }
}
