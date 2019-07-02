﻿using System;

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
                    Console.WriteLine("Goodbye! See you soon...");
                    Environment.Exit(0);
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
            // Show 
            Console.WriteLine("Current HP: " + player.HP);

            Console.WriteLine("Choose your options: ");
            Console.WriteLine("L -> Look around");
            Console.WriteLine(" Move");
            Console.WriteLine("Q -> Quit game");
        }

        /// <summary>
        /// Prints board, accepts args converted from console
        /// </summary>
        /// <param name="length"> GameSettings Collums value. </param>
        /// <param name="height"> GameSettings Row value. </param>
        public void PrintBoard(int length, int height)
        {
            //Console.Clear();
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


        public void PlacePart(int height, Player player)
        {
            // Vars
            int[] normalizedPos = NormalizePosition(player.Xpos, player.Ypos);

            // Cursor
            Console.SetCursorPosition(normalizedPos[0], normalizedPos[1]);

            Console.WriteLine(player.PrintPlayer());

            Console.SetCursorPosition(0, 0);

        }

        /// <summary>
        /// Normalize object's position to be printed on console
        /// </summary>
        /// <param name="x"> Object's Xpos value. </param>
        /// <param name="y"> Object's Ypos value. </param>
        /// <returns> Intager array that contains a normalized </returns>
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

        public void PlaceMenus(int height)
        {
            for (int i = 0; i < height * 2.25f ; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
