using System;

namespace LRRoguelike
{
    /// <summary>
    /// Output text to user
    /// </summary>
    public class Render
    {
        /// <summary>
        /// Output Initial/Main Menu, options included
        /// </summary>
        public void MainMenu()
        {

            // Output to user
            Console.WriteLine("\nPress...");
            Console.WriteLine("1 -> New Game");
            Console.WriteLine("2 -> Credits");
            Console.WriteLine("3 -> Quit");

            // Pick choice
            switch (UserMenuInput())
            {
                // Start game
                case 1:
                    //Console.Clear();
                    Console.WriteLine("Let's play");
                    // goes to game loop
                    break;

                // Show credits
                case 2:
                    Credits();
                    break;

                // Leaves program 
                case 3:
                    LeaveGame();
                    break;

                // Case invalid choice is entered
                default:
                    ErrorMessage();
                    Environment.Exit(0);
                    break;
            }
        }

        /// <summary>
        /// Shows in-game player menu.
        /// </summary>
        /// <param name="player"> Program user. </param>
        public void GameloopMenu(Player player)
        {
            // Show stats
            Console.WriteLine("______________ Stats ______________");
            Console.WriteLine("Current HP: " + player.HP);
            /*  DEBUG  */
            Console.WriteLine("Player's X: {0} and Y: {1}", player.Xpos, player.Ypos);
            /*  !DEBUG */
            Console.WriteLine();

            // Options menu
            Console.WriteLine("______________ Options _____________");
            Console.WriteLine("Choose your options: ");
            Console.WriteLine("L -> Look around");
            Console.WriteLine("M -> Move");
            Console.WriteLine("Q -> Quit game \n");

            // Legend
            Console.WriteLine("______________ Legend ______________");
            Console.WriteLine("⨀ -> Player");
            Console.WriteLine("✚ -> Exit \n");
        }

        /// <summary>
        /// Shows move instructions
        /// </summary>
        public void MoveMenu()
        {
            Console.WriteLine("______________ Move Menu ____________");
            Console.WriteLine("Keys to move: ");
            Console.WriteLine("7 = ↖");
            Console.WriteLine("8 = ↑");
            Console.WriteLine("9 = ↗");
            Console.WriteLine("4 = ←");
            Console.WriteLine("6 = →");
            Console.WriteLine("1 = ↙");
            Console.WriteLine("2 = ↓");
            Console.WriteLine("3 = ↘");
        }

        /// <summary>
        /// Prints board, accepts args converted from console
        /// </summary>
        /// <param name="col"> GameSettings Collums value. </param>
        /// <param name="rows"> GameSettings Row value. </param>
        public void PrintBoard(int col, int rows)
        {
            //Console.Clear();
            // For cicle to print map
            for (int k = 0; k < col * 4 + 1; k++)
                Console.Write("-");

            // New line
            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("|   ");
                }

                Console.WriteLine('|');

                for (int k = 0; k < col * 4 + 1; k++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method to print object character representation in correct position
        /// </summary>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="player"> Program user. </param>
        public void PlacePart(int rows, Player player)
        {
            // Vars
            int[] normalizedPos = NormalizePosition(player.Xpos, player.Ypos);

            // Cursor
            Console.SetCursorPosition(normalizedPos[0], normalizedPos[1]);

            Console.WriteLine(player.PrintPlayer());

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Overload, print object representation in correct position
        /// </summary>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="exit"> Program user. </param>
        public void PlacePart(int rows, Exit exit)
        {
            // Vars
            int[] normalizedPos = NormalizePosition(exit.Xpos, exit.Ypos);

            // Cursor
            Console.SetCursorPosition(normalizedPos[0], normalizedPos[1]);

            Console.WriteLine(exit.PrintExit());

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Normalize object's position to be printed on console
        /// </summary>
        /// <param name="x"> Object's Xpos value. </param>
        /// <param name="y"> Object's Ypos value. </param>
        /// <returns> Integer array that contains a normalized. </returns>
        private static int[] NormalizePosition(int x, int y) =>
            new int[2] { x * 4 - 2, y * 2 - 1 };

        /// <summary>
        /// Output credits, goes back to Start Menu
        /// </summary>
        public void Credits()
        {
            // Shows credits
            Console.WriteLine("This project was made by: ");
            Console.WriteLine("[Insert person 1 here];");
            Console.WriteLine("[Insert person 2 here];");

            // Goes back to start menu if user enters any key
            Console.WriteLine("Type to go back to Start Menu...");
            Console.Read();
            //Console.Clear();
            MainMenu();
        }

        /// <summary>
        /// Method to get and verify user input in menus
        /// </summary>
        private int UserMenuInput()
        {
            // Block variables
            string uInput;
            bool canConvert;
            int choice;

            // Does not continue program while input is invalid or
            // cannot be converted
            do
            {
                // Ask for input
                Console.Write("\nSelect your option: ");
                uInput = Console.ReadLine();

                // Verify if can convert to int32
                canConvert = int.TryParse(uInput, out choice);

            } while (!canConvert || choice > 3 || choice < 1);

            // Return converted uInput
            return choice;
        }

        /// <summary>
        /// Leaves game with a goodbye message
        /// </summary>
        public void LeaveGame()
        {
            Console.WriteLine("Goodbye! See you soon...");
            Environment.Exit(0);
        }

        /// <summary>
        /// Method to print error message
        /// </summary>
        public void ErrorMessage()
        {
            Console.WriteLine("Invalid option...");
        }

        /// <summary>
        /// Warns player he moved against a wall
        /// </summary>
        public void AgainstWall()
        {
            Console.WriteLine("You moved against a wall");
        }

        /// <summary>
        /// Method to position menus in the correct position 
        /// relative to the board
        /// </summary>
        /// <param name="rows"> GameSettings Rows value. </param>
        public void PlaceMenus(int rows)
        {
            for (int i = 0; i < rows * 2.25f ; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
