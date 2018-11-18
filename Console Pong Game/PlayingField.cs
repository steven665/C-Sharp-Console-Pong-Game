using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Console_Pong_Game
{
    class PlayingField
    {
        PlayerBoard PB;
        OpponentBoard OP;
        //OpponentBoard PB;
        Ball ball;
        ConsoleKey playerSide;
        Stopwatch stopwatch;
        Scores scores;

        int topBound = 4;
        int botBound = Console.WindowHeight - 5;
        int leftBound = 3;
        int rightBound = Console.WindowWidth - 4;
        int center = Console.WindowWidth / 2 - 1;

        public PlayingField(ConsoleKey key)
        {
            playerSide = key;
            PB = new PlayerBoard(key);
            OP = new OpponentBoard(key);
            ball = new Ball(key, topBound, botBound);
            stopwatch = new Stopwatch();
            scores = new Scores(0, 0, key);
            //if(key == ConsoleKey.L)
            //{
            //    PB = new OpponentBoard(ConsoleKey.R);

            //}
            //else
            //{
            //    PB = new OpponentBoard(ConsoleKey.L);

            //}
            
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
                OP.update(deltaTimeMS, ball);
                ball.update(deltaTimeMS);

                PB.draw();
                OP.draw();
                ball.draw();

                ball.checkBounce(PB, OP);

                if (ball.checkScored(PB, OP, leftBound, rightBound) == 'L')
                {
                    scores.update(playerSide);
                    ball.ResetBall();
                }
                if (ball.checkScored(PB, OP, leftBound, rightBound) == 'R')
                {
                    scores.update(ConsoleKey.A);
                    ball.ResetBall();
                }

                //drawing field
                for (int i = 5; i < Console.WindowHeight - 5; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 1, i);
                    Console.Write('|');
                    Console.SetCursorPosition(Console.WindowWidth - 2, i);
                    Console.Write('|');
                    Console.SetCursorPosition(1, i);
                    Console.Write('|');
                }
                for (int i = 1; i < Console.WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, topBound);
                    Console.Write('-');
                    Console.SetCursorPosition(i, botBound);
                    Console.Write('-');
                }
                scores.draw(playerSide);

            }
        }
    }
}
