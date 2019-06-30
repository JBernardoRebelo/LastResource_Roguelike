using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    public class Render
    {
        public void StartMenu()
        {
            int choice;
            Console.WriteLine("1. New Game;");
            Console.WriteLine("2. Credits;");
            Console.WriteLine("3. Quit;");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    Console.Clear();
                    Console.WriteLine("Let's play");
                    // goes to game loop
                    break;

                case 2:
                    Credits();
                    break;

                case 3:
                    Console.WriteLine("Goodbye! See you soon...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, goodbye...");
                    break;
            }
        }

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
