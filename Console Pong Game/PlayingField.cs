using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Console_Pong_Game
{
    class PlayingField
    {
        PlayerBoard PB;
        OpponentBoard OP;
        Ball ball;
        ConsoleKey playerSide;
        Stopwatch stopwatch;
        Scores scores;
        

        int topBound = 5;
        int botBound = Console.WindowHeight-5;
        int leftBound = 4;
        int rightBound = Console.WindowWidth-4;

        public PlayingField(ConsoleKey key)
        {
            playerSide = key;
            PB = new PlayerBoard(key);
            OP = new OpponentBoard(key);
            ball = new Ball();
            stopwatch = new Stopwatch();
            scores = new Scores(0, 0, key);
        }
        public void RunField()
        {
            stopwatch.Start();
            long lastUpdateTime = stopwatch.ElapsedMilliseconds;
            
            while (true)
            {
                int deltaTimeMS = (int)(stopwatch.ElapsedMilliseconds - lastUpdateTime);
                lastUpdateTime = stopwatch.ElapsedMilliseconds;

                PB.update(deltaTimeMS);
                OP.update(deltaTimeMS);
                ball.update(deltaTimeMS);

                PB.draw();
                OP.draw();
                ball.draw();

                if(ball.checkHit(PB))
                {
                    scores.update(playerSide);
                }
                if(ball.checkHit(OP))
                {
                    if(playerSide == ConsoleKey.R)
                    {
                        scores.update(ConsoleKey.L);
                    }
                    else
                    {
                        scores.update(ConsoleKey.R);
                    }
                }

                for (int i = 5; i < Console.WindowHeight - 5; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 , i);
                    Console.Write('|');
                }
                scores.draw(playerSide);

            }
        }
    }
}
