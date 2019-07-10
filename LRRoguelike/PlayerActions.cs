using System.Collections.Generic;

namespace LRRoguelike
{
    /// <summary>
    /// Class with all player actions
    /// </summary>
    public class PlayerActions
    {
        // Instantiate Render for error messages
        /// <summary>
        /// Instance of class Render to use methods.
        /// </summary>
        private Render rndr = new Render();

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
        /// Show adjacent tiles in world
        /// </summary>
        /// <param name="mapComps"> List of map components. </param>
        /// <param name="player"> Program user. </param>
        public void FogOfWar(IEnumerable<MapComponents> mapComps, 
            Player player)
        {
            int distanceX;
            int distanceY;

            foreach (MapComponents mc in mapComps)
            {
                // Calculate distances
                distanceX = player.Xpos - mc.Xpos;
                distanceY = player.Ypos - mc.Ypos;

                // Discover adjacent cells to player
                if (distanceX <= 1 && distanceY <= 1 &&
                    distanceX >= -1 && distanceY >= -1)
                {
                    mc.isDisc = true;
                }
            }
        }


        /// <summary>
        /// Accepts list of MapComponents, show info case one of them is Exit
        /// </summary>
        /// <param name="mapComps"> List of map components. </param>
        /// <param name="player"> Program user. </param>
        public void LookAround(IEnumerable<MapComponents> mapComps, 
            Player player)
        {
            int distanceX;
            int distanceY;

            foreach (MapComponents mc in mapComps)
            {
                // Calculate distances
                distanceX = player.Xpos - mc.Xpos;
                distanceY = player.Ypos - mc.Ypos;

                if (mc.isDisc && distanceX <= 1 && distanceY <= 1 &&
                    distanceX >= -1 && distanceY >= -1)
                {
                    // Show Exit info
                    if (mc is Exit)
                    {
                        rndr.FoundExit(mc.Xpos, mc.Ypos);
                    }
                    else if (mc is MapItem)
                    {
                        // Show map info
                        MapItem map = mc as MapItem;
                        if(!map.Used)
                        {
                            rndr.FoundMap(mc.Xpos, mc.Ypos);
                        }
                    }
                    else if(mc is Trap)
                    {
                        Trap trap = mc as Trap;
                        // Show trap info
                        rndr.FoundTrap(trap.Xpos, trap.Xpos, trap);
                    }
                }
            }

            // This is a cheat and we know it
            // Player doesn't loose turn
            player.HP++;
        }

        /// <summary>
        /// After finding an item in map, Player mey pick it up
        /// </summary>
        /// <param name="player"> Program user. </param>
        /// <param name="map"> MapItem instance. </param>
        /// <param name="mc"> List of map components. </param>
        public void PickUpItem
            (Player player, MapItem map, IEnumerable<MapComponents> mc)
        {
            if (player.Xpos == map.Xpos && player.Ypos == map.Ypos)
            {
                if (map.Used)
                {
                }
                else if (!map.Used)
                {
                    // Print message
                    rndr.UseMap();
                    // Set used map to true
                    map.Used = true;
                    // All mapcomponents turn discovered
                    map.UncoverMap(mc);
                }
            }
        }
    }
}
