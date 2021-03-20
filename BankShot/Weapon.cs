using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Weapon : GameObject, IMoveable
    {
        //Fields
        protected int damage;
        protected int knockback;
        protected Vector2 velocity;

        //Properties
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

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
