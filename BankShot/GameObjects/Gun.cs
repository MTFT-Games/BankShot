﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    public class Gun : Weapon
    {
        //Fields
        private bool visible;
        private int projectileCount = 1;
        private float projectileSpread = 0;
        //Projectile Base Fields:
        private Texture2D projectileTexture;
        private Rectangle projectileTransform;
        private List<Rectangle> projectileCollisionBoxes;
        private bool projectileActive;
        private double projectileHoming;
        private bool projectileBounce;
        //Projectile Stats:
        private double speed;
        private bool interceptable;
        private double lifeSpan;
        private bool fromEnemy;

        //Parameterized Constructor
        public Gun(bool visible, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback, bool interceptable,
                      double lifeSpan, int speed, Vector2 velocity,
                      Rectangle projectileTransform,
                      List<Rectangle> projectileCollisionBoxes,
                      double projectileHoming, bool projectileBounce,
                      bool projectileActive, bool fromEnemy)
                      : base(Program.game.Content.Load<Texture2D>("GunSprite"), transform, collisionBoxes,
                             active, damage, knockback, fromEnemy)
        {
            this.interceptable = interceptable;
            this.lifeSpan = lifeSpan;
            this.speed = speed;
            this.velocity = velocity;
            this.projectileTexture = Program.game.Content.Load<Texture2D>("Bullet");
            this.projectileTransform = projectileTransform;
            this.projectileCollisionBoxes = projectileCollisionBoxes;
            this.projectileActive = projectileActive;
            this.projectileHoming = projectileHoming;
            this.projectileBounce = projectileBounce;
            this.fromEnemy = fromEnemy;
            this.visible = visible;
        }

        //accessors

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public double Homing
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

        public int ProjectileCount
        {
            get
            {
                return projectileCount;
            }

            set
            {
                projectileCount = value;
            }
        }

        public Rectangle ProjectileTransform
        {
            get
            {
                return projectileTransform;
            }

            set
            {
                projectileTransform = value;
            }
        }

        public float ProjectileSpread
        {
            get
            {
                return projectileSpread;
            }

            set
            {
                projectileSpread = value;
            }
        }

        //Methods

        //Attack() will create a Projectile object
        //using the Gun's fields as parameters.
        public override void Attack()
        {
            Vector2 direction = Input.MousePosition - position;
            direction.Normalize();
            projectileTransform.X = X;
            projectileTransform.Y = Y;
            Game1.projectileManager.projectiles.Add(new Projectile(projectileTexture,
                                           projectileTransform,
                                           projectileActive, interceptable,
                                           (int)(damage * Game1.player.DamageMods[0] + Game1.player.DamageMods[1]),
                                           Knockback, lifeSpan,
                                           direction * (int)(speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]),
                                           (int)(speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]), fromEnemy,
                                           projectileHoming * Game1.player.ProjectileHoming, projectileBounce,
                                           this));
            base.Attack();
        }

        public void Attack(Vector2 direction)
        {
            direction.Normalize();
            projectileTransform.X = X;
            projectileTransform.Y = Y;
            Game1.projectileManager.projectiles.Add(new Projectile(projectileTexture,
                                           projectileTransform,
                                           projectileActive, interceptable,
                                           damage, Knockback, lifeSpan,
                                           direction * (int)speed, (int)speed, fromEnemy,
                                           projectileHoming, projectileBounce,
                                           this));
            base.Attack();
        }

        public override void Update()
        {
            //This is a very simple version of 
            //this since we dont have a cooldown 
            //yet.
            if (Input.MouseClick(1))
            {
                Attack();
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
            base.Draw(spriteBatch);
            }
        }
    }
}
