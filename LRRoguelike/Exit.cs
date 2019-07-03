using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class Exit : MapComponents
    {
        /// <summary>
        /// Exit constructor
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Exit(int row, int col)
        {
            // Place exit
            SpawnExit(row, col);
        }

        /// <summary>
        /// Accepts map dimensions and assigns exit's position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void SpawnExit(int row, int col)
        {
            Ypos = row;
            Xpos = col;
        }

        /// <summary>
        /// Prints Exit's token in position
        /// </summary>
        /// <returns></returns>
        public char PrintExit() => 'E'; // ✚

        /// <summary>
        /// Show exit description
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "Exit cell:\n"
            + "Enter here to transit to the next level";
    }
}
