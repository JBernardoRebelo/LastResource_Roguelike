using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    /// <summary>
    /// Class that is used do define game configurations
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Map total rows
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Map total collums
        /// </summary>
        public int Collums { get; }

        /// <summary>
        /// Class constructor that utilizes console args to initialize game 
        /// variables.
        /// </summary>
        /// <param name="args">Array of strings that are console args</param>
        public GameSettings(string[] args)
        {
            // Run through all console arguments...
            for (int i = 0; i < args.Length; i++)
            {
                // ... if args[i] is "-r", assign next index argument value
                if (args[i] == "-r")
                {
                    Rows = Convert.ToInt32(args[i + 1]);
                }

                // ... if args[i] is "-c", assign next index argument value

                if (args[i] == "-c")
                {
                    Collums = Convert.ToInt32(args[i + 1]);
                }
            }
        }


    }
}
