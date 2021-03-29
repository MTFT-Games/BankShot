﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class GameObject
    {
        //Fields
        private bool active;
        protected Rectangle rect;
        protected Texture2D texture;
        protected List<Rectangle> collisionBoxes;
        protected Vector2 position;

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
        public Rectangle Rect
        {
            get
            {
                return rect;
            }
            set
            {
                rect = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        //Constructor 
        public GameObject(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active)
        {
            this.texture = texture;
            this.rect = transform;
            this.collisionBoxes = collisionBoxes;
            collisionBoxes.Add(transform);
            this.active = active;
            position = new Vector2(transform.X, transform.Y);
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