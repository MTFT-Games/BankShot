using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    class Gun : Weapon
    {
        //Fields

        //Projectile Stats:
        private bool interceptable;
        private double lifeSpan;
        private Vector2 velocity;

        //Methods

        //Attack() will create a Projectile object
        //using the Gun's fields as parameters.
        public override void Attack() 
        { 
            base.Attack(); 
        }
    }
}
