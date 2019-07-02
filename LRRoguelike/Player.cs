using System;

namespace LRRoguelike
{
    /// <summary>
    /// Player, has a position, HP and moves
    /// </summary>
    public class Player
    {
        // Properties
        /// <summary>
        /// Player's HP, to be decremented in each turn
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Player's X position in map
        /// </summary>
        public int Xpos { get; set; }

        /// <summary>
        /// Player's Y position in map
        /// </summary>
        public int Ypos { get; set; }

        /// <summary>
        /// Player constructor, assigns HP and Y to given random value
        /// </summary>
        public Player (int y)
        {
            // Assigning HP to random
            HP = 100;

            // Initializing pos to random in first column
            Xpos = 2;

            // Assigning Y to random
            Ypos = y; 

        }

        /// <summary>
        /// Accepts input from user and moves
        /// </summary>
        /// <param name="chMove"></param>
        public void Move(string chMove, int height, int length)
        {
            switch (chMove)
            {
                case "7":
                    // Up left
                    break;

                // Up
                case "8":
                    // Wall
                    if(Ypos < height)
                    {
                        Ypos = Ypos;
                    }
                    // Moves
                    else
                    {
                        Ypos--;
                    }
                    break;

                case "9":
                    // Up right
                    break;

                // Left
                case "4":
                    // Wall
                    if (Xpos < length)
                    {
                        Xpos = Xpos;
                    }
                    // Moves
                    else
                    {
                        Xpos--;
                    }
                    break;

                // Right
                case "6":
                    // Wall
                    if (Xpos > length)
                    {
                        Xpos = Xpos;
                    }
                    // Moves
                    else
                    {
                        Xpos++;
                    }
                    break;

                case "1":
                    // Down left
                    break;

                // Down
                case "2":
                    // Wall
                    if (Ypos > height)
                    {
                        Ypos = Ypos;
                    }
                    // Moves
                    else
                    {
                        Ypos++;
                    }
                    break;

                case "3":
                    // Down Right
                    break;

                default:
                    
                    break;
            }
        }

        public void LookAround()
        {
            Console.Read();
        }

        /// <summary>
        /// Prints player's token in position
        /// </summary>
        /// <returns></returns>
        public char PrintPlayer() => '⨀';
    }
}
