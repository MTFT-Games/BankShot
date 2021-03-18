﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Character : GameObject, IMovable, IDamagable
    {
        //Fields
        private bool invincible;
        private int maxHealth;
        private int health;
        private Vector2 velocity;

        //We have not decided which of these we will use.
        private double invincibleTime;
        private int invincibleFrames;

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

        //Parameterized Constructor
        public Character(int maxHealth, Vector2 velocity)
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
        public void TakeDamage(int damage, int knockback) 
        {
            health -= damage;
            if (health < 0 )
            {
                health = 0;
            }
            this.X += knockback;
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
            //X and Y in Vector2's are floats, so 
            //I casted them.
            this.X += (int) velocity.X;
            this.Y += (int) velocity.Y;
        }
    }
}
