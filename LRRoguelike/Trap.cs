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
        }
    }
}
