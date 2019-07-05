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
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="col"> GameSettings Collums value. </param>
        public void Move
            (Player player, int chMove, int rows, int col)
        {
            switch (chMove)
            {
                case 7:
                    // Up left
                    player.Xpos--;
                    player.Ypos--;

                    if (player.Ypos <= 0 && player.Xpos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Xpos = 1;
                        player.Ypos = 1;
                    }
                    else if (player.Ypos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Ypos = 1;
                        player.Xpos++;
                    }
                    else if (player.Xpos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Ypos++;
                        player.Xpos = 1;
                    }
                    break;

                // Up
                case 8:
                    // Moves
                    player.Ypos--;

                    // Wall
                    if (player.Ypos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Ypos = 1;
                    }
                    break;

                case 9:
                    // Up right
                    player.Xpos++;
                    player.Ypos--;                  

                    if (player.Ypos <= 0 && player.Xpos > col)
                    {
                        rndr.AgainstWall();
                        player.Xpos = col;
                        player.Ypos = 1;
                    }
                    else if (player.Ypos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Ypos = 1;
                        player.Xpos--;
                    }
                    else if (player.Xpos > col)
                    {
                        rndr.AgainstWall();
                        player.Xpos = col;
                        player.Ypos++;
                    }
                    break;

                // Left
                case 4:
                    // Moves
                    player.Xpos--;

                    // Wall
                    if (player.Xpos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Xpos = 1;
                    }
                    break;

                // Right
                case 6:
                    // Moves
                    player.Xpos++;

                    // Wall
                    if (player.Xpos > col)
                    {
                        rndr.AgainstWall();
                        player.Xpos = col;
                    }
                    break;

                case 1:
                    // Down left
                    player.Xpos--;
                    player.Ypos++;

                    if (player.Ypos > rows && player.Xpos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Xpos = 1;
                        player.Ypos = rows;
                    }
                    else if (player.Ypos > rows)
                    {
                        rndr.AgainstWall();
                        player.Ypos = rows;
                        player.Xpos++;
                    }
                    else if (player.Xpos <= 0)
                    {
                        rndr.AgainstWall();
                        player.Xpos = 1;
                        player.Ypos--;
                    }
                    break;

                // Down
                case 2:
                    // Moves
                    player.Ypos++;

                    // Wall
                    if (player.Ypos > rows)
                    {
                        rndr.AgainstWall();
                        player.Ypos = rows;
                    }
                    break;

                case 3:
                    // Down Right
                    player.Xpos++;
                    player.Ypos++; 

                    if (player.Ypos > rows && player.Xpos > col)
                    {
                        rndr.AgainstWall();
                        player.Xpos = col;
                        player.Ypos = rows;
                    }
                    else if (player.Ypos > rows)
                    {
                        rndr.AgainstWall();
                        player.Ypos = rows;
                        player.Xpos--;
                    }
                    else if (player.Xpos > col)
                    {
                        rndr.AgainstWall();
                        player.Xpos = col;
                        player.Ypos--;
                    }
                    break;

                default:

                    break;
            }
        }

        /// <summary>
        /// Shows adjacent object's info
        /// </summary>
        /// <param name="mp"></param>
        public void LookAround(List<MapComponents> mapComps, Player player)
        {
            foreach(MapComponents mc in mapComps)
            {
                // Player position
                if(mc.Xpos == player.Xpos && mc.Ypos == player.Ypos)
                {
                    mc.isDisc = true;
                }
                // Left to player
                else if(mc.Xpos == player.Xpos - 1 && mc.Ypos == player.Ypos)
                {
                    mc.isDisc = true;
                }
                // Right to player
                else if (mc.Xpos == player.Xpos + 1 && mc.Ypos == player.Ypos)
                {
                    mc.isDisc = true;
                }
                // Down player
                else if (mc.Xpos == player.Xpos && mc.Ypos == player.Ypos + 1)
                {
                    mc.isDisc = true;
                }
                // Up to player
                else if (mc.Xpos == player.Xpos && mc.Ypos == player.Ypos - 1)
                {
                    mc.isDisc = true;
                }
                // Up Left
                else if (mc.Xpos == player.Xpos - 1 && mc.Ypos == player.Ypos - 1)
                {
                    mc.isDisc = true;
                }
                // Up Right
                else if (mc.Xpos == player.Xpos + 1 && mc.Ypos == player.Ypos - 1)
                {
                    mc.isDisc = true;
                }
                // Down Left
                else if (mc.Xpos == player.Xpos - 1 && mc.Ypos == player.Ypos + 1)
                {
                    mc.isDisc = true;
                }
                // Down Right
                else if (mc.Xpos == player.Xpos + 1 && mc.Ypos == player.Ypos + 1)
                {
                    mc.isDisc = true;
                }
            }

            // This is a cheat and we know it
            // Player doesn't loose turn
            player.HP++;
        }
    }
}
