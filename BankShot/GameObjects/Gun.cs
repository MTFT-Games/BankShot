using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    public class Gun : Weapon
    {
        //Fields

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
        public Gun(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback, bool interceptable, 
                      double lifeSpan, int speed, Vector2 velocity, 
                      Texture2D projectileTexture, 
                      Rectangle projectileTransform, 
                      List<Rectangle> projectileCollisionBoxes, 
                      double projectileHoming, bool projectileBounce, 
                      bool projectileActive, bool fromEnemy)
                      : base(texture, transform, collisionBoxes, 
                             active, damage, knockback, fromEnemy)
        {
            this.interceptable = interceptable;
            this.lifeSpan = lifeSpan;
            this.speed = speed;
            this.velocity = velocity;
            this.projectileTexture = projectileTexture;
            this.projectileTransform = projectileTransform;
            this.projectileCollisionBoxes = projectileCollisionBoxes;
            this.projectileActive = projectileActive;
            this.projectileHoming = projectileHoming;
            this.projectileBounce = projectileBounce;
            this.fromEnemy = fromEnemy;
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

        //Methods

        //Attack() will create a Projectile object
        //using the Gun's fields as parameters.
        public override void Attack() 
        {
            Vector2 direction = Input.MousePosition - position;
            direction.Normalize();
            projectileTransform.X = this.X;
            projectileTransform.Y = this.Y;
            Game1.projectileManager.projectiles.Add(new Projectile(projectileTexture, 
                                           projectileTransform,  
                                           projectileActive, interceptable, 
                                           (int) (damage * Game1.player.DamageMods[0] + Game1.player.DamageMods[1]), 
                                           knockback, lifeSpan, 
                                           direction * (int) (speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]), 
                                           (int)(speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]), fromEnemy, 
                                           projectileHoming * Game1.player.ProjectileHoming, projectileBounce, 
                                           this));
            base.Attack(); 
        }

        public void Attack(Vector2 direction)
        {
            direction.Normalize();
            projectileTransform.X = this.X;
            projectileTransform.Y = this.Y;
            Game1.projectileManager.projectiles.Add(new Projectile(projectileTexture,
                                           projectileTransform,
                                           projectileActive, interceptable,
                                           damage, knockback, lifeSpan,
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
                this.Attack();
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
