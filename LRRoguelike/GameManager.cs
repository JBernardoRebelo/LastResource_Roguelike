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

            //####################################################################################
            Console.WriteLine("Number of rows: " + rows);
            Console.WriteLine("Number of collums: " + col);
            Console.WriteLine("Player's hp: " + player.HP);
            Console.WriteLine("Player's spawn, Y:" + player.Ypos + "X: " + player.Xpos);
            Console.WriteLine("Exit's position, Y:" + exit.Ypos + "X: " + exit.Xpos);
            // DEBUG
            //####################################################################################

            // Render Main Menu
            rndr.MainMenu();

            // Start gameloop
            Loop(col, rows, player, exit);
        }

        /// <summary>
        /// Game loop, accepts map dimensions
        /// </summary>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        public void Loop(int col, int rows, Player player, Exit exit)
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
                
                // Place player
                rndr.PlacePart(rows, player);            
                // Place exit
                rndr.PlacePart(rows, exit);

                // Options
                rndr.PlaceMenus(rows);
                rndr.GameloopMenu(player);
               
                // Comment here ----- 
                do
                {
                    option = Console.ReadLine();

                    if (option == "l" || option == "m" || option == "q")
                    {
                        valInput = true;
                    }
                    else
                    {
                        rndr.ErrorMessage();
                    }
                } while (!valInput);


                // Checks player's choice and does stuff
                MenuChecker(option, player, exit, rows, col);

                // Check if player and exit have == position and restart level
                ExitChecker(player, exit, col, rows);

                // End of turn
                // Player looses 1 hp reset valInput value
                player.HP--;
                valInput = false;
            }

            // End of game with death message
            rndr.PlayerDeath(player);
        }

        /// <summary>
        /// Accepts a string and calls adequate methods
        /// </summary>
        /// <param name="option"> User input. </param>
        /// <param name="player"> Program user. </param>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="col"> GameSettings Collums value. </param>
        public void MenuChecker
            (string option, Player player, MapComponents mp, int rows, int col)
        {
            string uChoice;
            int chMove;

            switch (option)
            {
                // Looks around
                case "l":
                    pA.LookAround(mp, player);
                    // DONT USE TURN LA           
                    break;

                // Move
                case "m":
                    rndr.MoveMenu();

                    // Assign's user's choice
                    do
                    {
                        do
                        {
                            uChoice = Console.ReadLine();

                            if (!int.TryParse(uChoice, out int a))
                            {
                                rndr.ErrorMessage();
                            }

                        } while (!int.TryParse(uChoice, out int b));

                        chMove = Convert.ToInt32(uChoice);

                        if (chMove <= 0 || chMove > 9 || chMove == 5)
                        {
                            rndr.ErrorMessage();
                        }

                    } while (chMove <= 0 || chMove > 9 || chMove == 5);

                    // Actual movement
                    pA.Move(player, chMove, rows, col);

                    break;

                // Quit program
                case "q":
                    rndr.LeaveGame();
                    break;

                default:
                    rndr.ErrorMessage();
                    break;
            }
        }

        /// <summary>
        /// Accepts map dimensions and objects
        /// Calls NewLevel if player's pos is equal to Exit
        /// </summary>
        /// <param name="player"></param>
        /// <param name="exit"></param>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        public void ExitChecker
            (Player player, Exit exit, int col, int rows)
        {
            if(player.Xpos == exit.Xpos && player.Ypos == exit.Ypos)
            {
                NewLevel(player, exit, col, rows);
            }
        }

        /// <summary>
        /// Re-Spawns exit and player in new level
        /// </summary>
        /// <param name="player"></param>
        /// <param name="exit"></param>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        public void NewLevel(Player player, Exit exit, int col, int rows)
        {
            // Level up
            player.Lvl++;

            // Reset position
            player.SpawnPlayer(RanBtw(1, rows));
            exit.SpawnExit(RanBtw(1, rows), col);
        }

        /// <summary>
        /// Random number generator between 0 and given max value.
        /// </summary>
        /// <param name="min"> Min intager value given by user. </param>
        /// <param name="max"> Max intager value given by user. </param>
        /// <returns> Returns random number between given values. </returns>
        public int RanBtw(int min, int max)
        {
            int ran = rnd.Next(min, max);
            return ran;
        }
    }
}
