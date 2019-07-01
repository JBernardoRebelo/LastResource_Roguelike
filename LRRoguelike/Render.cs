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
        public void StartMenu()
        {
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
        /// Prints board, accepts args converted from console
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void PrintBoard(int length, int height)
        {
            Console.Clear();
            // For cicle to print map
            for (int k = 0; k < length * 4 + 1; k++)
                Console.Write("-");

            // New line
            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("|   ");
                }

                Console.WriteLine('|');

                for (int k = 0; k < length * 4 + 1; k++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
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
            StartMenu();
        }
    }
}
