using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Weapon : GameObject, IMovable
    {
        //Fields
        protected int damage;
        protected int knockback;

        //Parameterized Constructor
        public Weapon(Texture2D texture, Rectangle transform, 
                      List<Rectangle> collisionBoxes, bool active, 
                      int damage, int knockback) 
                      : base(texture, transform, collisionBoxes, active)
        {
            this.damage = damage;
            this.knockback = knockback;
        }

        //Methods
        public virtual void Attack() { }

        public void Move() { }
    }
}
