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
        //Projectile Stats:
        private int speed;
        private bool interceptable;
        private double lifeSpan;
        private List<Projectile> projectiles;
        private List<Projectile> projectilesToDestroy;

        //Parameterized Constructor
        public Gun(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback, bool interceptable, 
                      double lifeSpan, int speed, Vector2 velocity, 
                      Texture2D projectileTexture, 
                      Rectangle projectileTransform, 
                      List<Rectangle> projectileCollisionBoxes, 
                      bool projectileActive)
                      : base(texture, transform, collisionBoxes, 
                             active, damage, knockback)
        {
            this.interceptable = interceptable;
            this.lifeSpan = lifeSpan;
            this.speed = speed;
            this.velocity = velocity;
            this.projectileTexture = projectileTexture;
            this.projectileTransform = projectileTransform;
            this.projectileCollisionBoxes = projectileCollisionBoxes;
            this.projectileActive = projectileActive;
            projectiles = new List<Projectile>();
            projectilesToDestroy = new List<Projectile>();
        }

        //Methods

        //Attack() will create a Projectile object
        //using the Gun's fields as parameters.
        public override void Attack() 
        {
            Vector2 direction = Input.MousePosition - position;
            direction.Normalize();
            projectiles.Add(new Projectile(projectileTexture, 
                                           projectileTransform,  
                                           projectileActive, interceptable, 
                                           damage, knockback, lifeSpan, 
                                           direction * speed, false, 
                                           projectiles));
            base.Attack(); 
        }

        public override void Update()
        {
            projectileTransform.X = this.X;
            projectileTransform.Y = this.Y;
            //This is a very simple version of 
            //this since we dont have a cooldown 
            //yet.
            if (Input.MouseClick(1))
            {
                this.Attack();
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update();
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
