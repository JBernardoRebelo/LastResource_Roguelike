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
        private static void Main(string[] args)
        {
            // Instantiate classes
            GameSettings gm = new GameSettings(args);
            GameManager gl = new GameManager();           

            // Define output text encoding
            Console.OutputEncoding = Encoding.Unicode;

            // Start Game
            gl.StartGame(gm.Collums, gm.Rows);
        }
    }
}
