using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class GameObject
    {
        //Fields
        private bool active;
        private Rectangle transform;
        private Texture2D texture;
        private List<Rectangle> collisionBoxes;

        //Properties
        public int X
        {
            get
            {
                return transform.X;
            }
            set
            {
                transform.X = value;
            }
        }
        public int Y
        {
            get
            {
                return transform.Y;
            }
            set
            {
                transform.Y = value;
            }
        }

        //Methods
        public virtual void Update() { }

        public virtual void Draw() { }

        //There should be a method to check collisons
        //We just don't have it explicitly written yet.
    }
}
