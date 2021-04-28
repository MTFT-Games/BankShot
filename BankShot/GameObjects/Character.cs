using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    //Michael Robinson
    //Character
    //Represents a character in the game.
    //This encompasses both the Player and Enemies.
    //All Characters have he
    public class Character : GameObject, IMoveable, IDamageable
    {
        //Fields
        protected bool invincible;
        protected int maxHealth;
        protected int health;
        protected Vector2 velocity;
        protected Vector2 truePosition;

        //We have not decided which of these we will use.
        protected double invincibleTime;
        protected int invincibleFrames;
        protected Vector2 knockBackVector;

        //Properties
        public bool Invincible
        {
            get
            {
                return invincible;
            }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public int Health
        {
            get
            {
                return health;
            }
        }
        public double InvincibleTime
        {
            get
            {
                return invincibleTime;
            }
        }
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

        //Parameterized Constructor
        public Character(Texture2D texture, Rectangle transform,
                         List<Rectangle> collisionBoxes, bool active,
                         int maxHealth, Vector2 velocity)
                         : base(texture, transform, collisionBoxes, active)
        {
            this.maxHealth = maxHealth;
            health = maxHealth;
            this.velocity = velocity;
            invincible = false;
            knockBackVector = new Vector2(0, 0);
            truePosition = new Vector2(0, 0);
            truePosition.X = X + rect.Width / 2;
            truePosition.Y = Y + rect.Height / 2;
        }

        //Methods

        /// <summary>
        /// Subtracts an amount of damage from the Character's 
        /// health and applies knockback to its X value. 
        /// </summary>
        /// <param name="damage">The amount of damage taken.</param>
        /// <param name="knockback">The amount of knockback applied.</param>
        public virtual void TakeDamage(int damage, float knockback, GameObject damageDealer)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            knockBackVector = new Vector2(1, 0);
            knockBackVector *= knockback;
        }

        /// <summary>
        /// Adds an amount of healing to the Character's
        /// health.
        /// </summary>
        /// <param name="healing">The amount healed.</param>
        public void Heal(int healing)
        {
            health += healing;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        /// <summary>
        /// Applies the velocity vector to the 
        /// Character's X and Y values.
        /// </summary>
        public virtual void Move()
        {
            ApplyKnockBack();
            position += velocity;
        }

        public override void Update()
        {
            Move();
            X = (int)position.X;
            Y = (int)position.Y;
            truePosition.X = X + rect.Width / 2;
            truePosition.Y = Y + rect.Height / 2;
        }
        public void ApplyKnockBack()
        {
            velocity += knockBackVector;
            if (knockBackVector.X != 0)
            {
                knockBackVector.X -= knockBackVector.X / Math.Abs(knockBackVector.X) / 2;
            }
        }
    }
}
