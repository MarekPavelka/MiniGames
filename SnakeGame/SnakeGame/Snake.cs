using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SnakeGame
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    };

    class Snake
    {
        char _bodyType;
        public int Length { get; }
        public List<SnakePiece> Body { get; set; }
        public Direction Direction { get; set; }
        public SnakePiece Head => Body.Last();
        public SnakePiece Tail => Body.First();

        public Snake(char body, int number)
        {
            _bodyType = body;
            Length = number;
            Body = Enumerable.Range(0, number).Select(offset => new SnakePiece(30 + offset, 12)).ToList(); //list of snakepieces
            Direction = Direction.Right;
        }

        public bool Move()
        {
           
            Body.RemoveAt(0); // remove tail

            int newHeadX = Head.X;
            int newHeadY = Head.Y;

            if (Direction == Direction.Right) newHeadX += 1;
            if (Direction == Direction.Left) newHeadX -= 1;
            if (Direction == Direction.Up) newHeadY -= 1;
            if (Direction == Direction.Down) newHeadY += 1;

            var newHead = new SnakePiece(newHeadX, newHeadY);
            Body.Add(newHead);

            return true; // todo colisions
        }
    }
}