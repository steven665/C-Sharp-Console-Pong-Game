using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Console_Pong_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Console.SetWindowSize(80, 20);
            Game g = new Game();
            g.Run();
        }
    }
}
