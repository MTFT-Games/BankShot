using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public interface IDamages
    {

        /// <summary>
        /// objects that deal damage must have a method that takes in the 
        /// object being damaged.
        /// </summary>
        /// <param name="target"></param>
        void DealDamage(IDamageable target);

    }
}
