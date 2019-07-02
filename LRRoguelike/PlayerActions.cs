using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class PlayerActions
    {
        // Instantiate Render for error messages
        Render rndr = new Render();

        /// <summary>
        /// Accepts input from user and moves player
        /// </summary>
        /// <param name="player"> Program user. </param>
        /// <param name="chMove"> User chosen direction. </param>
        /// <param name="height"> GameSettings Rows value. </param>
        /// <param name="length"> GameSettings Collums value. </param>
        public void Move
            (Player player, int chMove, int height, int length)
        {
            switch (chMove)
            {
                case 7:
                    // Up left
                    break;

                // Up
                case 8:

                    // Moves
                    player.Ypos--;

                    // Wall
                    if (player.Ypos <= 0)
                    {
                        // INSERT ERROR MESSAGE!!!
                        player.Ypos = 1;
                    }
 
                    break;

                case 9:
                    // Up right
                    break;

                // Left
                case 4:

                    // Moves
                    player.Xpos--;

                    // Wall
                    if (player.Xpos <= 0)
                    {
                        player.Xpos = 1;
                    }
                    break;

                // Right
                case 6:

                    // Moves
                    player.Xpos++;

                    // Wall
                    if (player.Xpos >= length)
                    {
                        player.Xpos = length;
                    }
                    break;

                case 1:
                    // Down left
                    break;

                // Down
                case 2:

                    // Moves
                    player.Ypos++;

                    // Wall
                    if (player.Ypos >= height)
                    {
                        player.Ypos = height;
                    }
                    break;

                case 3:
                    // Down Right
                    break;

                default:

                    break;
            }
        }

        public void LookAround()
        {
            Console.Read();
        }
    }
}
