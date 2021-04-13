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
        }

        //Methods
        public void Move() { }

        //There should be a method to 
        //check for input to raise the shield.
        public void ProcessInput()
        {

        }
    }
}
