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
            switch (GetUserInput())
            {
                // Start game
                case 1:
                    Console.Clear();
                    Console.WriteLine("Let's play");
                    // goes to game loop
                    break;

                // Show credits
                case 2:
                    Credits();
                    break;

                // Leaves program 
                case 3:
                    Console.WriteLine("Goodbye! See you soon...");
                    break;

                // Case invalid choice is entered
                default:
                    ErrorMessage();
                    break;
            }
        }

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
            Console.WriteLine("Press anything to go back to Start Menu...");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        /// <summary>
        /// Method to get and verify user input in menus
        /// </summary>
        private int GetUserInput()
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
        /// Method to print error message
        /// </summary>
        private void ErrorMessage()
        {
            Console.WriteLine("Invalid option...");
        }
    }
}
