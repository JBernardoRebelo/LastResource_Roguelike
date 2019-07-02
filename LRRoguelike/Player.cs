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
        /// Player constructor, assigns HP and Y to given random value
        /// </summary>
        public Player(int y)
        {
            // Assigning HP to random
            //HP = 100;

            /*  DEBUG  */
            HP = 5;
            /*  !DEBUG */

            // Initializing pos to random in first column
            Xpos = 1;

            // Assigning Y to random
            Ypos = y;

        }       

        /// <summary>
        /// Prints player's token in position
        /// </summary>
        /// <returns></returns>
        public char PrintPlayer() => 'p';
    }
}
