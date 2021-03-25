using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Mobility : GameObject, IMoveable
    {
        //Fields
        private bool coolDown;
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
        public Mobility(Texture2D texture, Rectangle transform, 
                        List<Rectangle> collisionBoxes, bool active, 
                        Vector2 velocity)
                        : base(texture, transform, collisionBoxes, active)
        {
            coolDown = false;
            this.velocity = velocity;
        }
        //Methods
        public void Active() { }

        public virtual void Move()
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
