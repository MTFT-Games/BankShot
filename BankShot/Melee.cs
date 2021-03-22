using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Melee : Weapon
    {
        //Fields

        //Parameterized Constructor
        public Melee(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback)
                      : base(texture, transform, collisionBoxes, 
                             active, damage, knockback)
        {

        }

        //Methods

        //Displays the weapon’s melee animation and 
        //moves its collision boxes to the position it’s hitting
        public override void Attack()
        {
            base.Attack();
        }
    }
}
