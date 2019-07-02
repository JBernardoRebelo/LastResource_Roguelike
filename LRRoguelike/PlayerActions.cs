using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class PlayerActions
    {
        /// <summary>
        /// Accepts input from user and moves player
        /// </summary>
        /// <param name="chMove"></param>
        public void Move
            (Player player, string chMove, int height, int length)
        {
            switch (chMove)
            {
                case "7":
                    // Up left
                    break;

                // Up
                case "8":
                    // Wall
                    if (player.Ypos <= 0)
                    {
                        player.Ypos = player.Ypos;
                    }
                    // Moves
                    else
                    {
                        player.Ypos--;
                    }
                    break;

                case "9":
                    // Up right
                    break;

                // Left
                case "4":
                    // Wall
                    if (player.Xpos <= 0)
                    {
                        player.Xpos = player.Xpos;
                    }
                    // Moves
                    else
                    {
                        player.Xpos--;
                    }
                    break;

                // Right
                case "6":
                    // Wall
                    if (player.Xpos >= length)
                    {
                        player.Xpos = player.Xpos;
                    }
                    // Moves
                    else
                    {
                        player.Xpos++;
                    }
                    break;

                case "1":
                    // Down left
                    break;

                // Down
                case "2":
                    // Wall
                    if (player.Ypos >= height)
                    {
                        player.Ypos = player.Ypos;
                    }
                    // Moves
                    else
                    {
                        player.Ypos++;
                    }
                    break;

                case "3":
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
