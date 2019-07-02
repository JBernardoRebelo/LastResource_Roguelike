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
            while(player.HP > 0)
            {
                // Print board
                rndr.PrintBoard(length, height);

                // Options

                    // Move
                    // Look Around

                // End of turn
                // Player looses 1 hp
                player.HP--;
            }
        }

    }
}
