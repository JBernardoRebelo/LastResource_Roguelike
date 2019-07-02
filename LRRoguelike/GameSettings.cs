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
                        ErrorMessage();
                    }

                    Rows = Convert.ToInt32(args[i + 1]);
                }

                // ... if args[i] is "-c", assign next index argument value
                if (args[i] == "-c")
                {
                    if (!int.TryParse(args[i + 1], out int x))
                    {
                        ErrorMessage();
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
                ErrorMessage();
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
                ErrorMessage();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Method to display an error message in case user inputs are invalid
        /// and explains how to use program correctly.
        /// </summary>
        private void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nInvalid console arguments..." +
                              "\nFor correct usage, input: " +
                              "\" dotnet run -- " +
                              "-r <Desired number of rows> " +
                              "-c <Desired number of collums>\".\n" +
                              "Map size must be bigger than 1.");

            Console.ForegroundColor = ConsoleColor.Gray;

            Environment.Exit(0);
        }
    }
}
