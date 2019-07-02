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
            Player player = new Player(pg.RanBtw(100), pg.RanBtw(gm.Rows));

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
        /// Returns a random number between given value and 0
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RanBtw(int max)
        {
            // Sets hp to random between 0 and mx and returns
            int ran = rnd.Next(0, max);
            return ran;
        }
    }
}
