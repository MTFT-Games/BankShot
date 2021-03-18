using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    interface IDamageable
    {
        //damageable objects must have a boolean to determine invincibility
        bool invincible { get; }

        //damageable objects must have an int holding their max health
        int maxHealth { get; }

        //damageable objects must have an int holding their current health
        int health { get; }

        //damageable objects must have a double holding the length of 
        //their invincibility period
        Double invincibleTime { get; }

        /// <summary>
        /// all damageable objects are to have a method that allows
        /// them to take damage.
        /// this method takes in a number of the damage done, as well as
        /// the knockback value
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="knockback"></param>
        void TakeDamage(int damage, int knockback);

        /// <summary>
        /// all damageable objects are to have a method that governs healing
        /// takes in the amount of health gained
        /// </summary>
        /// <param name="healing"></param>
        void Heal(int healing);

    }
}
