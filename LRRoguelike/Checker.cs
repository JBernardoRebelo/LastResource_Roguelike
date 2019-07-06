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
            (string option, Player player, MapItem map,
            List<MapComponents> mapComps, int rows, int col)
        {
            string uChoice;
            int chMove;

            switch (option)
            {
                // Looks around
                case "l":
                    pA.LookAround(mapComps, player);
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
                case "e":
                    // Pick up item
                    pA.PickUpItem(player, map, mapComps);

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

        /// <summary>
        /// Accepts map and exit, checks map position
        /// Returns false if map and exit have the same position
        /// </summary>
        /// <param name="map"></param>
        /// <param name="exit"></param>
        public bool ComponentPosChecker(MapItem map, Exit exit)
        {
            if (map.Xpos == exit.Xpos && map.Ypos == exit.Xpos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
