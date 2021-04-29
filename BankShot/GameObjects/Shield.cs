using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Shield : GameObject, IMoveable
    {
        //Fields
        private int health;
        private int maxHealth;
        protected Vector2 velocity;
        private bool active;
        private double timeSinceBreak;
        private double coolDown;
        private float regenRate;

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

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }

        public double CoolDown
        {
            get
            {
                return coolDown;
            }

            set
            {
                coolDown = value;
            }
        }

        public float RegenRate
        {
            get
            {
                return regenRate;
            }

            set
            {
                regenRate = value;
            }
        }

        //Parameterized Constructor
        public Shield(Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      Vector2 velocity, double coolDown)
                      : base(Program.game.Content.Load<Texture2D>("Shield"), transform, collisionBoxes, active)
        {
            this.coolDown = coolDown;
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
            if (Input.MouseHeld(2) && timeSinceBreak >= coolDown && Game1.player.CurrentKnockback.X == 0)
            {
                active = true;
            } else
            {
                active = false;
            }
        }

        public void Update(GameTime time)
        {
            ProcessInput();
            Move();
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
