using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Pong_Game
{
    class Scores
    {
        int playerScore;
        int opponetScore;
        ConsoleKey playerSide;
        public Scores(int p, int o, ConsoleKey side)
        {
            playerScore = p;
            opponetScore = o;
            playerSide = side;
        }

        public void update(ConsoleKey k)
        {
            if (k == playerSide)
            {
                playerScore++;
            }
            else
            {
                opponetScore++;
            }
        }
        public void draw(ConsoleKey k)
        {
            if (k == ConsoleKey.L)
            {
                string s = $"Player score : {playerScore}  |  Opponent score : {opponetScore}";
                Console.SetCursorPosition(Console.WindowWidth / 2 - (s.Length / 2 + 2), Console.WindowHeight - 3);
                Console.Write(s);
            }
            else
            {
                string s = $"Opponent score : {opponetScore}  |  Player score : {playerScore}";
                Console.SetCursorPosition(Console.WindowWidth / 2 - (s.Length / 2 + 2 ), Console.WindowHeight - 3);
                Console.Write(s);
            }
        }
    }
}
