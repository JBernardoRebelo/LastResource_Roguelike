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
            SpawnPart(row, col);
        }

        /// <summary>
        /// Prints Exit's token in position according to discovered or not
        /// </summary>
        /// <returns></returns>
        public char PrintExit()
        {
            if(isDisc)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                return 'E';
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return '#';
            }
        }

        /// <summary>
        /// Show exit description
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "Exit cell:\n"
            + "Enter here to transit to the next level";
    }
}
