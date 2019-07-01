using System;

namespace LRRoguelike
{
    /// <summary>
    /// Output text to user
    /// </summary>
    public class Render
    {
        /// <summary>
        /// Output Start Menu, options included
        /// </summary>
        public void MainMenu()
        {
            // Player choice to navigate menus
            int choice;

            // Output to user
            Console.WriteLine("1. New Game;");
            Console.WriteLine("2. Credits;");
            Console.WriteLine("3. Quit;");

            // Convert input
            choice = Convert.ToInt32(Console.ReadLine());

            // Pick choice
            switch (choice)
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
                    Console.WriteLine("Invalid choice, goodbye...");
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
    }
}
