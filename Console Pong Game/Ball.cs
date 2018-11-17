using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Pong_Game
{
    class Ball
    {
        int timeSinceLastMove;
        int timeBetweenMoves;
        public Ball()
        {
            timeBetweenMoves = 100;
            timeSinceLastMove = 0;
        }
        public void update(int deltaTimeMS)
        {
            timeSinceLastMove += deltaTimeMS;
            if(timeSinceLastMove > timeBetweenMoves)
            {



                timeSinceLastMove -= timeBetweenMoves;
            }


        }
        public void draw()
        {

        }
        public bool checkHit(Board b)
        {
            return false;
        }
    }
    
}
