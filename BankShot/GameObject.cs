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
        private Rectangle rect;
        private Texture2D texture;
        private List<Rectangle> collisionBoxes;

        //Properties
        public int X
        {
            get
            {
                return rect.X;
            }
            set
            {
                rect.X = value;
            }
        }
        public int Y
        {
            get
            {
                return rect.Y;
            }
            set
            {
                rect.Y = value;
            }
        }

        //Constructor 
        public GameObject(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active)
        {
            this.texture = texture;
            this.rect = transform;
            this.collisionBoxes = collisionBoxes;
            this.active = active;
        }

        //Methods
        public virtual void Update() { }

        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }

        //There should be a method to check collisons
        //We just don't have it explicitly written yet.
    }
}
