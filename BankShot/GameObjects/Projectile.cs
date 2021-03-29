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
        private bool interceptable;
        private int damage;
        private float knockback;
        private double lifeSpan;
        private Vector2 velocity;
        private bool fromEnemy;
        //The Projectile should remove itself from this list when it dies.
        private List<Projectile> projectiles;

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
            Vector2 velocity, bool fromEnemy, List<Projectile> projectiles)
            : base(texture, transform, new List<Rectangle>(), active)
        {
            this.interceptable = interceptable;
            this.damage = damage;
            this.knockback = knockback;
            this.lifeSpan = lifeSpan;
            this.velocity = velocity;
            this.fromEnemy = fromEnemy;
            this.projectiles = projectiles;
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
            sb.Draw(
                texture,
                rect,
                null,
                Color.White,
                (float)Math.Atan2(velocity.Y, velocity.X),
                new Vector2(rect.X / 2, rect.Y / 2),
                SpriteEffects.None,
                1);
        }

        //Example version of collison checking. 
        //This is vary between projectiles since some will be 
        //hitting enemies and some will hit the player.
        //All will hit walls but we do not have the list of walls 
        //yet.
        public void CollisionCheck()
        {
            foreach (Enemy enemy in Game1.enemyManager.Enemies)
            {
                if (rect.Intersects(enemy.Rect))
                {
                    this.DealDamage((IDamageable)enemy);
                    this.Destroy();
                    return;

                }
            }
        }

        public void Destroy()
        {
            projectiles.Remove(this);
        }
    }
}
