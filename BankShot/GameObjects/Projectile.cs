using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    /// <summary>
    /// Primary author: Noah Emke
    /// <para>A projectile object spawned by a gun.</para>
    /// </summary>
    public class Projectile : GameObject, IMoveable, IDamages
    {
        //Fields
        public bool interceptable;
        private int damage;
        private float knockback;
        private double lifeSpan;
        private double elapsedTime;
        public Vector2 velocity;
        public int speed;
        public bool fromEnemy;
        public bool bounce;
        public bool bounceActive;
        private bool homing;
        //The Projectile should remove itself from this list when it dies.
        public Gun gunOfOrigin;

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

        public double ElapseTime
        {
            get
            {
                return elapsedTime;
            }
            set
            {
                elapsedTime = value;
            }
        }


        /// <summary>
        /// Creates a new projectile with the given stats.
        /// </summary>
        /// <param name="texture">The texture of this projectile.</param>
        /// <param name="transform">The size and position of this projectile.</param>
        /// <param name="active">Whether this projectile starts off being active.</param>
        /// <param name="interceptable">Whether this projectile can be destroyed 
        /// by hitting another projectile.</param>
        /// <param name="damage">How much damage this projectile does upon collision.</param>
        /// <param name="knockback">The speed at which to knock back a character 
        /// upon collision.</param>
        /// <param name="lifeSpan">How long the projectile should remain alive 
        /// before self destructing.</param>
        /// <param name="velocity">The projectiles current velocity.</param>
        /// <param name="fromEnemy">Whether this projectile is form an enemy.</param>
        /// <param name="projectiles">The list of projectiles that this should 
        /// be removed from upon death.</param>
        public Projectile(Texture2D texture, Rectangle transform, bool active, 
            bool interceptable, int damage, float knockback, double lifeSpan, 
            Vector2 velocity, int speed, bool fromEnemy, bool homing, bool bounce, 
            Gun gunOfOrigin)
            : base(texture, transform, new List<Rectangle>(), active)
        {
            this.interceptable = interceptable;
            this.damage = damage;
            this.knockback = knockback;
            this.lifeSpan = lifeSpan;
            this.velocity = velocity;
            this.speed = speed;
            this.fromEnemy = fromEnemy;
            this.homing = homing;
            this.gunOfOrigin = gunOfOrigin;
            this.bounce = bounce;
            this.elapsedTime = 0;
            lifeSpan = 1;
        }

        //Methods
        public void Move() 
        {
            position += velocity;
        }

        public override void Update()
        {
            this.Move();
            X = (int)position.X;
            Y = (int)position.Y;
            if (homing)
            {
                this.Homing();
            }
            if (elapsedTime >= lifeSpan)
            {
                this.Destroy();
            }
            //this.CollisionCheck();
        }

        public void DealDamage(IDamageable target) 
        { 
            if (target is Character)
            {
                ((Character)target).TakeDamage(damage, knockback);
            }
            
            //Projectile should destroy itself after doing any damage
            //This will probably be implemented in the collision method after 
            //Deal damage is called.
        }

        /// <summary>
        /// Draws this projectile to the screen.
        /// </summary>
        /// <param name="sb">The games spritebatch.</param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            /*
            sb.Draw(
                texture,
                rect,
                null,
                Color.White,
                (float)Math.Atan2(velocity.Y, velocity.X),
                new Vector2(rect.X / 2, rect.Y / 2),
                SpriteEffects.None,
                1);
            */
        }

        //Example version of collison checking. 
        //This is vary between projectiles since some will be 
        //hitting enemies and some will hit the player.
        //All will hit walls but we do not have the list of walls 
        //yet.

        public void Destroy()
        {
            Game1.projectileManager.projectiles.Remove(this);
        }

        public void Homing()
        {
            if (fromEnemy)
            {
                Vector2 difference = new Vector2(Game1.player.Y - this.X, Game1.player.Y - this.Y);
                velocity.X += (float) (difference.X * .1);
                velocity.Y += (float) (difference.Y * .1);
                velocity.Normalize();
                velocity = velocity * speed;
            }
            else
            {
                int distance = -1;
                int tempDistance = 0;
                Enemy enemyToHome = null;
                foreach (Enemy enemy in Game1.enemyManager.SpawnedEnemies)
                {
                    tempDistance = (int) Math.Sqrt(Math.Pow(this.X - enemy.X, 2) + Math.Pow(this.Y - enemy.Y, 2));
                    if (distance < 0 || tempDistance < distance)
                    {
                        distance = tempDistance;
                        enemyToHome = enemy;
                    }
                }
                if (enemyToHome != null)
                {
                    Vector2 difference = new Vector2(enemyToHome.Y - this.X, enemyToHome.Y - this.Y);
                    if (distance < 200)
                    {
                        velocity.X += (float)(difference.X * .004);
                        velocity.Y += (float)(difference.Y * .004);
                    }
                    else if (distance < 500)
                    {
                        velocity.X += (float)(difference.X * .0015);
                        velocity.Y += (float)(difference.Y * .0015);
                    }
                    velocity.Normalize();
                    velocity = velocity * speed;
                }
            }
        }
    }
}
