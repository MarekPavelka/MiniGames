using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public int Length { get; }
        public List<SnakePiece> Body { get; }
        public Direction Direction { get; set; }
        public SnakePiece Head => Body.Last();
        public SnakePiece Tail => Body.First();
        private bool _shouldGrow = false;

        public Snake(int number)
        {
            Length = number;
            Body = Enumerable.Range(0, number).Select(offset => new SnakePiece(30 + offset, 12)).ToList(); //list of snakepieces
            Direction = Direction.Right;
        }

        public bool BodyContains(int x, int y)
        {
            return Body.Any(piece => piece.X == x && piece.Y == y);
        }

        public bool Move()
        {

            if (_shouldGrow) _shouldGrow = false;
            else RemoveTail();

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

        private void RemoveTail()
        {
            Body.RemoveAt(0);
        }

        public void Grow()
        {
            _shouldGrow = true;
        }
    }
}