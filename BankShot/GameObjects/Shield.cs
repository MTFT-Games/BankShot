using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Shield : GameObject, IMoveable
    {
        //Fields
        protected Vector2 velocity;
        private bool active;
        private double timeSinceBreak;

        public bool Active
        {
            get
            {
                return active;
            }
        }

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
        public Shield(Texture2D texture, Rectangle transform, 
                      List<Rectangle> collisionBoxes, bool active, 
                      Vector2 velocity)
                      : base(texture, transform, collisionBoxes, active)
        {
            this.velocity = velocity;
            timeSinceBreak = 4;

        }

        //Methods
        public void Move()
        {
            position += velocity;
        }

        //There should be a method to 
        //check for input to raise the shield.
        public void ProcessInput()
        {
            if (Input.MouseHeld(2) && timeSinceBreak >= 2.5)
            {
                active = true;
            }
            else
            {
                active = false;
            }
        }

        public void Update(GameTime time)
        {
            ProcessInput();
            this.Move();
            X = (int)position.X;
            Y = (int)position.Y;
            timeSinceBreak += time.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                base.Draw(spriteBatch);
            }
        }

        public void BreakShield()
        {
            timeSinceBreak = 0;
            active = false;
        }
    }
}
