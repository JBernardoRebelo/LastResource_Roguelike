﻿using System;
using System.Threading;

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
            //Console.Clear();

            // Output to user
            Console.WriteLine("\nPress...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 -> New Game");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("2 -> Credits");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3 -> Quit");
            Console.ResetColor();

            // Pick choice
            switch (UserMenuInput())
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
            // Change console color to green
            Console.ForegroundColor = ConsoleColor.Blue;
            // Show stats
            Console.WriteLine(" »»»»»»»»»»»» Stats »»»»»»»»»»»»");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         Current HP: " + player.HP);
            Console.WriteLine("         Level: " + player.Lvl);
            Console.WriteLine("         X position: {0}", player.Xpos);
            Console.WriteLine("         Y position: {0}", player.Ypos + "\n");

            // Change Console color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Options menu
            Console.WriteLine(" ___________ Options ___________");
            Console.WriteLine("|                               |");
            Console.WriteLine("| (m) -> Move                   |");
            Console.WriteLine("| (l) -> Look around            |");
            Console.WriteLine("| (e) -> Pick up item           |");
            Console.WriteLine("| (h) -> Help                   |");
            Console.WriteLine("| (q) -> Quit game              |");
            Console.WriteLine("|_______________________________|\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            // Legend
            Console.WriteLine(" ___________ Legend ____________");
            // Player
            Console.Write("| ");
            LegendSet('p');
            Console.WriteLine("                   |");
            // Exit
            Console.Write("| ");
            LegendSet('e');
            Console.WriteLine("                     |");
            // Discovered
            Console.Write("| ");
            LegendSet('d');
            Console.WriteLine("                |");
            // Uncovered
            Console.Write("| ");
            LegendSet('u');
            Console.WriteLine("             |");
            // Map
            Console.Write("| ");
            LegendSet('m');
            Console.WriteLine("                      |");
            // Map
            Console.Write("| ");
            LegendSet('t');
            Console.WriteLine("                     |");
            Console.WriteLine("|_______________________________|\n");

            // Sets console color to default
            Console.ResetColor();
            Console.Write("Your option: ");
        }

        /// <summary>
        /// Shows move instructions
        /// </summary>
        public void MoveMenu()
        {
            // Change console color to magenta
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("\n _________ Move Menu ___________");
            Console.WriteLine("| Keys to move:                 |");
            Console.WriteLine("| 7 = ↖  |  8 = ↑  |  9 = ↗     |");
            Console.WriteLine("| 4 = ←  |         |  6 = →     |");
            Console.WriteLine("| 1 = ↙  |  2 = ↓  |  3 = ↘     |");
            Console.WriteLine("|_______________________________|\n");

            // Sets console color to default
            Console.ResetColor();

            Console.Write("Your move: ");
        }

        /// <summary>
        /// Display help menu
        /// </summary>
        public void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n _____________ Help Menu _____________");
            Console.WriteLine("| There are 3 kinds of traps:         |");
            Console.WriteLine("| -> Whole traps: Deal up to 40 dmg   |");
            Console.WriteLine("| -> Net traps: Deal up to 80 dmg     |");
            Console.WriteLine("| -> Blades traps: Deal up to 100 dmg |");
            Console.WriteLine("|_____________________________________|\n");
            Console.ResetColor();
            Thread.Sleep(5000);
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
        /// Draws objects on map, accepts all components so far
        /// </summary>
        /// <param name="player"> Program user. </param>
        /// <param name="exit"> Level exit. </param>
        /// <param name="map"> Map item. </param>
        public void PlaceParts(Player player, Exit exit,
            MapItem map)
        {
            // Doesn't place map if is Used
            if (!map.Used)
            {
                // Map
                int[] normalizedPosM = NormalizePosition(map.Xpos, map.Ypos);
                Console.SetCursorPosition(normalizedPosM[0], normalizedPosM[1]);
                Console.WriteLine(map.PrintMapItem());
            }

            // Player
            int[] normalizedPosP = NormalizePosition(player.Xpos, player.Ypos);
            Console.SetCursorPosition(normalizedPosP[0], normalizedPosP[1]);
            Console.WriteLine(player.PrintPlayer());

            // Exit
            int[] normalizedPosE = NormalizePosition(exit.Xpos, exit.Ypos);
            Console.SetCursorPosition(normalizedPosE[0], normalizedPosE[1]);
            Console.WriteLine(exit.PrintExit());
        }

        /// <summary>
        /// Accepts and draws trap in map.
        /// </summary>
        /// <param name="trap"> Trap object instance. </param>
        public void FillMap(Trap trap)
        {
            int[] normalizedPosT = NormalizePosition(trap.Xpos, trap.Ypos);
            Console.SetCursorPosition(normalizedPosT[0], normalizedPosT[1]);
            Console.WriteLine(trap.PrintTrap());
        }

        /// <summary>
        /// Overload Accepts and draws component in map
        /// </summary>
        /// <param name="mapComp"> Specific map component to be printed
        /// on board. </param>
        public void FillMap(MapComponents mapComp)
        {
            int[] normalizedPos = NormalizePosition(mapComp.Xpos, mapComp.Ypos);
            Console.SetCursorPosition(normalizedPos[0], normalizedPos[1]);
            Console.WriteLine(mapComp.PrintPart());
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            // Shows credits
            Console.WriteLine("This project was made by: \n");
            Console.WriteLine("  -> João Rebelo;");
            Console.WriteLine("  -> Miguel Fernández;\n");
            Console.ResetColor();

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
        /// Accepts a map component and show's it's description
        /// </summary>
        /// <param name="mp"> Specific map component for info to be
        /// printed. </param>
        public void ItemDescription(MapComponents mp)
        {
            Message();
            Console.WriteLine("There's a" + mp + "\n");
            Console.Read();
        }

        /// <summary>
        /// Leaves game with a goodbye message
        /// </summary>
        public void LeaveGame()
        {
            Message();
            Console.WriteLine(" Goodbye! See you soon...\n");
            Environment.Exit(0);
        }

        /// <summary>
        /// Outputs message of death and shows level of death
        /// </summary>
        /// <param name="player"> Program user. </param>
        public void PlayerDeath(Player player)
        {
            Message();
            Console.WriteLine(" You died on level " + player.Lvl + ".");
            Console.WriteLine(" Goodbye...\n");
            Console.Read();
        }

        /// <summary>
        /// Outputs message of next level
        /// </summary>
        public void NextLevel()
        {
            Message();
            Console.Write(" You found the exit");
            Console.Write(" and passed to the next Level!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Method to print error message
        /// </summary>
        public void ErrorMessage()
        {
            Message();
            Console.WriteLine(" Invalid option...\n");
            Console.Write("Try again: ");
        }

        /// <summary>
        /// Warns player he moved against a wall
        /// </summary>
        public void AgainstWall()
        {
            Message();
            Console.WriteLine(" You wasted a turn moving against a wall...\n");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Method to position menus in the correct position 
        /// relative to the board
        /// </summary>
        /// <param name="rows"> GameSettings Rows value. </param>
        public void PlaceMenus(int rows)
        {
            for (int i = 0; i < rows * 1.8f; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints message in red
        /// </summary>
        private void Message()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n** Message:");
            Console.ResetColor();
        }

        /// <summary>
        /// Accepts a position and describes exit in it's position
        /// </summary>
        /// <param name="x"> Exits's x (Collums) position. </param>
        /// <param name="y"> Exits's y (Rows) position. </param>
        public void FoundExit(int x, int y)
        {
            Message();
            Console.Write
                ($" You discovered the Exit at position X:{x} Y:{y}! ");
            Console.WriteLine("Enter to proceed to the next Level!");
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Accepts a position and describes map in it's position
        /// </summary>
        /// <param name="x"> Map's x (Collums) position. </param>
        /// <param name="y"> Map's y (Rows) position. </param>
        public void FoundMap(int x, int y)
        {
            Message();
            Console.Write
                ($" You discovered a Map at position X:{x} Y:{y}! ");
            Console.WriteLine("Catch it to unveil the rest of the Level!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Accepts a position and describes trap in it's position
        /// </summary>
        /// <param name="x"> Trap's x (Collums) position. </param>
        /// <param name="y"> Trap's y (Rows) position. </param>
        /// <param name="trap"> Trap object instance. </param>
        public void FoundTrap(int x, int y, Trap trap)
        {
            Message();
            Console.Write($" You discovered a {trap.Type} ");
            Console.Write($"trap at position X:{trap.Xpos} Y: {trap.Ypos}! ");
            // Output info based of type
            if (trap.Type == TrapType.Whole)
            {
                Console.WriteLine
                    ("Don't fall in to it! It will hurt a little!");
            }
            else if (trap.Type == TrapType.Net)
            {
                Console.Write("Take care, don't be grabed by it or else ");
                Console.WriteLine("you'll lose precious HP!");
            }
            else if (trap.Type == TrapType.Blades)
            {
                Console.Write("Try to dodge those blades, ");
                Console.WriteLine("they'll chop you up and it will hurt a lot!");
            }
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Accepts a trap and a player
        /// Show damage taken by trap
        /// </summary>
        /// <param name="trap"> Trap component (object instance). </param>
        /// <param name="dmg"> Trap's damage. </param>
        public void DamageTaken(Trap trap, int dmg)
        {
            Message();
            Console.Write($"You have fallen into a {trap.Type} trap ");
            Console.WriteLine($"and lost {dmg} HP");
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Print a message if player has fallen into a trap
        /// </summary>
        public void FallenInto()
        {
            Message();
            Console.WriteLine
                (" Fortunately, the trap you're in no longer works!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Decides character to be output in legend
        /// </summary>
        /// <param name="c"> Character whose color will be change to be 
        /// distiguished from chart. </param>
        private void LegendSet(char c)
        {
            if (c == 'p')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("P -> Player");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (c == 'e')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("E -> Exit");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (c == 'd')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  -> Dicovered");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (c == 'u')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("# -> Undiscovered");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (c == 'm')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("M -> Map");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (c == 't')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("T -> Trap");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Output message of map usage
        /// </summary>
        public void UseMap()
        {
            Message();
            Console.Write
                ($" You just used a map, the level will now uncover... ");
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Method to display an error message in case user inputs are invalid
        /// and explains how to use program correctly.
        /// </summary>
        public void InputErrorMessage()
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

        /// <summary>
        /// Displays message to inform player no item can be used.
        /// </summary>
        public void NoItemToUse()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("No item in range to be used... \n" +
                "You still lose 1HP :c");

            Console.ForegroundColor = ConsoleColor.Gray;

            Thread.Sleep(3000);
        }
    }
}
