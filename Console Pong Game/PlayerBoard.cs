using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Console_Pong_Game
{
    class PlayerBoard : Board
    {
        public PlayerBoard(ConsoleKey side) : base()
        {
            if(side == ConsoleKey.L)
            {
                position = new Point(3, Console.WindowHeight / 2 - 1);
                
            }
            else
            {
                position = new Point(Console.WindowWidth - 4, Console.WindowHeight / 2 - 1);
            }
            
        }
        public override void update(int deltaTimeMS)
        {
            timeSinceLastMove += deltaTimeMS;
            if (timeBetweenMoves < timeSinceLastMove)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            previousPosition = position;
                            position = new Point(position.X, position.Y - 1);
                            unDraw();
                            break;
                        case ConsoleKey.S:
                            previousPosition = position;
                            position = new Point(position.X, position.Y + 1);
                            unDraw();
                            break;
                    }

                }
                base.update(deltaTimeMS);
                timeSinceLastMove -= timeBetweenMoves;
            }
        }
    }
}
