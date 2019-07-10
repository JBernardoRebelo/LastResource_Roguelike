using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
    /// <summary>
    /// Trap component, deals damage to Players
    /// </summary>
    public class Trap : MapComponents
    {
        /// <summary>
        /// Max damage of trap, between 0 - 100
        /// </summary>
        public int MaxDamage { get; set; }

        /// <summary>
        /// Indidactes if player has fallen into trap
        /// </summary>
        public bool FallenInto { get; set; }

        /// <summary>
        /// Set trap type
        /// </summary>
        public TrapType Type { get; set; }

        /// <summary>
        /// Trap constructor, accepts map dimensions and seed for damage
        /// Assigns position and max Damage
        /// </summary>
        /// <param name="x"> Trap's x (Collums) position. </param>
        /// <param name="y"> Trap's y (Rows) position. </param> 
        /// <param name="mD"> Max damage the trap can deal. </param>
        public Trap(int x, int y, int mD)
        {
            Xpos = x;
            Ypos = y;
            MaxDamage = mD;
            FallenInto = false;

            // Define type based on damage
            if (mD <= 100 && mD >= 80)
            {
                Type = TrapType.Blades;
            }
            else if (mD < 80 && mD > 40)
            {
                Type = TrapType.Net;
            }
            else
            {
                Type = TrapType.Whole;
            }
        }

        /// <summary>
        /// Prints Trap's token in position according to discovered or not
        /// </summary>
        /// <returns> Designated character for representation. </returns>
        public char PrintTrap()
        {
            if (isDisc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return 'T';
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return '#';
            }
        }
    }
}
