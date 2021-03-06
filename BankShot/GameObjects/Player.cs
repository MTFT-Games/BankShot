using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Player : Character
    {
        //Fields
        private float knockbackResist = 0;
        private float regenRate = 0;
        private Mobility mobility;
        private Weapon weapon;
        private Shield shield;
        private int money;

        //Just for the demo
        private string weaponSide;

        //Player Stats will also be included as Fields

        //Determines if the player is on the ground
        private bool onGround;

        //The following Fields are directly affected by upgrades.

        //Jumps allowed.
        private int numberOfJumps;
        private int jumpsLeft;
        public int NumberOfJumps
        {
            get
            {
                return numberOfJumps;
            }
            set
            {
                numberOfJumps = value;
            }
        }
        //Damage Multiplier and Modifier
        private double[] damageMods;
        public double[] DamageMods
        {
            get
            {
                return damageMods;
            }
            set
            {
                damageMods = value;
            }
        }

        //Projectile Count Multiplier and Modifier
        private double[] projectileCountMods;
        public double[] ProjectileCountMods
        {
            get
            {
                return projectileCountMods;
            }
            set
            {
                projectileCountMods = value;
            }
        }

        //Projectile Speed Multiplier and Modifier
        private double[] projectileSpeedMods;
        public double[] ProjectileSpeedMods
        {
            get
            {
                return projectileSpeedMods;
            }
            set
            {
                projectileSpeedMods = value;
            }
        }

        //Projectile Spread Multiplier and Modifier
        private double[] projectileSpreadMods;
        public double[] ProjectileSpreadMods
        {
            get
            {
                return projectileSpreadMods;
            }
            set
            {
                projectileSpreadMods = value;
            }
        }

        //Projectile Homing
        private double projectileHoming;
        public double ProjectileHoming
        {
            get
            {
                return projectileHoming;
            }
            set
            {
                projectileHoming = value;
            }
        }

        //Shield Health Multiplier and Modifier

        //Attack Cool Down

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

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public Vector2 CurrentKnockback
        {
            get
            {
                return knockBackVector;
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

        public float KnockbackResist
        {
            get
            {
                return knockbackResist;
            }

            set
            {
                knockbackResist = value;
            }
        }

        //Default Contructor
        public Player(Rectangle transform,
                    List<Rectangle> collisionBoxes, bool active,
                    int maxHealth, Vector2 velocity)
                    : base(Program.game.Content.Load<Texture2D>("PlayerSprite"), transform, collisionBoxes, active,
                        maxHealth, velocity)
        {
            weaponSide = "right";
            onGround = false;
            money = 0;


            CurrentWeapon = new Gun(
                true, 
                new Rectangle(50, 50, 100, 50), 
                new List<Rectangle>(), 
                true, 
                2, 
                0, 
                true, 
                .8, 
                20, 
                new Vector2(0, 0), 
                Program.game.Content.Load<Texture2D>("Bullet"), 
                new Rectangle(400, 100, 20, 20), 
                new List<Rectangle>(), 
                0, 
                true, 
                true, 
                false);
            CurrentShield = new Shield(new Rectangle(
                Rect.X - 10, 
                Rect.Y - 10, 
                Rect.Width + 20, 
                Rect.Height + 20), 
                new List<Rectangle>(), 
                true, 
                new Vector2(0, 0), 
                2.5);


            //Initializing the Upgrade Modifiers
            damageMods = new double[] { 1, 0 };
            projectileCountMods = new double[] { 1, 0 };
            projectileSpeedMods = new double[] { 1, 0 };
            projectileSpreadMods = new double[] { 1, 0 };
            projectileHoming = 1;
            numberOfJumps = 2;
            //knockBackVector = new Vector2(5, 0);
        }

        //Methods
        public void Update(GameTime gameTime)
        {
            ProcessInput();
            if (weaponSide == "right")
            {
                weapon.Position = new Vector2(X + (float)(rect.Width * (25.5 / 60)), Y + (float)(rect.Height * 30.5 / 60));
            } else
            {
                weapon.Position = new Vector2(X + (float)(rect.Width * (25.5 / 60)), Y + (float)(rect.Height * 30.5 / 60));
            }

            if (invincible)
            {
                invincibleFrames--;
                if (invincibleFrames <= 0)
                {
                    invincible = false;
                }
            }

            //weapon.Velocity = velocity;
            base.Update();

            weapon.Update();
            //shield.Velocity = velocity;
            shield.Update(gameTime);

            //Applying Upgrades if they have not been applied already:

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, weaponSide == "left");
            weapon.Draw(spriteBatch);
            shield.Draw(spriteBatch);

        }

        public override void Move()
        {
            ApplyGravity();
            if (shield.Active)
            {
                velocity.X = 0;
            }
            base.Move();
            ResolveCollisions();
            shield.Position = new Vector2(X - 10, Y - 10);
            shield.Velocity = velocity;
        }

        public void ProcessInput()
        {
            velocity.X = 0;
            if (invincibleFrames <= 30)
            {
                if (Input.KeyHeld(Keys.A)) //&& velocity.X != -5)
                {
                    velocity.X -= 6;
                    weaponSide = "left";
                }
                if (Input.KeyHeld(Keys.D)) //&& velocity.X != 5)
                {
                    velocity.X += 6;
                    weaponSide = "right";
                }
                if (Input.KeyClick(Keys.W) && (onGround || jumpsLeft > 0) && !shield.Active)
                {
                    velocity.Y = -27;
                    onGround = false;
                    jumpsLeft--;
                }
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
            foreach (GameObject wall in Game1.mapManager.CurrentMap.MapArray)
            {
                Rectangle playerPosition = new Rectangle((int)position.X, (int)position.Y, rect.Width, rect.Height);
                if (playerPosition.Intersects(wall.Rect))
                {
                    Rectangle intersection = Rectangle.Intersect(playerPosition, wall.Rect);
                    if (intersection.Width <= intersection.Height)
                    {
                        if (playerPosition.X <= wall.X)
                        {
                            playerPosition.X -= intersection.Width;
                        } else
                        {
                            playerPosition.X += intersection.Width;
                        }
                    } else
                    {
                        velocity.Y = 0;
                        if (playerPosition.Y <= wall.Y)
                        {
                            playerPosition.Y -= intersection.Height;
                            jumpsLeft = numberOfJumps;
                        } else
                        {
                            playerPosition.Y += intersection.Height;
                        }
                    }
                }
                position.X = playerPosition.X;
                position.Y = playerPosition.Y;
            }
        }

        public override void TakeDamage(int damage, float knockback, GameObject damageDealer)
        {
            if (!Program.game.Test && !invincible)
            {
                Game1.soundEffects[6].Play();
                base.TakeDamage(damage, knockback, damageDealer);
                if (knockback != 0)
                {
                    velocity.Y += -100 / Math.Abs(knockback);
                }
                invincible = true;
                invincibleFrames = 60;
            }
        }

        //The collison checking method in GameObject might
        //also be overridden here.
    }
}


