using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    /// <summary>
    /// Runs game, controls turns
    /// </summary>
    public class GameLoop
    { 
        // Instantiate Classes
        Render rndr = new Render();
        PlayerActions pA = new PlayerActions();

        /// <summary>
        /// Shows start menu, redirects to Loop
        /// </summary>
        /// <param name="length"> GameSettings Collums value. </param>
        /// <param name="height"> GameSettings Rows value. </param>
        /// <param name="player"> Program user. </param>
        /// /// <param name="exit"> Program user. </param>
        public void StartGame(int length, int height, Player player, Exit exit)
        {
            rndr.MainMenu();
            Loop(length, height, player, exit);

        }

        /// <summary>
        /// Game loop, accepts map dimensions
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void Loop(int length, int height, Player player, Exit exit)
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
                rndr.PrintBoard(length, height);
                
                // Place player
                rndr.PlacePart(height, player);
                
                // Place exit
                rndr.PlacePart(height, exit);


                // Options
                rndr.PlaceMenus(height);
                rndr.GameloopMenu(player);
                // Look around Move

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


                MenuChecker(option, player, length, height);

                // End of turn
                // Player looses 1 hp reset valInput value
                player.HP--;
                valInput = false;
            }
        }

        /// <summary>
        /// Accepts a string and calls adequate methods
        /// </summary>
        /// <param name="option"> User input. </param>
        /// <param name="player"> Program user. </param>
        /// <param name="height"> GameSettings Rows value. </param>
        /// <param name="length"> GameSettings Collums value. </param>
        public void MenuChecker
            (string option, Player player, int height, int length)
        {
            string uChoice;
            int chMove;

            switch (option)
            {
                // Looks around
                case "l":
                    pA.LookAround();
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
                    pA.Move(player, chMove, height, length);

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
    }
}
