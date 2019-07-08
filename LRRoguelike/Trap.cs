using System;
using System.Collections.Generic;
using System.Text;

namespace LRRoguelike
{
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
        public TrapType Type{ get; set; }

        /// <summary>
        /// Trap constructor, accepts map dimensions and seed for damage
        /// Assigns position and max Damage
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param> 
        /// <param name="mD"></param>
        public Trap(int x, int y, int mD)
        {
            Xpos = x;
            Ypos = y;
            MaxDamage = mD;

            // Define type based on damage
            if(mD <= 100 && mD >= 80)
            {
                Type = TrapType.Blades;
            }
            else if(mD < 80 && mD > 40)
            {
                Type = TrapType.Net;
            }
            else
            {
                Type = TrapType.Whole;
            }
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Trap()
        {

        }

        /// <summary>
        /// Prints Trap's token in position according to discovered or not
        /// </summary>
        /// <returns></returns>
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
