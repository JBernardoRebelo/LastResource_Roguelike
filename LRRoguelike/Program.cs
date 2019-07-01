using System;
using System.Text;

namespace LRRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate classes
            GameSettings gm = new GameSettings(args);
            Random rndm = new Random();
            Render rndr = new Render();
            GameLoop gl = new GameLoop();

            // Define output text encoding
            Console.OutputEncoding = Encoding.UTF8;


            /*************************
             *******   DEBUG   *******
             *************************/
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }

            Console.WriteLine("Number of rows: " + gm.Rows);
            Console.WriteLine("Number of collums: " + gm.Collums);

            /*************************
             *******  !DEBUG   *******
             *************************/

            gl.StartGame(gm.Collums, gm.Rows);

        }
    }
}
