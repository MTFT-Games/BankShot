﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Projectile : GameObject, IMovable, IDamages
    {
        //Fields
        private bool interceptable;
        private int damage;
        private int knockback;
        private double lifeSpan;
        private Vector2 velocity;
        private bool fromEnemy;
        private List<Projectile> projectiles;

        //Parameterized Contructor
        public Projectile(Texture2D texture, Rectangle transform,
                          List<Rectangle> collisionBoxes, bool active,
                          bool interceptable, int damage, int knockback, 
                          double lifeSpan, Vector2 velocity, bool fromEnemy,
                          List<Projectile> projectiles)
                          : base(texture, transform, collisionBoxes, active)
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
        public void Move() { }

        public void DealDamage(IDamagable target) { }
    }
}
