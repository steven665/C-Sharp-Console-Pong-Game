using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Pong_Game
{
    class PlayingField
    {
        PlayerBoard PB;
        OpponentBoard OP;
        Ball ball;
        ConsoleKey side;
        public PlayingField(ConsoleKey key)
        {
            side = key;

            
        }
        public void RunField()
        {

        }
    }
}
