﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Pong_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(76, 30);
            Game g = new Game();
            g.Run();
        }
    }
}
