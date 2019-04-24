using System;

namespace SnakeGame
{
    class Snakebody
    {
        string _bodyType;
        int _bodyTypeNumber;

        public Snakebody(string body, int number)
        {
            _bodyType = body;
            _bodyTypeNumber = number;
        }

        public int BodyLength()
        {
            return _bodyTypeNumber;
        }
    }
}