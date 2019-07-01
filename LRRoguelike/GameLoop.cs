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
        public void StartGame(int length, int height)
        {
            rndr.StartMenu();
            Loop(length, height);
        }

        /// <summary>
        /// Game loop, accepts map dimensions
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void Loop(int length, int height)
        {
            // Print board
            rndr.PrintBoard(length, height);
        }

    }
}
