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
        public OpponentBoard(ConsoleKey side, Point p) : base(side,p)
        {
            
        }
    }
}
