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

            // Define output text encoding
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            
            Console.WriteLine(gm.Rows);
            Console.WriteLine(gm.Collums);



            rndr.MainMenu();

        }
    }
}
