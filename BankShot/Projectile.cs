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
    class Projectile : GameObject, IMoveable, IDamages
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
            bool interceptable, int damage, int knockback, double lifeSpan, 
            Vector2 velocity, bool fromEnemy, List<Projectile> projectiles)
            : base(texture, transform, new List<Rectangle> { transform }, active)
        {
            this.interceptable = interceptable;
            this.damage = damage;
            this.knockback = knockback;
            this.lifeSpan = lifeSpan;
            this.velocity = velocity;
            this.fromEnemy = fromEnemy;
            this.projectiles = projectiles;
        }

        
        public void Move() { }

        public void DealDamage(IDamageable target) { }

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
    }
}
