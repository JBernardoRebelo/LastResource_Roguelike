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
            for (int i = 1; i < col + 1; i++)
            {
                // Random num
                int rand = RanBtw(1, rows);

                // Add default Map component
                mpComp.Add(AddComponent(i, rows));

                // Add traps
                if (rand > rows / 2)
                {
                    mpComp.Add(TrapGen(col, rows));
                }

                for (int j = 1; j < rows; j++)
                {
                    // Random num
                    rand = RanBtw(1, j);

                    mpComp.Add(AddComponent(i, j));

                    if (rand > col / 2)
                    {
                        mpComp.Add(TrapGen(col, rows));
                    }
                }
            }

            // Add exit and map to list of components
            mpComp.Add(exit);
            mpComp.Add(map);

            Console.WriteLine("Number of rows: " + rows);
            Console.WriteLine("Number of collums: " + col);
            Console.WriteLine("Player's hp: " + player.HP);
            Console.WriteLine("Player's spawn, Y: " + player.Ypos + "X: " + player.Xpos);
            Console.WriteLine("Exit's position, Y: " + exit.Ypos + "X: " + exit.Xpos);
            Console.WriteLine("Map's position, Y: " + map.Ypos + "x: " + map.Xpos);

            int numtraps = 0;

            foreach (MapComponents trap in mpComp)
            {
                if (trap is Trap)
                {
                    numtraps++;
                    Trap trap1 = trap as Trap;
                    Console.Write($"I'm a trap at position: X: {trap1.Xpos} Y: {trap1.Ypos}");
                    Console.WriteLine(trap1.Type);
                }
            }
            Console.WriteLine(numtraps);

            // Render Main Menu
            rndr.MainMenu();

            // Start gameloop
            Loop(col, rows, player, exit, map, mpComp);
        }

        /// <summary>
        /// Game loop, accepts map dimensions and map components
        /// </summary>
        /// <param name="col"> GameSettings Collums value. </param>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="player"> Program user. </param>
        /// <param name="exit"> Level exit. </param>
        /// <param name="map"> MapItem. </param>
        /// <param name="mpComp"> List of map components. </param>
        private void Loop
            (int col, int rows, Player player, Exit exit, MapItem map,
            IEnumerable<MapComponents> mpComp)
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
                    // Place map Components and traps
                    rndr.FillMap(mc);
                }

                // Place player, exit and map
                rndr.PlaceParts(player, exit, map);

                // Options
                rndr.PlaceMenus(rows);
                rndr.GameloopMenu(player);

                // Option loop
                do
                {
                    // Store input
                    option = Console.ReadLine();

                    // Make sure option is valid
                    if (option == "l" || option == "m"
                        || option == "q" || option == "e" || option == "h")
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

                // Traps damage player
                TrapWorker(player);

                // Check if player and exit have == position and restart level
                if (player.Xpos == exit.Xpos && player.Ypos == exit.Ypos)
                {
                    NewLevel(player, exit, map, mpComp, col, rows);
                    rndr.NextLevel();
                }

                // End of turn
                // Player loses 1 hp reset valInput value
                player.HP--;
                valInput = false;
            }

            // End of game with death message
            rndr.PlayerDeath(player);
        }


        /// <summary>
        /// Re-Spawns exit and player in new level
        /// </summary>
        /// <param name="player"> Program user. </param>
        /// <param name="exit"> Level exit. </param>
        /// <param name="map"> MapItem. </param>
        /// <param name="mapComps"> List of map components. </param>
        /// <param name="col"> GameSettings Collums value. </param>
        /// <param name="rows"> GameSettings Rows value. </param>
        private void NewLevel
            (Player player, Exit exit, MapItem map,
            IEnumerable<MapComponents> mapComps, int col, int rows)
        {
            // Level up
            player.Lvl++;

            // New map
            map.Used = false;

            // Reset discover
            foreach (MapComponents mc in mapComps)
            {
                mc.isDisc = false;
                if (mc is Trap)
                {
                    Trap trap = mc as Trap;
                    trap.FallenInto = false;

                    // Assign new position
                    trap.Xpos = RanBtw(1, col);
                    trap.Ypos = RanBtw(1, rows);
                }
            }
            // Reset position
            player.SpawnPlayer(RanBtw(1, rows));
            exit.SpawnPart(RanBtw(1, rows), col);
            map.SpawnPart(RanBtw(1, rows), RanBtw(1, col));
        }

        /// <summary>
        /// Accepts seeds a seed to generate random trap in map
        /// </summary>
        /// <param name="col"> Random x (Collums) position between
        /// 1 and max board collums. </param>
        /// <param name="rows">Random y (Rows) position between
        /// 1 and max board rows. </param>
        private Trap TrapGen(int seedX, int seedY)
        {
            // Instantiate trap
            Trap trap = new Trap
                (RanBtw(1, seedX), RanBtw(1, seedY), RanBtw(0, 100));

            return trap;
        }

        /// <summary>
        /// Method to activate the trap, deals damage to player between 1 and 
        /// specific trap max damage. 
        /// </summary>
        /// <param name="player"> Program user. </param>
        private void TrapWorker(Player player)
        {
            int damageTaken;
            // Trap worker
            foreach (MapComponents mp in mpComp)
            {
                if (mp is Trap)
                {
                    Trap trap = mp as Trap;
                    // Check if player was hit by traps
                    if (checker.TrapPlayer(trap, player))
                    {
                        if (trap.FallenInto == false)
                        {
                            damageTaken = RanBtw(1, trap.MaxDamage);

                            // Take hp from player
                            player.HP -= damageTaken;
                            trap.FallenInto = true;

                            // Print details 
                            rndr.DamageTaken(trap, damageTaken);
                        }
                        // Print a message if player has alreaydy fallen in trap
                        else
                        {
                            rndr.FallenInto();
                        }
                    }
                }
            }
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
        /// <param name="x"> GameSettings Collums value. </param>
        /// <param name="y"> GameSettings Rows value. </param>
        /// <returns> Map component with given coordinates. </returns>
        private MapComponents AddComponent(int x, int y)
        {
            MapComponents mc = new MapComponents(x, y);
            return mc;
        }
    }
}
