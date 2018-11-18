using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Console_Pong_Game
{
    class OpponentBoard : Board
    {
        public OpponentBoard(ConsoleKey side) : base()
        {
            if (side == ConsoleKey.L)
            {
                position = new Point(Console.WindowWidth - 4, Console.WindowHeight / 2 - 1);
            }
            else
            {
                position = new Point(3, Console.WindowHeight / 2 - 1);
            }
        }
        public void update(int deltaTimeMS, Ball b)
        {
            timeSinceLastMove += deltaTimeMS;
            if (timeBetweenMoves < timeSinceLastMove)
            {
                previousPosition = position;
                unDraw();
                if (position.Y < b.ballPosition.Y)
                {
                    position = new Point(position.X, position.Y + 1);
                }
                if (position.Y > b.ballPosition.Y)
                {
                    position = new Point(position.X, position.Y - 1);
                }

                timeSinceLastMove -= timeBetweenMoves;

                base.update(deltaTimeMS);
            }
        }
    }
}
