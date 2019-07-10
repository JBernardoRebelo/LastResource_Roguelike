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
        /// <param name="x"> GameSettings Collums value. </param>
        /// <param name="y"> GameSettings Rows value. </param>
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
        /// <returns> Designated map component character. </returns>
        public char PrintPart()
        {
            if(isDisc)
            {
                return ' ';
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
        /// <param name="col"> GameSettings Collums value. </param>
        /// <param name="row"> GameSettings Rows value. </param>
        public void SpawnPart(int row, int col)
        {
            Ypos = row;
            Xpos = col;
        }
    }
}
