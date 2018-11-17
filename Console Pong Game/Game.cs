using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Pong_Game
{
    class Game
    {
        public void Run()
        {
            string messageString = "Would you like to be on the left(press L) or right(press R) side?";
            Console.SetCursorPosition(Console.WindowWidth / 2 - (messageString.Length / 2 - 1),Console.WindowHeight/2 -1);
            Console.WriteLine(messageString);
            ConsoleKey keyInfo = Console.ReadKey(intercept:true).Key;
            Console.Clear();
            PlayingField PF = new PlayingField(keyInfo);
            while(true)
            {
                PF.RunField();
            }
        }
    }
}
