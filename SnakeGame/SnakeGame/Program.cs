using System;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    partial class Program
    {
        private static Snake _snake = new Snake(10);
        private static Food _food = new Food();
        private static int _score = 0;


        static void Main(string[] args)
        {
            int x = 1;
            object y = x;
            object c = ConsoleColor.Green;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            _food.GenerateFood(_snake);

            while (true)
            {
                ProcessInput();
                _snake.Move();
                CheckFoodEat();
                if (IsDead()) break;
                Redraw();
                Thread.Sleep(50);
            }
            WriteGameOver();
            Console.ReadLine();
        }

        private static void Redraw()
        {
            Console.Clear();
            DrawScore();
            PrintRightWall();
            DrawFood();
            DrawSnake();
        }

        private static void CheckFoodEat()
        {
            if (_snake.Head.X == _food.X && _snake.Head.Y == _food.Y)
            {
                _snake.Grow();
                _food.GenerateFood(_snake);
                _score += 1;
            }
        }

        private static void DrawSnake()
        {
            foreach (var snakepiece in _snake.Body)
            {
                Console.SetCursorPosition(snakepiece.X, snakepiece.Y);
                Console.Write('#');
            }
        }

        private static void DrawFood()
        {
            Console.SetCursorPosition(_food.X, _food.Y);
            Console.Write('o');
        }

        public static void ProcessInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            var keyPressed = Console.ReadKey(true).Key;

            if (_snake.Direction == Direction.Up && keyPressed == ConsoleKey.DownArrow) return;
            if (_snake.Direction == Direction.Down && keyPressed == ConsoleKey.UpArrow) return;
            if (_snake.Direction == Direction.Left && keyPressed == ConsoleKey.RightArrow) return;
            if (_snake.Direction == Direction.Right && keyPressed == ConsoleKey.LeftArrow) return;

            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                    _snake.Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _snake.Direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    _snake.Direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _snake.Direction = Direction.Right;
                    break;
            }
        }

        public static bool IsDead()
        {
            if (_snake.Head.X < 0 || _snake.Head.X > 60) return true;
            if (_snake.Head.Y < 0 || _snake.Head.Y >= 25) return true;
            var headlessBody = _snake.Body.Except(new[] { _snake.Head });
            if (headlessBody.Any(piece => piece.X == _snake.Head.X && piece.Y == _snake.Head.Y)) return true;

            return false;
        }

        public static void WriteGameOver()
        {
            Console.SetCursorPosition(36, 12);
            Console.WriteLine("Game over");
        }

        public static void PrintRightWall()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition(61, i);
                Console.Write("|");
            }
        }

        public static void DrawScore()
        {
            Console.SetCursorPosition(68, 12);
            Console.Write($"Score: {_score}");
        }
    }
}
