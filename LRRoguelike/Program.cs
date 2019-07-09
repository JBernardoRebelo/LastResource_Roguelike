using System;
using System.Text;

namespace LRRoguelike
{
    /// <summary>
    /// Program class where main() is located and where GameSettings and
    /// GameLoop are instanciated. Output text encoding defined aswell.
    /// </summary>
    public class Program
    {  
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args"> Console arguments. </param>
        static void Main(string[] args)
        {
            // Instantiate classes
            GameSettings gm = new GameSettings(args);
            GameManager gl = new GameManager();           

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
