using System;
using System.Text;

namespace LRRoguelike
{
    public class Program
    {
        // Instantiate random class
        Random rnd = new Random();

        static void Main(string[] args)
        {
            // Instantiate classes                   
            Program pg = new Program();
            GameSettings gm = new GameSettings(args);
            Render rndr = new Render();
            GameLoop gl = new GameLoop();
            Player player = new Player(pg.RanBtw(1, gm.Rows));

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
            Console.WriteLine("Player's hp: " + player.HP);
            Console.WriteLine("Player's spawn, Y:" + player.Ypos + "X:" + player.Xpos);

            /*************************
             *******  !DEBUG   *******
             *************************/

            gl.StartGame(gm.Collums, gm.Rows, player);

        }

        /// <summary>
        /// Random number generator between 0 and given max value.
        /// </summary>
        /// <param name="min"> Min intager value given by user. </param>
        /// <param name="max"> Max intager value given by user. </param>
        /// <returns> Returns random number between given values. </returns>
        public int RanBtw(int min, int max)
        {
            int ran = rnd.Next(min, max);
            return ran;
        }
    }
}
