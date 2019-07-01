using System;

namespace LRRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            //int lenght = Convert.ToInt32(args [0]);
            //int height = Convert.ToInt32(args[1]);

            int lenght = 10;
            int height = 10;

            GameLoop gl = new GameLoop();

            gl.StartGame(lenght, height);
        }
    }
}
