using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Console_Pong_Game
{
    abstract class Board
    {
        Point _position;
        Point _previousPosition;
        protected int timeSinceLastMove;
        protected int timeBetweenMoves;
        public Board()
        {
            timeBetweenMoves = 110;
            timeSinceLastMove = 0;
        }
        public Point position
        {
            get
            {
                return _position;

            }
            set
            {
                if (value.Y < Console.WindowHeight - 5 && value.Y > 4)
                    _position = value;
                return;
            }

        }
        public Point previousPosition
        {
            get
            {
                return _previousPosition;

            }
            set
            {
                if (value.Y < Console.WindowHeight - 5 && value.Y > 4)
                    _previousPosition = value;
                return;
            }

        }
        virtual public void update(int deltaTimeMS)
        {

        }
        virtual public void draw()
        {
            Console.SetCursorPosition(position.X, position.Y - 1);
            Console.Write('|');
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('|');
            Console.SetCursorPosition(position.X, position.Y + 1);
            Console.Write('|');
        }
        virtual public void unDraw()
        {
            Console.SetCursorPosition(previousPosition.X, previousPosition.Y - 1);
            Console.Write(' ');
            Console.SetCursorPosition(previousPosition.X, previousPosition.Y);
            Console.Write(' ');
            Console.SetCursorPosition(previousPosition.X, previousPosition.Y + 1);
            Console.Write(' ');
        }
    }
}
