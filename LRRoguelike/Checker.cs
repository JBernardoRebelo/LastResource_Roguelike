using System;
using System.Collections.Generic;

namespace LRRoguelike
{
    class Checker
    {
        // Instantiate needed classes
        Render rndr = new Render();
        PlayerActions pA = new PlayerActions();

        /// <summary>
        /// Accepts a string and calls adequate methods
        /// </summary>
        /// <param name="option"> User input. </param>
        /// <param name="player"> Program user. </param>
        /// <param name="rows"> GameSettings Rows value. </param>
        /// <param name="col"> GameSettings Collums value. </param>
        public void MenuChecker
            (string option, Player player, List<MapComponents> mp, int rows, int col)
        {
            string uChoice;
            int chMove;

            switch (option)
            {
                // Looks around
                case "l":
                    pA.LookAround(mp, player);
                    // DONT USE TURN LA           
                    break;

                // Move
                case "m":
                    rndr.MoveMenu();

                    // Assign's user's choice
                    do
                    {
                        do
                        {
                            uChoice = Console.ReadLine();

                            if (!int.TryParse(uChoice, out int a))
                            {
                                rndr.ErrorMessage();
                            }

                        } while (!int.TryParse(uChoice, out int b));

                        chMove = Convert.ToInt32(uChoice);

                        if (chMove <= 0 || chMove > 9 || chMove == 5)
                        {
                            rndr.ErrorMessage();
                        }

                    } while (chMove <= 0 || chMove > 9 || chMove == 5);

                    // Actual movement
                    pA.Move(player, chMove, rows, col);

                    break;

                // Quit program
                case "q":
                    rndr.LeaveGame();
                    break;

                default:
                    rndr.ErrorMessage();
                    break;
            }
        }
    }
}
