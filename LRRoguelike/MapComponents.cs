using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class MapComponents
    {
        /// <summary>
        /// Component's X position in map
        /// </summary>
        public int Xpos { get; set; }

        /// <summary>
        /// Component's Y position in map
        /// </summary>
        public int Ypos { get; set; }

        /// <summary>
        /// Check if discovered or not
        /// </summary>
        public bool isDisc { get; set; }

        /// <summary>
        /// Initializes isDisc to false, assigns position
        /// </summary>
        public MapComponents(int x, int y)
        {
            Xpos = x;
            Ypos = y;
            isDisc = false;
        }

        /// <summary>
        /// Empty constructor, initializes isDisc to false
        /// </summary>
        public MapComponents()
        {
            isDisc = false;
        }

        /// <summary>
        /// Returns map component's char based on discovered or not
        /// </summary>
        /// <returns></returns>
        public char PrintPart()
        {
            if(isDisc)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                return '-';
            }           
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return '#';
            }
        }
    }
}
