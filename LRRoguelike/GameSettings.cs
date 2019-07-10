using System;

namespace LRRoguelike
{
    /// <summary>
    /// Class that is used do define game configurations
    /// </summary>
    public class GameSettings
    {
        // Instance variables
        Render rndr = new Render();

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
            // Check if array lenght is valid
            CheckInvalidInput(args);

            // Run through all console arguments...
            for (int i = 0; i < args.Length; i++)
            {
                // ... if args[i] is "-r", assign next index argument value
                if (args[i] == "-r")
                {
                    if (!int.TryParse(args[i + 1], out int x))
                    {
                        rndr.InputErrorMessage();
                    }

                    Rows = Convert.ToInt32(args[i + 1]);
                }

                // ... if args[i] is "-c", assign next index argument value
                if (args[i] == "-c")
                {
                    if (!int.TryParse(args[i + 1], out int x))
                    {
                        rndr.InputErrorMessage();
                    }

                    Collums = Convert.ToInt32(args[i + 1]);
                }
            }

            // Check if array lenght is valid
            CheckInvalidInput(Rows, Collums);
        }

        /// <summary>
        /// Method that verifies invalid number of console arguments.
        /// </summary>
        /// <param name="args"> Console arguments. </param>
        private void CheckInvalidInput(string[] args)
        {
            if (args.Length < 4)
            {
                rndr.InputErrorMessage();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Overload of CheckInvalidInput() that verifies if map size values 
        /// are sufficient to create a grid.
        /// </summary>
        /// <param name="row"> GameSettings property Row. </param>
        /// <param name="collum"> GameSettings property Collums. </param>
        private void CheckInvalidInput(int row, int collum)
        {
            if (Rows == 0 || Rows == 1 || Collums == 0 || Collums == 1)
            {
                rndr.InputErrorMessage();
                Environment.Exit(0);
            }
        }

    }
}
