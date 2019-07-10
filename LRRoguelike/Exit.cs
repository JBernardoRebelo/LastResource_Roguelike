using System;

namespace LRRoguelike
{
    /// <summary>
    /// Level exit
    /// </summary>
    public class Exit : MapComponents
    {
        /// <summary>
        /// Exit constructor
        /// </summary>
        /// <param name="row"> Random given value within map row number. </param>
        /// <param name="col"> GameSettings Collums value. </param>
        public Exit(int row, int col)
        {
            // Place exit
            SpawnPart(row, col);
        }

        /// <summary>
        /// Prints Exit's token in position according to discovered or not
        /// </summary>
        /// <returns> Designated Exit character. </returns>
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
    }
}
