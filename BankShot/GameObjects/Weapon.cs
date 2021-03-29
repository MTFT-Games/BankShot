using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Weapon : GameObject, IMoveable
    {
        //Fields
        protected int damage;
        protected float knockback;
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
                      int damage, float knockback) 
                      : base(texture, transform, collisionBoxes, active)
        {
            this.damage = damage;
            this.knockback = knockback;
        }

        //Methods
        public virtual void Attack() { }

        public void Move() 
        {
            position += velocity;
        }

        public override void Update()
        {
            this.Move();
            X = (int)position.X;
            Y = (int)position.Y;
        }
    }
}
