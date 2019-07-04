using System;

namespace LRRoguelike
{
    /// <summary>
    /// Player, has a position, HP and moves
    /// </summary>
    public class Player
    {
        // Properties
        /// <summary>
        /// Player's HP, to be decremented in each turn
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Player's X position in map
        /// </summary>
        public int Xpos { get; set; }

        /// <summary>
        /// Player's Y position in map
        /// </summary>
        public int Ypos { get; set; }

        /// <summary>
        /// Registers player's level
        /// </summary>
        public int Lvl { get; set; }

        /// <summary>
        /// Player constructor, assigns HP and Y to given random value
        /// </summary>
        public Player(int y)
        {
            /*  DEBUG  */
            HP = 100;
            /*  !DEBUG */
            Lvl = 1;
            // Set initial position
            SpawnPlayer(y);
        }

        /// <summary>
        /// Accepts map dimensions, assingn's player's initial position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void SpawnPlayer(int row)
        {
            Ypos = row;
            Xpos = 1;
        }

        /// <summary>
        /// Prints player's token in position
        /// </summary>
        /// <returns></returns>
        public char PrintPlayer() => '⨀';
    }
}
