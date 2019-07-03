using System;
using System.Text;

namespace LRRoguelike
{
    public class Program
    {  
        static void Main(string[] args)
        {
            // Instantiate classes                   
            Program pg = new Program();
            GameSettings gm = new GameSettings(args);
            GameLoop gl = new GameLoop();           

            // Define output text encoding
            Console.OutputEncoding = Encoding.Unicode;


            /*************************
             *******   DEBUG   *******
             *************************/
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            /*************************
             *******  !DEBUG   *******
             *************************/

            gl.StartGame(gm.Collums, gm.Rows);
        }
    }
}
