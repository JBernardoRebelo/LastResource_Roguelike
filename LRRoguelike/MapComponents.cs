using System;

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
                Console.ForegroundColor = ConsoleColor.Gray;
                return '-';
            }           
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return '#';
            }
        }

        /// <summary>
        /// Accepts map dimensions and assigns position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void SpawnPart(int row, int col)
        {
            Ypos = row;
            Xpos = col;
        }
    }
}
