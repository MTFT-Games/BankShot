using System;
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

        //Just for the demo
        private string weaponSide;

        //Player Stats will also be included as Fields

        //Determines if the player is on the ground
        private bool onGround;
        private bool doubleJump;
        private int jumpsLeft;

        private double knockBack;

        public Weapon CurrentWeapon
        {
            get
            {
                return weapon;
            }

            set
            {
                weapon = value;
            }
        }

        public Shield CurrentShield
        {
            get
            {
                return shield;
            }
            set
            {
                shield = value;
            }
        }

        public new int Health
        {
            get { return health; }
            set { health = value; }
        }

        //Default Contructor
        public Player(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int maxHealth, Vector2 velocity)
                      : base(texture, transform, collisionBoxes, active,
                             maxHealth, velocity)
        {
            weaponSide = "right";
            onGround = false;
            doubleJump = true;
        }

        //Methods
        public void Update(GameTime gameTime)
        {
            this.ProcessInput();
            if (weaponSide == "right")
            {
                weapon.Position = new Vector2(this.X + (float)(rect.Width * (25.5 / 60)), this.Y + (float)(rect.Height * 30.5 / 60));
            }
            else
            {
                weapon.Position = new Vector2(this.X + (float)(rect.Width*(25.5/60)), this.Y + (float)(rect.Height * 30.5 /60));
            }

            //weapon.Velocity = velocity;
            base.Update();
            weapon.Update();
            //shield.Velocity = velocity;
            shield.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, weaponSide == "left");
            weapon.Draw(spriteBatch);
            shield.Draw(spriteBatch);

        }

        public override void Move()
        {
            this.ApplyGravity();
            base.Move();
            this.ResolveCollisions();
            shield.Position = new Vector2(this.X - 10, this.Y - 10);
            shield.Velocity = velocity;
        }

        public void ProcessInput()
        {
            velocity.X = 0;
            if (Input.KeyHeld(Keys.A)) //&& velocity.X != -5)
            {
                velocity.X -= 5;
                weaponSide = "left";
            }
            if (Input.KeyHeld(Keys.D)) //&& velocity.X != 5)
            {
                velocity.X += 5;
                weaponSide = "right";
            }
            if (Input.KeyClick(Keys.W) && (onGround || jumpsLeft > 0))
            {
                velocity.Y = -20;
                onGround = false;
                jumpsLeft--;
            }
        }

        public void ApplyGravity()
        {
            velocity += new Vector2(0, 1);
            onGround = false;
        }

        //This was very buggy I need to take another look at the PE
        public void ResolveCollisions()
        {
            foreach(GameObject wall in Game1.mapManager.CurrentMap.MapArray)
            {
                Rectangle playerPosition = new Rectangle((int) position.X, (int) position.Y, rect.Width, rect.Height);
                if (playerPosition.Intersects(wall.Rect))
                {
                    Rectangle intersection = Rectangle.Intersect(playerPosition, wall.Rect);
                    if (intersection.Width <= intersection.Height)
                    {
                        if (playerPosition.X <= wall.X)
                        {
                            playerPosition.X -= intersection.Width;
                        }
                        else
                        {
                            playerPosition.X += intersection.Width;
                        }
                    }
                    else
                    {
                        velocity.Y = 0;
                        if (playerPosition.Y <= wall.Y)
                        {
                            playerPosition.Y -= intersection.Height;
                            if (doubleJump)
                            {
                                jumpsLeft = 2;
                            }
                        }
                        else
                        {
                            playerPosition.Y += intersection.Height;
                        }
                    }
                }
                position.X = playerPosition.X;
                position.Y = playerPosition.Y;
            }
        }

        public override void TakeDamage(int damage, float knockback)
        {
            if (!Program.game.Test)
            {
                base.TakeDamage(damage, knockback);
            }
        }
        //The collison checking method in GameObject might
        //also be overridden here.
    }
}


