﻿using System;
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

        //We have not decided which of these we will use.
        protected double invincibleTime;
        protected int invincibleFrames;

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
            get
            {
                return maxHealth;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
        }
        public Double InvincibleTime
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
                         int maxHealth,Vector2 velocity)
                         : base(texture, transform, collisionBoxes, active)
        {
            this.maxHealth = maxHealth;
            health = maxHealth;
            this.velocity = velocity;
            invincible = false;
        }

        //Methods

        /// <summary>
        /// Subtracts an amount of damage from the Character's 
        /// health and applies knockback to its X value. 
        /// </summary>
        /// <param name="damage">The amount of damage taken.</param>
        /// <param name="knockback">The amount of knockback applied.</param>
        public void TakeDamage(int damage, float knockback) 
        {
            health -= damage;
            if (health < 0 )
            {
                health = 0;
            }
            this.velocity.X += knockback;
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
            position += velocity;
        }

        public override void Update()
        {
            this.Move();
            X = (int)position.X;
            Y = (int)position.Y;
        }
    }
}