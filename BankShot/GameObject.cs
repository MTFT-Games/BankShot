using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    //Michael Robinson
    //GameObject
    //Represents a basic object in the game.
    //This encompasses the player, walls, enemies, 
    //weapons, etc. 
    //All GameObjects have a texture, a rectangle, 
    //collision boxes, and a variable to determine if they are active.
    //They also have methods to draw themselves, update their info,
    //and check for collisions.
    class GameObject
    {
        //Fields
        protected bool active;
        protected Rectangle transform;
        protected  Texture2D texture;
        protected List<Rectangle> collisionBoxes;

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

        //Constructor 
        public GameObject(Texture2D texture, Rectangle transform, 
                          List<Rectangle> collisionBoxes, bool active)
        {
            this.texture = texture;
            this.transform = transform;
            this.collisionBoxes = collisionBoxes;
            this.active = active;
        }

        //Methods
        public virtual void Update() { }

        /// <summary>
        /// Takes in a spritebatch and calls its draw method to draw 
        /// a texture to the screen.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used to draw the texture.</param>
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, transform, Color.White);
        }

        //There should be a method to check collisons
        //We just don't have it explicitly written yet.
    }
}
