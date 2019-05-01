using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Random _rnd = new Random();

        private readonly List<(int X, int Y)> _allPoints = GenerateAllPoints();

        private static List<(int, int)> GenerateAllPoints()
        {
            var result = new List<(int, int)>();

            for (int x = 0; x < 60; x++)
                for (int y = 0; y < 25; y++)
                    result.Add((x, y));

            return result;
        }

        public void GenerateFood(Snake snake)
        {
            var availablePoints = _allPoints.Where(p => !snake.BodyContains(p.X, p.Y)).ToList();
            var availablePointIndex = _rnd.Next(0, availablePoints.Count);
            var chosenPoint = availablePoints[availablePointIndex];
            X = chosenPoint.X;
            Y = chosenPoint.Y;
        }
    }
}
