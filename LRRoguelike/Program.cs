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
            Player player = new Player(pg.RanHp(100), pg.RanY(gm.Rows));

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
        /// Returns player's HP, accepts max HP
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RanHp(int max)
        {
            // Sets hp to random between 0 and mx and returns
            int hp = rnd.Next(0, max);
            return hp;
        }

        /// <summary>
        /// Returns player's spawning point,
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int RanY(int y)
        {
            // Sets ypos to random between 0 and nº of rows and returns
            int ypos = rnd.Next(0, y);
            return ypos;
        }
    }
}
