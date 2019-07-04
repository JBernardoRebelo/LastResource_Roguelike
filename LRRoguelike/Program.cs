using System;
using System.Text;

namespace LRRoguelike
{
    public class Program
    {  
        static void Main(string[] args)
        {
            // Instantiate classes
            GameSettings gm = new GameSettings(args);
            GameManager gl = new GameManager();           

            // Define output text encoding
            Console.OutputEncoding = Encoding.Unicode;


            // Clean console before game start
            Console.Clear();                    // ***** mOVE THIS TO START MENU

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
