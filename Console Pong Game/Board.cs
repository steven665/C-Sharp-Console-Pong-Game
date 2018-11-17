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
        public Board(ConsoleKey side, Point p)
        {
                
        }
        public Point position
        {
            get
            {
                return _position;
            
            }
            set
            {
                _position = value;
            }
            
        }
        virtual public void update()
        {

        }
        virtual public void draw()
        {

        }
    }
}
