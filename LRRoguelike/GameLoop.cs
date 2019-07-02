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
        // Variables
        Render rndr = new Render();

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
                MenuChecker(option, player);



                // End of turn
                // Player looses 1 hp
                player.HP--;
            }
        }

        /// <summary>
        /// Accepts a string and calls adequate methods
        /// </summary>
        /// <param name="option"></param>
        public void MenuChecker(string option, Player player)
        {
            string chMove;

            switch (option)
            {
                case "l":
                    // Looks around

                    break;

                case "m":
                    // Move
                    rndr.MoveMenu();

                    // Assign's user's choice
                    chMove = Console.ReadLine();
                    player.Move(chMove);

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
