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
        public void StartGame(int length, int height, Player player)
        {
            rndr.MainMenu();
            Loop(length, height, player);
        }

        /// <summary>
        /// Game loop, accepts map dimensions
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void Loop(int length, int height, Player player)
        {
            string option;

            while(player.HP > 0)
            {
                // Print board
                rndr.PrintBoard(length, height);
                //rndr.PlacePart(height, player);

                // Show Options
                rndr.GameloopMenu(player);

                option = Console.ReadLine();
                MenuChecker(option, player, length, height);

                // End of turn
                // Player looses 1 hp
                player.HP--;
            }
        }

        /// <summary>
        /// Accepts a string and calls adequate methods
        /// </summary>
        /// <param name="option"></param>
        public void MenuChecker
            (string option, Player player, int height, int length)
        {
            string chMove;

            switch (option)
            {
                case "l":
                    // Looks around
                    pA.LookAround();
                    break;

                case "m":
                    // Move
                    rndr.MoveMenu();

                    // Assign's user's choice
                    chMove = Console.ReadLine();
                    pA.Move(player, chMove, height, length);

                    break;
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
