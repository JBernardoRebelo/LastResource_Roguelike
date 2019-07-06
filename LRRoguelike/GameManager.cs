using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    /// <summary>
    /// Runs game, controls turns
    /// </summary>
    public class GameManager
    {
        // Instantiate Classes
        Random rnd = new Random();
        Render rndr = new Render();
        PlayerActions pA = new PlayerActions();
        Checker checker = new Checker();
        List<MapComponents> mpComp;

        /// <summary>
        /// Shows start menu, redirects to Loop
        /// </summary>
        /// <param name="col"> GameSettings Collums value. </param>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="player"> Program user. </param>
        /// /// <param name="exit"> Program user. </param>
        public void StartGame(int col, int rows)
        {
            // Instantiate objects in world with "random" positions
            Player player = new Player(RanBtw(1, rows));
            Exit exit = new Exit(RanBtw(1, rows), col);
            MapItem map = new MapItem(RanBtw(1, rows), RanBtw(1, col));

            // List of map components
            mpComp = new List<MapComponents>();

            // Check positions - map and exit must be diferent
            // Else new position is assigned
            while (checker.ComponentPosChecker(map, exit))
            {
                map.Xpos = RanBtw(1, rows);
                map.Ypos = RanBtw(1, col);
            }

            // Create map components and add to list
            for (int i = 1; i < col + 1 ; i++)
            {
                mpComp.Add(AddComponent(i, rows));
                for (int j = 1; j < rows; j++)
                {
                    mpComp.Add(AddComponent(i, j));
                }
            }

            mpComp.Add(exit);
            mpComp.Add(map);

            //####################################################################################
            Console.WriteLine("Number of rows: " + rows);
            Console.WriteLine("Number of collums: " + col);
            Console.WriteLine("Player's hp: " + player.HP);
            Console.WriteLine("Player's spawn, Y: " + player.Ypos + "X: " + player.Xpos);
            Console.WriteLine("Exit's position, Y: " + exit.Ypos + "X: " + exit.Xpos);
            Console.WriteLine("Map's position, Y: " + map.Ypos + "x: " + map.Xpos);
            // DEBUG
            //####################################################################################

            // Render Main Menu
            rndr.MainMenu();

            // Start gameloop
            Loop(col, rows, player, exit, map, mpComp);
        }

        /// <summary>
        /// Game loop, accepts map dimensions and map components
        /// </summary>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        private void Loop
            (int col, int rows, Player player, Exit exit, MapItem map,
            List<MapComponents> mpComp)
        {
            // Method variables
            string option;
            bool valInput = false;

            // Actual game loop
            while (player.HP > 0)
            {
                // Clear console to ensure correct print of everything
                Console.Clear();

                // Print board
                rndr.PrintBoard(col, rows);

                // Display fog of war
                pA.FogOfWar(mpComp, player);

                // Print map components
                foreach (MapComponents mc in mpComp)
                {
                    // Place map Components
                    rndr.FillMap(mc);
                }

                // Place player, exit and map
                rndr.PlaceParts(player, exit, map);

                // Options
                rndr.PlaceMenus(rows);
                rndr.GameloopMenu(player);

                // Comment here ----- 
                do
                {
                    option = Console.ReadLine();

                    if (option == "l" || option == "m" 
                        || option == "q" || option == "e")
                    {
                        valInput = true;
                    }
                    else
                    {
                        rndr.ErrorMessage();
                    }
                } while (!valInput);

                // Checks player's choice and does stuff
                checker.MenuChecker(option, player, map, mpComp, rows, col);

                // Check if player and exit have == position and restart level
                if (player.Xpos == exit.Xpos && player.Ypos == exit.Ypos)
                {
                    NewLevel(player, exit, map, mpComp, col, rows);
                    rndr.NextLevel();
                }

                // End of turn
                // Player looses 1 hp reset valInput value
                player.HP--;
                valInput = false;
            }

            // End of game with death message
            rndr.PlayerDeath(player);
        }

        /// <summary>
        /// Re-Spawns exit and player in new level
        /// </summary>
        /// <param name="player"></param>
        /// <param name="exit"></param>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        public void NewLevel
            (Player player, Exit exit, MapItem map,
            List<MapComponents> mapComps, int col, int rows)
        {
            // Level up
            player.Lvl++;

            // New map
            map.Used = false;

            // Reset discover
            foreach(MapComponents mc in mapComps)
            {
                mc.isDisc = false;
            }

            // Reset position
            player.SpawnPlayer(RanBtw(1, rows));
            exit.SpawnPart(RanBtw(1, rows), col);
        }

        /// <summary>
        /// Random number generator between 0 and given max value.
        /// </summary>
        /// <param name="min"> Min intager value given by user. </param>
        /// <param name="max"> Max intager value given by user. </param>
        /// <returns> Returns random number between given values. </returns>
        private int RanBtw(int min, int max)
        {
            int ran = rnd.Next(min, max);
            return ran;
        }

        /// <summary>
        /// Instantiate map component
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private MapComponents AddComponent(int x, int y)
        {
            MapComponents mc = new MapComponents(x, y);
            return mc;
        }
    }
}
