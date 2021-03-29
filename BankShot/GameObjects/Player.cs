﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Player : Character
    {
        //Fields
        private Mobility mobility;
        private Weapon weapon;
        private Shield shield;

        //Player Stats will also be included as Fields

        //Default Contructor
        public Player(Texture2D texture, Rectangle transform, 
                      List<Rectangle> collisionBoxes, bool active, 
                      int maxHealth, Vector2 velocity) 
                      : base(texture, transform, collisionBoxes, active, 
                             maxHealth, velocity) { }

        //Methods
        public override void Update()
        {
            this.ProcessInput();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Move()
        {
            this.ApplyGravity();
            base.Move();
        }

        public void ProcessInput()
        {
            velocity.X = 0;
            if (Input.KeyHeld(Keys.A)) //&& velocity.X != -5)
            {
                velocity.X -= 5;
            }
            if (Input.KeyHeld(Keys.D)) //&& velocity.X != 5)
            {
                velocity.X += 5;
            }
            if (Input.KeyClick(Keys.W))
            {
                velocity.Y = -20;
            }
        }

        public void ApplyGravity()
        {
            velocity += new Vector2(0, 1);
        }

        //The collison checking method in GameObject might
        //also be overridden here.
    }
}