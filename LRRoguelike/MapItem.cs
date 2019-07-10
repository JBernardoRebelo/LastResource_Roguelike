using System;
using System.Collections.Generic;

namespace LRRoguelike
{
    /// <summary>
    /// Map class, item used to unveil board.
    /// </summary>
    public class MapItem : MapComponents
    {
        /// <summary>
        /// See if map is used
        /// </summary>
        public bool Used { get; set; }

        /// <summary>
        /// Map constructor, accepts map dimensions and assigns position
        /// Initializes used to false
        /// </summary>
        /// <param name="row"> Given row value within map size. </param>
        /// <param name="col"> Given collum value within map size. </param>
        public MapItem(int row, int col)
        {
            SpawnPart(row, col);
            Used = false;
        }

        /// <summary>
        /// Prints Map's token in position according to discovered or not
        /// </summary>
        /// <returns> Designated MapItem charater. </returns>
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


        /// <summary>
        /// Accepts a list of MapComponents and assigns isDisc(overed) to true
        /// To all components
        /// </summary>
        /// <param name="mapComp"> List of map components. </param>
        public void UncoverMap(IEnumerable<MapComponents> mapComp)
        {
            foreach (MapComponents mc in mapComp)
            {
                mc.isDisc = true;
            }
        }
    }
}
