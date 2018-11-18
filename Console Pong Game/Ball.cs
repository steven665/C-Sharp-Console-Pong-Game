using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Console_Pong_Game
{
    class Ball
    {
        int timeSinceLastMove;
        int timeBetweenMoves;
        int hDirection;
        int vDirection;
        Point prevPos;
        Point position;
        char ballSymbol = 'o';
        int topBound;
        int botBound;
        ConsoleKey playerSide;
        Random rnd;
        public Ball(ConsoleKey key, int TB, int BB)
        {
            timeBetweenMoves = 150;
            timeSinceLastMove = 0;

            position = new Point(Console.WindowWidth / 2 - 1, Console.WindowHeight / 2 - 1);

            if (key == ConsoleKey.L)
            {
                hDirection = -1;
                vDirection = 1;
            }
            else
            {
                hDirection = 1;
                vDirection = 1;
            }

            topBound = TB;
            botBound = BB;

            playerSide = key;
            rnd = new Random();
        }

        public Point ballPosition
        {
            get
            {
                return position;
            }
        }

        public void update(int deltaTimeMS)
        {
            timeSinceLastMove += deltaTimeMS;
            if (timeSinceLastMove > timeBetweenMoves)
            {

                prevPos = position;
                if (position.X > topBound || position.X < Console.WindowHeight - botBound)
                {
                    position = new Point(position.X + hDirection, position.Y + vDirection);
                }
                else
                {
                    return;
                    throw new Exception("ball's position was outside play area. There was an error with checkScored function");
                }

                timeSinceLastMove -= timeBetweenMoves;
            }


        }

        public void draw()
        {
            Console.SetCursorPosition(prevPos.X, prevPos.Y);
            Console.Write(' ');
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(ballSymbol);
            using (StreamWriter s = new StreamWriter(@"C:\data\log.txt", true))
                s.WriteLine($"speed = : {timeBetweenMoves} ");
        }

        public char? checkScored(Board playerBoard, Board opponentBoard, int leftBound, int rightBound)
        {
            //checking if anyone scored while player is on the left side.
            if (playerSide == ConsoleKey.L)
            {
                //checking if opponent scored.
                if (position.X < playerBoard.position.X)
                {

                    return 'R';
                }
                //checking if player scored
                if (position.X > opponentBoard.position.X)
                {

                    return 'L';
                }
            }
            //checking if anyone scored while player is on the right side.
            if (playerSide == ConsoleKey.R)
            {
                //checking if opponent scored.
                if (position.X > playerBoard.position.X)
                {

                    return 'R';
                }
                //checking if player scored.
                if (position.X < opponentBoard.position.X)
                {

                    return 'L';
                }
            }


            return null;
        }

        public void checkBounce(Board PB, Board OP)
        {
            //checking if bouncing off side walls.
            if (position.Y == topBound + 1)
            {
                vDirection = 1;
            }
            if (position.Y == botBound - 1)
            {
                vDirection = -1;
            }

            //checking if bouncing off of player baord, and if it does increase ball speed.
            //checking if bouncing off of board for player being on the right side
            if (playerSide == ConsoleKey.R)
            {
                //checking if bouncing off Player board for right side
                if (position == new Point(PB.position.X - 1, PB.position.Y) || position == new Point(PB.position.X - 1, PB.position.Y - 1) || position == new Point(PB.position.X - 1, PB.position.Y + 1))
                {
                    hDirection = hDirection = -1;
                    if (timeBetweenMoves > 60)
                    {
                        if (timeBetweenMoves - 5 < 60)
                        {
                            timeBetweenMoves = 60;
                        }
                        else
                        {
                            timeBetweenMoves -= 5;
                        }

                    }
                }

                //checking if bouncing off Opponent board for right side
                if (position == new Point(OP.position.X + 1, OP.position.Y) || position == new Point(OP.position.X + 1, OP.position.Y - 1) || position == new Point(OP.position.X + 1, OP.position.Y + 1))
                {
                    hDirection = hDirection = 1;
                    if (timeBetweenMoves > 60)
                    {
                        if (timeBetweenMoves - 5 < 60)
                        {
                            timeBetweenMoves = 60;
                        }
                        else
                        {
                            timeBetweenMoves -= 5;
                        }

                    }
                }

            }

            //checking if bouncing off of board for player being on the left side
            if (playerSide == ConsoleKey.L)
            {
                //checking if bouncing off Opponent board for left side
                if (position == new Point(OP.position.X - 1, OP.position.Y) || position == new Point(OP.position.X - 1, OP.position.Y - 1) || position == new Point(OP.position.X - 1, OP.position.Y + 1))
                {
                    hDirection = hDirection = -1;
                    if (timeBetweenMoves > 60)
                    {
                        if (timeBetweenMoves - 5 < 60)
                        {
                            timeBetweenMoves = 60;
                        }
                        else
                        {
                            timeBetweenMoves -= 5;
                        }

                    }
                }
                //checking if bouncing off of Player board for left side
                if (position == new Point(PB.position.X + 1, PB.position.Y) || position == new Point(PB.position.X + 1, OP.position.Y - 1) || position == new Point(PB.position.X + 1, PB.position.Y + 1))
                {
                    hDirection = hDirection = 1;
                    
                    if (timeBetweenMoves > 60)
                    {
                        if (timeBetweenMoves - 5 < 60)
                        {
                            timeBetweenMoves = 60;
                        }
                        else
                        {
                            timeBetweenMoves -= 5;
                        }

                    }
                }

            }

        }
        public void ResetBall()
        {
            prevPos = position;
            Console.SetCursorPosition(prevPos.X, prevPos.Y);
            Console.Write(' ');
            position = new Point(Console.WindowWidth / 2 - 1, rnd.Next(topBound + 1, botBound - 1));

            if (rnd.Next(0, 2) == 1)
            {
                vDirection = 1;
            }
            else
            {
                vDirection = -1;
            }
            if (rnd.Next(0, 2) == 1)
            {
                hDirection = 1;
            }
            else
            {
                hDirection = -1;
            }
            timeBetweenMoves = 150;


        }
    }

}
