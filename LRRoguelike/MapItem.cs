using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class MapItem : MapComponents
    {

        /// <summary>
        /// Map constructor, accepts map dimensions and assigns position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public MapItem(int row, int col)
        {
            SpawnPart(row, col);
        }


        /// <summary>
        /// Prints Exit's token in position according to discovered or not
        /// </summary>
        /// <returns></returns>
        public char PrintMapItem()
        {
            if (isDisc)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return 'M';
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return '#';
            }
        }
    }
}
